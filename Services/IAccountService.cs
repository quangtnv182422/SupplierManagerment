using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects.BussinessObjects;
namespace Services
{
    public interface IAccountService
    {
        void AddAccountMember(AccountMember accountMember);
        void DeleteAccountMember(AccountMember accountMember);
        void UpdateAccountMember(AccountMember accountMember);
        AccountMember GetAccountMemberById(string id);
        AccountMember GetAccountMemberByName(string name);
        AccountMember GetAccountMemberByRole(int role);
        List<AccountMember> GetAllAccountMembers();
    }
}
