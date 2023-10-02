using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transaction.WebApi.Services.AccountService;

namespace Transaction.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _transactionService;

        public AccountController(ILogger<AccountController> logger, IAccountService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("api/account/balance")]
        public async Task<ActionResult<decimal>> balance(int accountNumber)
        {
            var result = await _transactionService.GetBalance(accountNumber);
            return result;
        }

        [HttpPost]
        [Route("api/account/deposit")]
        public async Task<ActionResult<string>> deposit(int AccountNumber, decimal Amount, String Description)
        {
            var result = await _transactionService.Deposit(AccountNumber, Amount, Description);
            return "Transaction Performed Successfully";
        }

        [HttpPost]
        [Route("api/account/withdraw")]
        public async Task<ActionResult<string>> withdraw(int AccountNumber, decimal Amount, String Description)
        {
            var result = await _transactionService.Withdraw(AccountNumber, Amount, Description);
            return "Transaction Performed Successfully";
        }
    }
}