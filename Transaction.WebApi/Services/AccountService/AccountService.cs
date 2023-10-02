using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.AccountService
{
    public class AccountService : IAccountService
    {
        public async Task<decimal> GetBalance(int AccountNumber)
        {
            try
            {
                return 0.0M;
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
                return true;
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
