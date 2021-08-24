using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductBackEnd.Data;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;

namespace ProductBackEnd.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly InventoryContext _inventoryContext;

        public ProductService(IMapper mapper, InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            Product product = _mapper.Map<Product>(newProduct);
            _inventoryContext.Products.Add(product);
            await _inventoryContext.SaveChangesAsync();
            serviceResponse.Data = await _inventoryContext.Products.Select(p => _mapper.Map<GetProductDto>(p)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            var dbProducts = await _inventoryContext.Products.ToListAsync();

            serviceResponse.Data = dbProducts.Select(p => _mapper.Map<GetProductDto>(p)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int prodId)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();
            
            var dbProduct = await _inventoryContext.Products.FirstOrDefaultAsync(p => p.ProductId == prodId);

            if(dbProduct == null) {
                serviceResponse.message = "Product dooesn't exist";
                serviceResponse.Success = false;
            }
            else {
                serviceResponse.Data = _mapper.Map<GetProductDto>(dbProduct);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(int prodId, UpdateProductDto updateProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();

            try
            {

                Product product = await _inventoryContext.Products.FirstAsync(p => p.ProductId == prodId);

                product.Name = updateProduct.Name;
                product.Description = updateProduct.Description;
                product.Rating = updateProduct.Rating;
                product.Price = updateProduct.Price;
                product.Image = updateProduct.Image;
                product.Reviews = updateProduct.Reviews;

                await _inventoryContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetProductDto>(product);

            }
            catch (Exception ex)
            {
                serviceResponse.message = "Product dooesn't exist";
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int prodId)
        {

            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            try
            {
                Product product = await _inventoryContext.Products.FirstAsync(p => p.ProductId == prodId);
                _inventoryContext.Products.Remove(product);

                await _inventoryContext.SaveChangesAsync();

                serviceResponse.Data = await _inventoryContext.Products.Select(p => _mapper.Map<GetProductDto>(p)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.message = "Product doesn't exist";
            }

            return serviceResponse;
        }
    }
}