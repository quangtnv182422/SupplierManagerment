using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.AddProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);

        public List<Product> GetAllProduct() => ProductDAO.GetAllProduct();

        public Product GetProductById(int id) => ProductDAO.GetProductById(id);

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);

    }
}
