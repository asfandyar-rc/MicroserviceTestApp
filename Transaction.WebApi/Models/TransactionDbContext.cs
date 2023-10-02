using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Transaction.WebApi.Models
{
    public class TransactionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\RCMSSQLSERVER;Database=TransactionDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<AccountSummary> AccountSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountSummary>().HasData(
                new AccountSummary
                {
                    id = Guid.NewGuid(),
                    AccountNumber = 1001,
                    Balance = 500,
                    Currency = "USD"
                },
                new AccountSummary {

                    id = Guid.NewGuid(),
                    AccountNumber = 1002,
                    Balance = 500,
                    Currency = "USD"
                }
                ,
                new AccountSummary
                {

                    id = Guid.NewGuid(),
                    AccountNumber = 1003,
                    Balance = 500,
                    Currency = "USD"
                }
            );
        }
    }
}
