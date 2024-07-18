using DataAccessObjects.BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _productRepository.AddProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _productRepository.DeleteProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }
            return _productRepository.GetProductById(id);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _productRepository.UpdateProduct(product);
        }


        public List<Product> GetProductsBySupplier(int supplierId)
        {
            var products = _productRepository.GetAllProduct();
            return products.Where(p => p.SupplierId == supplierId).ToList();
        }

        public List<Product> GetProductsSortedByName()
        {
            var products = _productRepository.GetAllProduct();
            return products.OrderBy(p => p.ProductName).ToList();
        }

        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var products = _productRepository.GetAllProduct();
            return products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();
        }
        public List<Product> GetProductsByColor(string color)
        {
            var products = _productRepository.GetAllProduct();
            return products.Where(p => p.Color != null && p.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Product> GetProductsSortedByTaxRate()
        {
            var products = _productRepository.GetAllProduct();
            return products.OrderBy(p => p.TaxRate).ToList();
        }

        public List<Product> GetProductsSortedByTypicalWeightPerUnit()
        {
            var products = _productRepository.GetAllProduct();
            return products.OrderBy(p => p.TypicalWeightPerUnit).ToList();
        }
    }
}
