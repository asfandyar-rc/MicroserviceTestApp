using Transaction.WebApi.Models.Enums;

namespace Transaction.WebApi.Dto.Account
{
    public class AddWithdrawTransactionDto
    {
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public TransactionTypes TransactionType { get; set; } = TransactionTypes.Withdraw;
        public decimal Amount { get; set; }
    }
}
