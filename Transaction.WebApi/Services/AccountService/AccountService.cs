using System.Data;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly TransactionDbContext _dbContext;
        private readonly ILogger _logger;
        public AccountService(TransactionDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<decimal> GetBalance(int AccountNumber)
        {
            try
            {
                _logger.LogInformation("Get Balance Method requested with Account Number: " + AccountNumber);
                var accountSummary= _dbContext.AccountSummaries.FirstOrDefault(x=>x.AccountNumber == AccountNumber);
                return await Task.FromResult(accountSummary.Balance);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> Deposit(int AccountNumber, decimal Amount, string Description)
        {
            try
            {
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> Withdraw(int AccountNumber, decimal Amount, string Description)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
