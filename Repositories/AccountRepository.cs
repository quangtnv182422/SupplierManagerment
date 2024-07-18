using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccountMember(AccountMember accountMember) => AccountMemberDAO.AddAccountMember(accountMember);


        public void DeleteAccountMember(AccountMember accountMember) => AccountMemberDAO.DeleteAccountMember(accountMember);
 
        public void UpdateAccountMember(AccountMember accountMember) => AccountMemberDAO.UpdateAccountMember(accountMember);

        public AccountMember GetAccountMemberById(string id) => AccountMemberDAO.GetAccountMemberById(id);


        public AccountMember GetAccountMemberByName(string name) => AccountMemberDAO.GetAccountMemberByName(name);


        public AccountMember GetAccountMemberByRole(int role) => AccountMemberDAO.GetAccountMemberByRole(role);


        public List<AccountMember> GetAllAccountMember() => AccountMemberDAO.GetAllAccountMember();

    }
}
