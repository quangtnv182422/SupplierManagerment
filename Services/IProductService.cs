using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        public List<Product> GetProductsBySupplier(int supplierId);
        public List<Product> GetProductsSortedByName();
        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
        public List<Product> GetProductsByColor(string color);
        public List<Product> GetProductsSortedByTaxRate();
        public List<Product> GetProductsSortedByTypicalWeightPerUnit();
    }
}
