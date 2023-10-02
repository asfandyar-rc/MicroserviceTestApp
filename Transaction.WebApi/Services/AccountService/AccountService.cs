using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Transactions;
using Transaction.WebApi.Dto.Account;
using Transaction.WebApi.Models;
using Transaction.WebApi.Models.Account;

namespace Transaction.WebApi.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly TransactionDbContext _dbContext;
        private readonly IMapper _mapper;
        public AccountService(IMapper mapper, TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ViewBalanceDto?> GetBalance(int AccountNumber)
        {
            try
            {
                bool isValidated = ValidateAccount(AccountNumber);
                if (isValidated)
                {
                    var accountSummary = await _dbContext.AccountSummaries.FirstOrDefaultAsync(x => x.AccountNumber == AccountNumber);
                    return _mapper.Map<ViewBalanceDto>(accountSummary);
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception("Unable to get Balance Details");
            }
        }

        public async Task<AddDepositTransactionDto> Deposit(AddDepositTransactionDto depositData)
        {
            try
            {
                var isValidated = ValidateAccount(depositData.AccountNumber);
                if (isValidated)
                {
                    //Updating Account Balance
                    var accountSummary = await _dbContext.AccountSummaries.FirstOrDefaultAsync(x => x.AccountNumber == depositData.AccountNumber);
                    accountSummary.Balance = accountSummary.Balance + depositData.Amount;
                    _dbContext.Update(accountSummary);
                    await _dbContext.SaveChangesAsync();

                    //Adding transaction
                    var data = _mapper.Map<AccountTransaction>(depositData);
                    _dbContext.AccountTransactions.Add(data);
                    var result = await _dbContext.SaveChangesAsync();
                    return (depositData);
                }
               return null;
                
            }
            catch (Exception)
            {
                throw new Exception("Unable to perform Transaction");
            }
        }

        public async Task<AddWithdrawTransactionDto> Withdraw(AddWithdrawTransactionDto withdrawData)
        {
            try
            {
                var isValidated = ValidateAccount(withdrawData.AccountNumber);
                if (isValidated)
                {
                    //Updating Account Balance
                    var accountSummary = await _dbContext.AccountSummaries.FirstOrDefaultAsync(x => x.AccountNumber == withdrawData.AccountNumber);
                    accountSummary.Balance = accountSummary.Balance - withdrawData.Amount;
                    _dbContext.Update(accountSummary);
                    await _dbContext.SaveChangesAsync();

                    //Adding transaction
                    var data = _mapper.Map<AccountTransaction>(withdrawData);
                    _dbContext.AccountTransactions.Add(data);
                    var result = await _dbContext.SaveChangesAsync();
                    return (withdrawData);
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception("Unable to perform Transaction");
            }
        }

        private bool ValidateAccount(int AccountNumber)
        {

            try
            {
                return _dbContext.AccountSummaries.Any(x => x.AccountNumber == AccountNumber);
            }
            catch (Exception)
            {

                throw new Exception("Unable to validate Account !");
            }
        }
    }
}
