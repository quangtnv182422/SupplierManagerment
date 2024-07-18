using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierCategoriesRepository : ISupplierCategoriesRepository
    {
        public void AddSupplierCategories(SupplierCategory supplierCategory) => SupplierCategoriesDAO.AddSupplierCategories(supplierCategory);

        public void DeleteSupplierCategories(SupplierCategory supplierCategory) => SupplierCategoriesDAO.DeleteSupplierCategories(supplierCategory);

        public List<SupplierCategory> GetAllSupplierCategory() => SupplierCategoriesDAO.GetAllSupplierCategory();

        public SupplierCategory GetSupplierById(int id) => SupplierCategoriesDAO.GetSupplierById(id);

        public SupplierCategory GetSupplierByName(string name) => SupplierCategoriesDAO.GetSupplierByName(name);

        public void UpdateSupplierCategories(SupplierCategory supplierCategory) => SupplierCategoriesDAO.UpdateSupplierCategories(supplierCategory);

    }
}
