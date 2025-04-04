using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using LMS.Application.Exception;
using LMS.Domain.Interface;
using LMS.Domain.Model;
using LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LMS.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        protected readonly LMSDbContext _lMSDbContext;
        public BookRepository(LMSDbContext lMSDbContext)
        {
            _lMSDbContext = lMSDbContext;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _lMSDbContext.Books.ToListAsync();
        }
        public async Task<Book> GetBookByIdAsync(int id)
        {
            Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(book == null)
            {
                throw new NotFoundException("Book not found");
            }
            Category category = await _lMSDbContext.Categories.FirstOrDefaultAsync(c => c.Id == book.CategoryId);
            if (category == null)
            {
                throw new NotFoundException("Category not found");
            }
            book.Category = category;
            book.Category.Books = null;
            return book;
        }
        public async Task<bool> AddBookAsync(Book book)
        {
            await _lMSDbContext.AddAsync(book);
            await _lMSDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Book> UpdateBookByIdAsync(Book book)
        {
            Book bookToUpdate = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if(bookToUpdate == null)
            {
                throw new NotFoundException("Book not found");
            }
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.CategoryId = book.CategoryId;
            bookToUpdate.PublishedYear = book.PublishedYear;
            bookToUpdate.BookCount = book.BookCount;
            await _lMSDbContext.SaveChangesAsync();
            return bookToUpdate;
        }
        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }
            if (book is not null)
            {
                _lMSDbContext.Books.Remove(book);
                return await _lMSDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> BorrowBookAsync(int id, string mid)
        {
            Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }
            if(book.BookCount > 0)
            {
                if (!_lMSDbContext.Loans.Any(l => l.BookId == id && l.MemberId == mid && (l.Status == 1 || l.Status == 3 || l.Status == 4)))
                {
                    Loan loan = new Loan()
                    {
                        MemberId  = mid,
                        BookId = id,
                        LoanDate = DateTime.MinValue,
                        DueDate = DateTime.MinValue,
                        ReturnDate = DateTime.MinValue,
                        BorrowRequestTime = DateTime.Now,
                        Status = 3,
                    };
                    await _lMSDbContext.Loans.AddAsync(loan);
                    await _lMSDbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> ReturnBookAsync(int id, int lid, string mid)
        {
            Loan loan = await _lMSDbContext.Loans.FirstOrDefaultAsync(l => l.Id == lid && l.BookId == id && l.MemberId == mid && l.Status == 1);
            if (loan == null)
            {
                throw new NotFoundException("Loan data not found");
            }
            if (loan != null && loan.Status != 2)
            {
                loan.ReturnDate = DateTime.Now;
                loan.Status = 2;
                await _lMSDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> LoanBookAsync(int id, string email)
        {
            Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            Member member = await _lMSDbContext.Members.FirstOrDefaultAsync(m => m.Email == email);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }
            if (member == null)
            {
                throw new NotFoundException("Email not found");
            }
            if (book.BookCount > 0)
            {
                if(await _lMSDbContext.Loans.AnyAsync(l => l.BookId == id && l.MemberId == member.Id && l.Status == 3))
                {
                    Loan loan = await _lMSDbContext.Loans.FirstOrDefaultAsync(l => l.BookId == id && l.MemberId == member.Id && l.Status == 3);
                    if(loan != null)
                    {
                        loan.LoanDate = DateTime.Now;
                        loan.DueDate = DateTime.Now.AddDays(2);
                        loan.Status = 1;
                        await _lMSDbContext.SaveChangesAsync();
                        return true;
                    }
                }
                else if (!(await _lMSDbContext.Loans.AnyAsync(l => l.BookId == id && l.MemberId == member.Id && l.Status == 1)))
                {
                    Loan loan = new Loan()
                    {
                        MemberId = member.Id,
                        BookId = id,
                        LoanDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(2),
                        ReturnDate = DateTime.MinValue,
                        BorrowRequestTime = DateTime.MinValue,
                        Status = 1,
                    };
                    await _lMSDbContext.Loans.AddAsync(loan);
                    await _lMSDbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> BorrowBookAcceptAsync(int id, int lid, string mid)
        {
            Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }
            if (book.BookCount > 0)
            {
                Loan loan = await _lMSDbContext.Loans.FirstOrDefaultAsync(l => l.BookId == id && l.MemberId == mid && l.Id == lid && l.Status == 3);
                if (loan != null)
                {
                    loan.LoanDate = DateTime.MinValue;
                    loan.DueDate = DateTime.MinValue;
                    loan.ReturnDate = DateTime.MinValue;
                    loan.BorrowRequestTime = DateTime.Now;
                    loan.Status = 4;
                    book.BookCount--;
                    await _lMSDbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> BorrowBookRejectAsync(int id, int lid, string mid)
        {
            Loan loan = await _lMSDbContext.Loans.FirstOrDefaultAsync(l => l.BookId == id && l.MemberId == mid && l.Id == lid && l.Status == 3);
            if (loan != null)
            {
                loan.LoanDate = DateTime.MinValue;
                loan.DueDate = DateTime.MinValue;
                loan.ReturnDate = DateTime.MinValue;
                loan.BorrowRequestTime = DateTime.Now;
                loan.Status = 6;
                await _lMSDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Loan>> GetLoanBooks(string mid)
        {
            IEnumerable<Loan> loans = _lMSDbContext.Loans.Where(l => l.MemberId == mid && l.Status == 1);
            foreach (Loan loan in loans)
            {
                Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == loan.BookId);
                if (book != null)
                {
                    loan.BookName = book.Title;
                }
            }
            return loans;
        }
        public async Task<IEnumerable<Loan>> GetReturnBooks(string mid)
        {
            IEnumerable<Loan> loans = _lMSDbContext.Loans.Where(l => l.MemberId == mid && l.Status == 2);
            return loans;
        }
        public async Task<IEnumerable<Loan>> GetRequestsBooks(string mid)
        {
            IEnumerable<Loan> loans = _lMSDbContext.Loans.Where(l => l.MemberId == mid && (l.Status == 3 || l.Status == 4 || l.Status == 5 || l.Status == 6)).OrderByDescending(l => l.BorrowRequestTime);
            foreach(Loan loan in loans)
            {
                Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == loan.BookId);
                if(book != null)
                {
                    loan.BookName = book.Title;
                }
            }
            return loans;
        }
        public async Task<IEnumerable<Loan>> GetRequestsAdmin()
        {
            IEnumerable<Loan> loans = _lMSDbContext.Loans.Where(l => l.Status == 3 || l.Status == 4 || l.Status == 5 || l.Status == 6).OrderByDescending(l => l.BorrowRequestTime);
            foreach (Loan loan in loans)
            {
                Member member = await _lMSDbContext.Members.FirstOrDefaultAsync(m => m.Id == loan.MemberId);
                Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == loan.BookId);
                if(member != null)
                {
                    loan.Email = member.Email;
                }
                if (book != null)
                {
                    loan.BookName = book.Title;
                }
            }
            return loans;
        }
        public async Task<IEnumerable<Loan>> GetMemberLoansAsync(string mid)
        {
            IEnumerable<Loan> loans = _lMSDbContext.Loans.Where(l => l.MemberId == mid && l.Status == 1).OrderByDescending(l => l.LoanDate);
            foreach (Loan loan in loans)
            {
                Book book = await _lMSDbContext.Books.FirstOrDefaultAsync(b => b.Id == loan.BookId);
                if (book != null)
                {
                    loan.BookName = book.Title;
                }
            }
            return loans;
        }
    }
}
