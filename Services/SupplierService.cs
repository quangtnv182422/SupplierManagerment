using DataAccessObjects.BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            _supplierRepository.AddSupplier(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            _supplierRepository.DeleteSupplier(supplier);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSupplier();
        }

        public Supplier GetSupplierById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid supplier ID", nameof(id));
            }
            return _supplierRepository.GetSupplierById(id);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            _supplierRepository.UpdateSupplier(supplier);
        }


        public List<Supplier> GetSuppliersByCategory(int categoryId)
        {
            var suppliers = _supplierRepository.GetAllSupplier();
            return suppliers.Where(s => s.SupplierCategoryId == categoryId).ToList();
        }

        public List<Supplier> GetSuppliersByCity(string city)
        {
            var suppliers = _supplierRepository.GetAllSupplier();
            return suppliers.Where(s => s.DeliveryCity != null && s.DeliveryCity.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Supplier> GetSuppliersByPaymentDays(int paymentDays)
        {
            var suppliers = _supplierRepository.GetAllSupplier();
            return suppliers.Where(s => s.PaymentDays == paymentDays).ToList();
        }
    }
}
