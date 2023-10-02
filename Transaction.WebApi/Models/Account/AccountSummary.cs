using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction.WebApi.Models.Account
{
    public class AccountSummary
    {
        public Guid id { get; set; } = Guid.NewGuid();

        [Key]
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public IEnumerable<AccountTransaction>? AccountTransactions { get; set; }
    }
}
