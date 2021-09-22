using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProductBackEnd.Data.Repository;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;

namespace ProductBackEnd.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;       
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;            
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            Product product = _mapper.Map<Product>(newProduct);

            List<Product> dbProducts = await _productRepository.AddProduct(product);

            serviceResponse.Data = _mapper.Map<List<GetProductDto>>(dbProducts);            

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            List<Product> dbProducts = await _productRepository.GetAllproducts();

            serviceResponse.Data = _mapper.Map<List<GetProductDto>>(dbProducts);          

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int prodId)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();

            var dbProduct = await _productRepository.GetProductById(prodId);          

            if(dbProduct == null) {
                serviceResponse.message = Constants.ServiceErrorMsg;
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

            Product product = _mapper.Map<Product>(updateProduct);            
            product.ProductId = prodId;

            try
            {
                bool isProductUpdated = await _productRepository.UpdateProduct(prodId, product);

                if (!isProductUpdated)
                {
                    serviceResponse.message = Constants.ServiceErrorMsg;
                    serviceResponse.Success = false;
                }
                else
                {
                    serviceResponse.Data = _mapper.Map<GetProductDto>(product);
                    serviceResponse.message = Constants.UpdateProductSuccess;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Logs::Update::Service::" + ex.Message);
                serviceResponse.message = Constants.ServiceErrorMsg;
                serviceResponse.Success = false;
            }

            return serviceResponse;            
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int prodId)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            try
            {
                bool isProductDeleted = await _productRepository.DeleteProduct(prodId);

                if (isProductDeleted)
                {
                    List<Product> dbProducts = await _productRepository.GetAllproducts();

                    serviceResponse.Data = _mapper.Map<List<GetProductDto>>(dbProducts);
                    serviceResponse.message = Constants.DeleteProductSuccess;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.message = Constants.ServiceErrorMsg;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Logs::Delete::Service::" + ex.Message);
                serviceResponse.Success = false;
                serviceResponse.message = Constants.ServiceErrorMsg;
            }

            return serviceResponse;
        }
    }
}