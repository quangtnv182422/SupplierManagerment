using DataAccessObjects.BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{

    public class ProductDAO
    {
        public static List<Product> GetAllProduct()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.Products.ToList();
        }
        public static void AddProduct(Product product)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void DeleteProduct(Product product)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }

        public static Product GetProductById(int id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var product = (from p in context.Products
                           where p.ProductId == id
                           select p).FirstOrDefault();
            return product;
        }
    }
}
