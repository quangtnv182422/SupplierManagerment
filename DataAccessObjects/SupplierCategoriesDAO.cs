using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{

    public class SupplierCategoriesDAO
    {

        public static List<SupplierCategory> GetAllSupplierCategory()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.SupplierCategories.ToList();
        }

        public static SupplierCategory GetSupplierById(int id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var supplier = (from s in context.SupplierCategories
                            where s.SupplierCategoryId == id
                            select s).FirstOrDefault();
            return supplier;
        }
        public static SupplierCategory GetSupplierByName(string name)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var supplier = (from s in context.SupplierCategories
                            where s.SupplierCategoryName == name
                            select s).FirstOrDefault();
            return supplier;
        }

        public static void AddSupplierCategories(SupplierCategory supplier)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                context.SupplierCategories.Add(supplier);
                context.SaveChanges();
            }
        }
        public static void DeleteSupplierCategories(SupplierCategory supplier)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                context.SupplierCategories.Remove(supplier);
                context.SaveChanges();
            }
        }
        public static void UpdateSupplierCategories(SupplierCategory supplier)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                context.SupplierCategories.Update(supplier);
                context.SaveChanges();
            }
        }

    }
}
