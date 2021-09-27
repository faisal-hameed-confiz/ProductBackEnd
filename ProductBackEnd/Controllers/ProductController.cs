using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;
using ProductBackEnd.Services.ProductService;

namespace ProductBackEnd.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId}")]        
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetSingleProduct(int productId)
        {
            var serviceResponse = await _productService.GetProductById(productId);

            if(serviceResponse.Data == null) {
                return NotFound(serviceResponse);
            }
            
            return Ok(serviceResponse);
        }

        [HttpGet]        
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost]        
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddProduct(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct(int productId, UpdateProductDto updateProduct)
        {

            var serviceResponse = await _productService.UpdateProduct(productId, updateProduct);

            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);
        }

        [HttpDelete("{productId}")]        
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> DeleteProudct(int productId)
        {

            var serviceResponse = await _productService.DeleteProduct(productId);

            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);
        }
    }
}