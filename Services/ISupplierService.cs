using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISupplierService
    {
        void AddSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int id);
        void UpdateSupplier(Supplier supplier);
        List<Supplier> GetSuppliersByCategory(int categoryId);
        List<Supplier> GetSuppliersByCity(string city);
        List<Supplier> GetSuppliersByPaymentDays(int paymentDays);
    }
}
