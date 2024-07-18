using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISupplierCategoriesRepository
    {
        List<SupplierCategory> GetAllSupplierCategory();
        void AddSupplierCategories(SupplierCategory supplierCategory);
        void DeleteSupplierCategories(SupplierCategory supplierCategory);
        void UpdateSupplierCategories(SupplierCategory supplierCategory);
        SupplierCategory GetSupplierById(int id);
        SupplierCategory GetSupplierByName(string name);
    }
}
