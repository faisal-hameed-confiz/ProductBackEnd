using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductBackEnd.Controllers;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;
using ProductBackEnd.Services.ProductService;
using Xunit;

namespace ProductBackendTest
{
    public class ProductControllerTest
    {
        public Mock<IProductService> mock = new Mock<IProductService>();

        [Fact]
        public async void GetProduct()
        {
            GetProductDto getProductDto = GetProductDtoObject();

            var serviceResponse = new ServiceResponse<GetProductDto>();
            serviceResponse.Success = true;
            serviceResponse.Data = getProductDto;

            mock.Setup(p => p.GetProductById(It.IsAny<int>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.GetSingleProduct(1);

            var result = actionResult.Result as OkObjectResult;

            var resultObject = (ServiceResponse<GetProductDto>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeOk, result.StatusCode);
            Assert.True(resultObject.Success);
            Assert.NotNull(resultObject.Data);
        }

        [Fact]
        public async void GetProductForInvalidId()
        {
            GetProductDto getProductDto = GetProductDtoObject();

            var serviceResponse = new ServiceResponse<GetProductDto>();
            serviceResponse.Success = false;

            mock.Setup(p => p.GetProductById(It.IsAny<int>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.GetSingleProduct(-1);

            var result = actionResult.Result as NotFoundObjectResult;

            var resultObject = (ServiceResponse<GetProductDto>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeNotFound, result.StatusCode);
            Assert.False(resultObject.Success);
            Assert.Null(resultObject.Data);
        }

        [Fact]
        public async void GetAllProducts()
        {
            var getProductDtos = new List<GetProductDto>
            {
                new GetProductDto { ProductId = 1, Name = ConstantsTest.ProductName },
            };

            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            serviceResponse.Success = true;
            serviceResponse.Data = getProductDtos;

            mock.Setup(p => p.GetAllProducts()).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.AllProducts();

            var result = actionResult.Result as OkObjectResult;

            var resultObject = (ServiceResponse<List<GetProductDto>>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeOk, result.StatusCode);
            Assert.True(resultObject.Success);
            Assert.NotEmpty(resultObject.Data);
        }

        [Fact]
        public async void UpdateProduct()
        {
            GetProductDto getProductDto = GetProductDtoObject();

            var serviceResponse = new ServiceResponse<GetProductDto>();
            serviceResponse.Success = true;
            serviceResponse.Data = getProductDto;

            mock.Setup(p => p.UpdateProduct(It.IsAny<int>(), It.IsAny<UpdateProductDto>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.UpdateProduct(1, new UpdateProductDto());

            var result = actionResult.Result as OkObjectResult;

            var resultObject = (ServiceResponse<GetProductDto>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeOk, result.StatusCode);
            Assert.True(resultObject.Success);
            Assert.NotNull(resultObject.Data);
        }

        [Fact]
        public async void UpdateProductForInvalidId()
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();
            serviceResponse.Success = false;

            mock.Setup(p => p.UpdateProduct(It.IsAny<int>(), It.IsAny<UpdateProductDto>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.UpdateProduct(-1, new UpdateProductDto());

            var result = actionResult.Result as NotFoundObjectResult;

            var resultObject = (ServiceResponse<GetProductDto>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeNotFound, result.StatusCode);
            Assert.False(resultObject.Success);
            Assert.Null(resultObject.Data);
        }

        [Fact]
        public async void AddProduct()
        {
            var getProductDtos = new List<GetProductDto>
            {
                new GetProductDto { ProductId = 1, Name = ConstantsTest.ProductName },
            };

            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            serviceResponse.Success = true;
            serviceResponse.Data = getProductDtos;

            mock.Setup(p => p.AddProduct(It.IsAny<AddProductDto>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.AddProduct(new AddProductDto());

            var result = actionResult.Result as OkObjectResult;

            var resultObject = (ServiceResponse<List<GetProductDto>>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeOk, result.StatusCode);
            Assert.True(resultObject.Success);
            Assert.NotEmpty(resultObject.Data);
        }

        [Fact]
        public async void DeleteProduct()
        {
            var getProductDtos = new List<GetProductDto>
            {
                new GetProductDto { ProductId = 1, Name = ConstantsTest.ProductName },
            };

            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            serviceResponse.Success = true;
            serviceResponse.Data = getProductDtos;

            mock.Setup(p => p.DeleteProduct(It.IsAny<int>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.DeleteProudct(1);

            var result = actionResult.Result as OkObjectResult;

            var resultObject = (ServiceResponse<List<GetProductDto>>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeOk, result.StatusCode);
            Assert.True(resultObject.Success);
            Assert.NotEmpty(resultObject.Data);
        }

        [Fact]
        public async void DeleteProductForInvalidId()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            serviceResponse.Success = false;

            mock.Setup(p => p.DeleteProduct(It.IsAny<int>())).ReturnsAsync(serviceResponse);

            ProductController productController = new ProductController(mock.Object);

            var actionResult = await productController.DeleteProudct(-1);

            var result = actionResult.Result as NotFoundObjectResult;

            var resultObject = (ServiceResponse<List<GetProductDto>>)result.Value;

            Assert.Equal(ConstantsTest.StatusCodeNotFound, result.StatusCode);
            Assert.False(resultObject.Success);
            Assert.Null(resultObject.Data);
        }

        public GetProductDto GetProductDtoObject()
        {
            GetProductDto getProductDto = new GetProductDto();
            getProductDto.ProductId = 1;
            getProductDto.Name = ConstantsTest.ProductName;
            getProductDto.Description = ConstantsTest.ProductDesc;
            getProductDto.Rating = 10;
            getProductDto.Price = 5;
            getProductDto.Image = ConstantsTest.ProductImage;
            getProductDto.Reviews = 33;

            return getProductDto;
        }
    }
}
