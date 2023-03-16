using DataAccess.Abstract;
using Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    
    public class InMemoryProductDal : IProductDal 
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            new Product { ProductId = 1, CategoryId = 1, ProductName = "Döner Sandalye", UnitsInStock = 26, UnitPrice = 25, };
            new Product { ProductId = 2, CategoryId = 2, ProductName = "Sofra", UnitsInStock = 15, UnitPrice = 43, };
            new Product { ProductId = 3, CategoryId = 2, ProductName = "Komidin", UnitsInStock = 325, UnitPrice = 21, };
            new Product { ProductId = 4, CategoryId = 1, ProductName = "Vazo", UnitsInStock = 145, UnitPrice = 140, };
        }




        public void Add(Product product)
        {
            _products.Add(product);

        }

        public void Delete(Product product)
        {
          
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
           return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
