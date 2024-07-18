using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class AccountMemberDAO
    {

        public static List<AccountMember> GetAllAccountMember()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.AccountMembers.ToList();
        }
        public static void AddAccountMember(AccountMember accountMember)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (accountMember == null)
            {
                throw new ArgumentNullException(nameof(accountMember));
            }
            else
            {
                context.AccountMembers.Add(accountMember);
                context.SaveChanges();
            }
        }

        public static void DeleteAccountMember(AccountMember accountMember)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (accountMember == null)
            {
                throw new ArgumentNullException(nameof(accountMember));
            }
            else
            {
                context.AccountMembers.Remove(accountMember);
                context.SaveChanges();
            }
        }

        public static void UpdateAccountMember(AccountMember accountMember)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (accountMember == null)
            {
                throw new ArgumentNullException(nameof(accountMember));
            }
            else
            {
                context.AccountMembers.Update(accountMember);
                context.SaveChanges();
            }
        }

        public static AccountMember GetAccountMemberById(String id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var accountMember = (from a in context.AccountMembers
                                 where a.MemberId == id
                                 select a).FirstOrDefault();
            return accountMember;
        }

        public static AccountMember GetAccountMemberByName(String name)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var accountMember = (from a in context.AccountMembers
                                 where a.FullName == name
                                 select a).FirstOrDefault();
            return accountMember;
        }
        public static AccountMember GetAccountMemberByRole(int role)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var accountMember = (from a in context.AccountMembers
                                 where a.MemberRole == role
                                 select a).FirstOrDefault();
            return accountMember;
        }

    }
}
