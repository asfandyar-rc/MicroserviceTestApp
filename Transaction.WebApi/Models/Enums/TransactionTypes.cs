using System.ComponentModel;

namespace Transaction.WebApi.Models.Enums
{
    public enum TransactionTypes
    {
        [Description("Added Amount in Your Account")]
        Deposit,
        [Description("Deducted Amount from your Account")]
        Withdraw,

    }
}
