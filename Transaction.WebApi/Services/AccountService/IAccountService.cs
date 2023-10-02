using Transaction.WebApi.Dto.Account;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.AccountService
{
    public interface IAccountService
    {
        public Task<ViewBalanceDto?> GetBalance(int AccountNumber);
        public Task<AddDepositTransactionDto> Deposit(AddDepositTransactionDto depositData);
        public Task<AddWithdrawTransactionDto> Withdraw(AddWithdrawTransactionDto withdrawData);
    }
}
