using Transaction.WebApi.Dto.Account;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.AccountService
{
    public interface IAccountService
    {
        public Task<ViewBalanceDto> GetBalance(int AccountNumber);
        public Task<bool> Deposit(int AccountNumber, decimal Amount, string Description);
        public Task<bool> Withdraw(int AccountNumber, decimal Amount, string Description);
    }
}
