using Transaction.WebApi.Models;
using Transaction.WebApi.Services.Interface;

namespace Transaction.WebApi.Services
{
    public class TransactionService : ITransactionService
    {
        public async Task<decimal>  GetBalance(int AccountNumber)
        {
            try
            {
                return 0.0M ;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> Deposit(int AccountNumber, decimal Amount, String Description)
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

        public async Task<bool> Withdraw(int AccountNumber, decimal Amount, String Description)
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
