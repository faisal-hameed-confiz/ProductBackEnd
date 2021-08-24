using System.Collections.Generic;
using System.Threading.Tasks;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;

namespace ProductBackEnd.Services.ProductService
{
    public interface IProductService
    {
         Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();

         Task<ServiceResponse<GetProductDto>> GetProductById(int prodId);

         Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct);

         Task<ServiceResponse<GetProductDto>> UpdateProduct(int prodId, UpdateProductDto updateProduct);

         Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int prodId);
    }
}