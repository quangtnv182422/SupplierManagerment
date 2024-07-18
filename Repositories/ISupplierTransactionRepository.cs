using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISupplierTransactionRepository
    {
        List<SupplierTransaction> GetAllSupplierTransaction();
        void AddSupplierTransaction(SupplierTransaction supplierTransaction);
        void DeleteSupplierTransaction(SupplierTransaction supplierTransaction);
        void UpdateSupplierTransaction(SupplierTransaction supplierTransaction);
        SupplierTransaction GetSupplierTransactionById(int id);
    }
}
