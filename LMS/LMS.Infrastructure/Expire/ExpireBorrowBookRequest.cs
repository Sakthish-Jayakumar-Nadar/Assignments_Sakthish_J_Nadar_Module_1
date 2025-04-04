using LMS.Domain.Interface;
using LMS.Domain.Model;
using LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LMS.Infrastructure.Expire
{
    public class ExpireBorrowBookRequest : IHostedService
    {
        private Timer _timer;
        //protected readonly LMSDbContext _lMSDbContext;
        protected readonly IServiceProvider _serviceProvider;
        public ExpireBorrowBookRequest(IServiceProvider serviceProvider)
        {
             _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ExpireRequest, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        private void ExpireRequest(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var lMSDbContext = scope.ServiceProvider.GetRequiredService<LMSDbContext>();
                var expiredBorrowRequest = lMSDbContext.Loans.Where(l => l.Status == 3 && EF.Functions.DateDiffMinute(l.BorrowRequestTime, DateTime.Now) > 2);
                foreach(var ebr in  expiredBorrowRequest)
                {
                    ebr.Status = 5;
                }
                var expiredBorrowAcceptRequest = lMSDbContext.Loans.Where(l => l.Status == 4 && EF.Functions.DateDiffMinute(l.BorrowRequestTime, DateTime.Now) > 5);
                foreach (var ebar in expiredBorrowAcceptRequest)
                {
                    Book book = lMSDbContext.Books.FirstOrDefault(b => b.Id == ebar.BookId);
                    if (book != null)
                    {
                        book.BookCount++;
                    }
                    ebar.Status = 5;
                }
                lMSDbContext.SaveChanges();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
