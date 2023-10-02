
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Transaction.WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Transaction.WebApi.Models.Account
{
    public class AccountTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public decimal Amount { get; set; }

    }
}
