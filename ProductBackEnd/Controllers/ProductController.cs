using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;
using ProductBackEnd.Services.ProductService;

namespace ProductBackEnd.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route(ApiRoutes.GetDetail)]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetSingleProduct([FromQuery(Name = "productId")] int prodId)
        {
            var serviceResponse = await _productService.GetProductById(prodId);

            if(serviceResponse.Data == null) {
                return NotFound(serviceResponse);
            }
            
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route(ApiRoutes.GetAll)]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost]
        [Route(ApiRoutes.CreateProduct)]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddProduct(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpPut]
        [Route(ApiRoutes.UpdateProduct)]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct([FromQuery(Name = "productId")] int prodId, UpdateProductDto updateProduct) {

            var serviceResponse = await _productService.UpdateProduct(prodId, updateProduct);

            if(serviceResponse.Data == null) {
                return NotFound(serviceResponse);
            }
            
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route(ApiRoutes.DeleteProduct)]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> DeleteProudct([FromQuery(Name = "productId")] int prodId) {

            var serviceResponse = await _productService.DeleteProduct(prodId);
            
            if(serviceResponse.Data == null) {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route(ApiRoutes.GetStatus)]
        public ActionResult<string> GetStatus()
        {
            return Ok("Site is up and running");
        }
    }
}