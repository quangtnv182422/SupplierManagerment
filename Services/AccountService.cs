using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects.BussinessObjects;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public void AddAccountMember(AccountMember accountMember)
        {
            if (accountMember == null)
            {
                throw new ArgumentNullException(nameof(accountMember));
            }
            _accountRepository.AddAccountMember(accountMember);
        }

        public void DeleteAccountMember(AccountMember accountMember)
        {
            if (accountMember == null)
            {
                throw new ArgumentNullException(nameof(accountMember));
            }
            _accountRepository.DeleteAccountMember(accountMember);
        }

        public void UpdateAccountMember(AccountMember accountMember)
        {
            if (accountMember == null)
            {
                throw new ArgumentNullException(nameof(accountMember));
            }
            _accountRepository.UpdateAccountMember(accountMember);
        }

        public AccountMember GetAccountMemberById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _accountRepository.GetAccountMemberById(id);
        }

        public AccountMember GetAccountMemberByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            return _accountRepository.GetAccountMemberByName(name);
        }

        public AccountMember GetAccountMemberByRole(int role)
        {
            return _accountRepository.GetAccountMemberByRole(role);
        }

        public List<AccountMember> GetAllAccountMembers()
        {
            return _accountRepository.GetAllAccountMember();
        }
    }
}
