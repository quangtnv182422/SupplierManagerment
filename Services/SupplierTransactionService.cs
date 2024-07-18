using DataAccessObjects.BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SupplierTransactionService : ISupplierTransactionService
    {
        private readonly ISupplierTransactionRepository _supplierTransactionRepository;

        public SupplierTransactionService(ISupplierTransactionRepository supplierTransactionRepository)
        {
            _supplierTransactionRepository = supplierTransactionRepository;
        }

        public void AddSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            if (supplierTransaction == null)
            {
                throw new ArgumentNullException(nameof(supplierTransaction));
            }
            _supplierTransactionRepository.AddSupplierTransaction(supplierTransaction);
        }

        public void DeleteSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            if (supplierTransaction == null)
            {
                throw new ArgumentNullException(nameof(supplierTransaction));
            }
            _supplierTransactionRepository.DeleteSupplierTransaction(supplierTransaction);
        }

        public List<SupplierTransaction> GetAllSupplierTransactions()
        {
            return _supplierTransactionRepository.GetAllSupplierTransaction();
        }

        public SupplierTransaction GetSupplierTransactionById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid supplier transaction ID", nameof(id));
            }
            return _supplierTransactionRepository.GetSupplierTransactionById(id);
        }

        public void UpdateSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            if (supplierTransaction == null)
            {
                throw new ArgumentNullException(nameof(supplierTransaction));
            }
            _supplierTransactionRepository.UpdateSupplierTransaction(supplierTransaction);
        }

        // LINQ queries for additional business logic

        public List<SupplierTransaction> GetSupplierTransactionsBySupplierId(int supplierId)
        {
            var supplierTransactions = _supplierTransactionRepository.GetAllSupplierTransaction();
            return supplierTransactions.Where(st => st.SupplierId == supplierId).ToList();
        }

        public List<SupplierTransaction> GetSupplierTransactionsByDateRange(DateOnly startDate, DateOnly endDate)
        {
            var supplierTransactions = _supplierTransactionRepository.GetAllSupplierTransaction();
            return supplierTransactions
                .Where(st => st.TransactionDate.HasValue &&
                             st.TransactionDate.Value >= startDate &&
                             st.TransactionDate.Value <= endDate)
                .ToList();
        }

        public List<SupplierTransaction> GetSupplierTransactionsByAmountRange(decimal minAmount, decimal maxAmount)
        {
            var supplierTransactions = _supplierTransactionRepository.GetAllSupplierTransaction();
            return supplierTransactions
                .Where(st => st.TransactionAmount.HasValue &&
                             st.TransactionAmount.Value >= minAmount &&
                             st.TransactionAmount.Value <= maxAmount)
                .ToList();
        }

        public List<SupplierTransaction> GetSupplierTransactionsByPaymentMethod(string paymentMethod)
        {
            var supplierTransactions = _supplierTransactionRepository.GetAllSupplierTransaction();
            return supplierTransactions
                .Where(st => st.PaymentMethod != null &&
                             st.PaymentMethod.Equals(paymentMethod, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
