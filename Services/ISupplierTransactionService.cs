using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISupplierTransactionService
    {
        void AddSupplierTransaction(SupplierTransaction supplierTransaction);
        void DeleteSupplierTransaction(SupplierTransaction supplierTransaction);
        List<SupplierTransaction> GetAllSupplierTransactions();
        SupplierTransaction GetSupplierTransactionById(int id);
        void UpdateSupplierTransaction(SupplierTransaction supplierTransaction);
        List<SupplierTransaction> GetSupplierTransactionsBySupplierId(int supplierId);
        List<SupplierTransaction> GetSupplierTransactionsByDateRange(DateOnly startDate, DateOnly endDate);
        List<SupplierTransaction> GetSupplierTransactionsByAmountRange(decimal minAmount, decimal maxAmount);
        List<SupplierTransaction> GetSupplierTransactionsByPaymentMethod(string paymentMethod);
    }
}
