namespace Transaction.WebApi.Dto.Account
{
    public class ViewBalanceDto
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
}
