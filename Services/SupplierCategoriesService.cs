using DataAccessObjects.BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SupplierCategoriesService : ISupplierCategoriesService
    {
        private readonly ISupplierCategoriesRepository _supplierCategoriesRepository;

        public SupplierCategoriesService(ISupplierCategoriesRepository supplierCategoriesRepository)
        {
            _supplierCategoriesRepository = supplierCategoriesRepository;
        }

        public void AddSupplierCategory(SupplierCategory supplierCategory)
        {
            if (supplierCategory == null)
            {
                throw new ArgumentNullException(nameof(supplierCategory));
            }
            _supplierCategoriesRepository.AddSupplierCategories(supplierCategory);
        }

        public void DeleteSupplierCategory(SupplierCategory supplierCategory)
        {
            if (supplierCategory == null)
            {
                throw new ArgumentNullException(nameof(supplierCategory));
            }
            _supplierCategoriesRepository.DeleteSupplierCategories(supplierCategory);
        }

        public List<SupplierCategory> GetAllSupplierCategories()
        {
            return _supplierCategoriesRepository.GetAllSupplierCategory();
        }

        public SupplierCategory GetSupplierCategoryById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid supplier category ID", nameof(id));
            }
            return _supplierCategoriesRepository.GetSupplierById(id);
        }

        public SupplierCategory GetSupplierCategoryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            return _supplierCategoriesRepository.GetSupplierByName(name);
        }

        public void UpdateSupplierCategory(SupplierCategory supplierCategory)
        {
            if (supplierCategory == null)
            {
                throw new ArgumentNullException(nameof(supplierCategory));
            }
            _supplierCategoriesRepository.UpdateSupplierCategories(supplierCategory);
        }
    }
}