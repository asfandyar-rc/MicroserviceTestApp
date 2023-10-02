using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transaction.WebApi.Services.Interface;

namespace Transaction.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly ITransactionService _transactionService;

        public AccountController(ILogger<AccountController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("api/account/balance")]
        public decimal balance(int accountNumber)
        {
            var result = _transactionService.GetBalance(accountNumber);
            return result.Result;
        }

        [HttpPost]
        [Route("api/account/deposit")]
        public string deposit(int AccountNumber, decimal Amount, String Description)
        {
            var result = _transactionService.Deposit(AccountNumber, Amount, Description);
            return "Transaction Performed Successfully";
        }

        [HttpPost]
        [Route("api/account/withdraw")]
        public string withdraw(int AccountNumber, decimal Amount, String Description)
        {
            var result = _transactionService.Withdraw(AccountNumber, Amount, Description);
            return "Transaction Performed Successfully";
        }
    }
}