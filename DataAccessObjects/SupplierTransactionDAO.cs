using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class SupplierTransactionDAO
    {

        public static List<SupplierTransaction> GetAllSupplierTransaction()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.SupplierTransactions.ToList();
        }
        public static void AddSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplierTransaction == null)
            {
                throw new ArgumentNullException(nameof(supplierTransaction));
            }
            else
            {
                context.SupplierTransactions.Add(supplierTransaction);
                context.SaveChanges();
            }
        }

        public static void DeleteSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplierTransaction == null)
            {
                throw new ArgumentNullException(nameof(supplierTransaction));
            }
            else
            {
                context.SupplierTransactions.Remove(supplierTransaction);
                context.SaveChanges();
            }
        }

        public static void UpdateSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplierTransaction == null)
            {
                throw new ArgumentNullException(nameof(supplierTransaction));
            }
            else
            {
                context.SupplierTransactions.Update(supplierTransaction);
                context.SaveChanges();
            }
        }

        public static SupplierTransaction GetSupplierTransactionById(int id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var supplierTransaction = (from st in context.SupplierTransactions
                                       where st.SupplierTransactionId == id
                                       select st).FirstOrDefault();
            return supplierTransaction;
        }
    }
}
