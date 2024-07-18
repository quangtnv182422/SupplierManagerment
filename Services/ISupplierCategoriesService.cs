using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISupplierCategoriesService
    {
        void AddSupplierCategory(SupplierCategory supplierCategory);
        void DeleteSupplierCategory(SupplierCategory supplierCategory);
        List<SupplierCategory> GetAllSupplierCategories();
        SupplierCategory GetSupplierCategoryById(int id);
        SupplierCategory GetSupplierCategoryByName(string name);
        void UpdateSupplierCategory(SupplierCategory supplierCategory);
    }
}
