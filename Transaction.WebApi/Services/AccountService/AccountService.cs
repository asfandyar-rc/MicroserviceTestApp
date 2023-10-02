using AutoMapper;
using System.Data;
using Transaction.WebApi.Dto.Account;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services.AccountService
{
    public class AccountService : IAccountService
    {
        //private readonly TransactionDbContext _dbContext;
        private readonly IMapper _mapper;
        public AccountService( IMapper mapper)
        {
            //_dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ViewBalanceDto> GetBalance(int AccountNumber)
        {
            try
            {
                TransactionDbContext _dbContext = new TransactionDbContext();
                var accountSummary = _dbContext.AccountSummaries.FirstOrDefault(x => x.AccountNumber == AccountNumber);
                return _mapper.Map<ViewBalanceDto>(accountSummary);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> Deposit(int AccountNumber, decimal Amount, string Description)
        {
            try
            {
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> Withdraw(int AccountNumber, decimal Amount, string Description)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
