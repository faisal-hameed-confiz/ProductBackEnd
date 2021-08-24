using System.Collections.Generic;
using System.Linq;
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
        [Route("get-detail")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetSingleProduct([FromQuery(Name = "prodId")] int prodId)
        {
            var serviceResponse = await _productService.GetProductById(prodId);

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

        [HttpPut]
        [Route("update-product")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct([FromQuery(Name = "prodId")] int prodId, UpdateProductDto updateProduct) {

            var serviceResponse = await _productService.UpdateProduct(prodId, updateProduct);

            if(serviceResponse.Data == null) {
                return NotFound(serviceResponse);
            }
            
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("delete-product")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> DeleteProudct([FromQuery(Name = "prodId")] int prodId) {

            var serviceResponse = await _productService.DeleteProduct(prodId);
            
            if(serviceResponse.Data == null) {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);
        }
    }
}