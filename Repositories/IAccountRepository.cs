using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAccountRepository
    {
        List<AccountMember> GetAllAccountMember();
        void AddAccountMember(AccountMember accountMember);
        void UpdateAccountMember(AccountMember accountMember);
        void DeleteAccountMember(AccountMember accountMember);
        AccountMember GetAccountMemberById(String id);
        AccountMember GetAccountMemberByName(String name);
        AccountMember GetAccountMemberByRole(int role);
    }
}
