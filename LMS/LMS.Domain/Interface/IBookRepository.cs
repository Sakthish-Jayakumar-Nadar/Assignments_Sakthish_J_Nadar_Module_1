using LMS.Domain.Model;

namespace LMS.Domain.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> AddBookAsync(Book book);
        Task<Book> UpdateBookByIdAsync(Book book);
        Task<bool> DeleteBookByIdAsync(int id);
        Task<bool> BorrowBookAsync(int id, string mid);
        Task<bool> ReturnBookAsync(int id, int lid, string mid);
        Task<bool> LoanBookAsync(int id, string mid);
        Task<bool> BorrowBookAcceptAsync(int id, int lid, string mid);
        Task<bool> BorrowBookRejectAsync(int id, int lid, string mid);
        Task<IEnumerable<Loan>> GetLoanBooks(string mid);
        Task<IEnumerable<Loan>> GetReturnBooks(string mid);
        Task<IEnumerable<Loan>> GetRequestsBooks(string mid);
        Task<IEnumerable<Loan>> GetRequestsAdmin();
        Task<IEnumerable<Loan>> GetMemberLoansAsync(string mid);
    }
}
