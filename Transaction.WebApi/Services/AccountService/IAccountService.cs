using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.AccountService
{
    public interface IAccountService
    {
        public Task<decimal> GetBalance(int AccountNumber);
        public Task<bool> Deposit(int AccountNumber, decimal Amount, string Description);
        public Task<bool> Withdraw(int AccountNumber, decimal Amount, string Description);
    }
}
