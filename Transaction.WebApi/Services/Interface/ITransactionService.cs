using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.Interface
{
    public interface ITransactionService
    {
        public  Task<decimal> GetBalance(int AccountNumber);
        public  Task<bool> Deposit(int AccountNumber, decimal Amount, String Description);
        public  Task<bool> Withdraw(int AccountNumber, decimal Amount, String Description);
    }
}
