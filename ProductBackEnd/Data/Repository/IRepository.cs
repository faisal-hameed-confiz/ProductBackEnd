using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;

namespace ProductBackEnd.Data.Repository
{
    public interface IRepository
    {
        Task<List<Product>> GetAllproducts();
        Task<Product> GetProductById(int prodId);
        Task<List<Product>> AddProduct(Product newProduct);
        Task<bool> UpdateProduct(int prodId, Product product);
        Task<bool> DeleteProduct(int prodId);        
    }
}
