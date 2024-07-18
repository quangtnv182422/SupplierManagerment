using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class SupplierDAO
    {

        public static List<Supplier> GetAllSupplier()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.Suppliers.ToList();
        }


        public static void AddSupplier(Supplier supplier)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            else
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
        }

        public static void DeleteSupplier(Supplier supplier)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            else
            {
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
            }
        }

        public static void UpdateSupplier(Supplier supplier)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }
            else
            {
                context.Suppliers.Update(supplier);
                context.SaveChanges();
            }
        }

        public static Supplier GetSupplierById(int id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var supplier = (from s in context.Suppliers
                            where s.SupplierId == id
                            select s).FirstOrDefault();
            return supplier;
        }
    }
}
