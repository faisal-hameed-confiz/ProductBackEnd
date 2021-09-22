using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;

namespace ProductBackEnd.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryContext _inventoryContext;

        public ProductRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;   
        }

        public async Task<List<Product>> GetAllproducts()
        {
            return await _inventoryContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int prodId)
        {
            return await _inventoryContext.Products.FirstOrDefaultAsync(p => p.ProductId == prodId);
        }

        public async Task<List<Product>> AddProduct(Product newProduct)
        {
            _inventoryContext.Products.Add(newProduct);
            await _inventoryContext.SaveChangesAsync();

            return await _inventoryContext.Products.ToListAsync();
        }

        public async Task<bool> DeleteProduct(int prodId)
        {
            try
            {
                Product product = await _inventoryContext.Products.FirstAsync(p => p.ProductId == prodId);
                _inventoryContext.Products.Remove(product);

                await _inventoryContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Logs::Update::Repository::" + ex.Message);
            }

            return false;
        }       

        public async Task<bool> UpdateProduct(int prodId, Product product)
        {
            Product dbProduct = await _inventoryContext.Products.FirstOrDefaultAsync(p => p.ProductId == prodId);

            if(dbProduct != null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.Rating = product.Rating;
                dbProduct.Price = product.Price;
                dbProduct.Image = product.Image;
                dbProduct.Reviews = product.Reviews;

                await _inventoryContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
