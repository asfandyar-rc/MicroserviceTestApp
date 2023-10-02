using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transaction.WebApi.Dto.Account;
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
        public async Task<ActionResult<ViewBalanceDto>> balance(int accountNumber)
        {
            var result = await _transactionService.GetBalance(accountNumber); 
            if (result != null)
            {
                return result;
            }
            return new StatusCodeResult(404);
        }

        [HttpPost]
        [Route("api/account/deposit")]
        public async Task<ActionResult<AddDepositTransactionDto>> deposit([FromBody] AddDepositTransactionDto data)
        {
            var result = await _transactionService.Deposit(data);
            if(result != null)
            {
                return result;
            }
            return new StatusCodeResult(404);
        }

        [HttpPost]
        [Route("api/account/withdraw")]
        public async Task<ActionResult<AddWithdrawTransactionDto>> withdraw([FromBody] AddWithdrawTransactionDto data)
        {
            var result = await _transactionService.Withdraw(data);
            if (result != null)
            {
                return result;
            }
            return new StatusCodeResult(404);
        }
    }
}