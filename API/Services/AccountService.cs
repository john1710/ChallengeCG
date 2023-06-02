using API.Data.Account;
using API.Interfaces.Repositories;
using API.Interfaces.Services;
using API.Models;
using FluentValidation;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IValidator<Account> _validator;
        public AccountService(IAccountRepository accountRepository, IValidator<Account> validator)
        {
            _accountRepository = accountRepository;
            _validator = validator;
        }
        public async Task<Account> Create(UpsertAccountInput entity)
        {
            var account = new Account(entity.Name, entity.Description);
            await _validator.ValidateAndThrowAsync(account);
            return await _accountRepository.Add(account);
        }
        public async Task<Account> Update(UpsertAccountInput entity)
        {
            var account = new Account(entity.Id, entity.Name, entity.Description);
            await _validator.ValidateAndThrowAsync(account);
            return await _accountRepository.Update(account);
        }

        public async Task Delete(long id)
        {
            await _accountRepository.Delete(id);
        }

        public async Task<ICollection<Account>> GetAll()
        {
            return await _accountRepository.GetAll();
        }

        public async Task<Account> GetById(long id)
        {
            return await _accountRepository.GetById(id);
        }

    }
}
