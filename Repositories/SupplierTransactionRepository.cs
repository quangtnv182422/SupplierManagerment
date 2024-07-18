using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierTransactionRepository : ISupplierTransactionRepository
    {
        public void AddSupplierTransaction(SupplierTransaction supplierTransaction) => SupplierTransactionDAO.AddSupplierTransaction(supplierTransaction);


        public void DeleteSupplierTransaction(SupplierTransaction supplierTransaction) => SupplierTransactionDAO.DeleteSupplierTransaction(supplierTransaction);


        public List<SupplierTransaction> GetAllSupplierTransaction() => SupplierTransactionDAO.GetAllSupplierTransaction();


        public SupplierTransaction GetSupplierTransactionById(int id) => SupplierTransactionDAO.GetSupplierTransactionById(id);


        public void UpdateSupplierTransaction(SupplierTransaction supplierTransaction) => SupplierTransactionDAO.UpdateSupplierTransaction(supplierTransaction);

    }
}
