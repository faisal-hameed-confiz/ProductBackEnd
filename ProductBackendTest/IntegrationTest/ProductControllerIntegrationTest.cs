using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;
using Xunit;

namespace ProductBackendTest.IntegrationTest
{
    public class ProductControllerIntegrationTest : IntegrationTest
    {
        [Fact]
        public async Task GetAllProducts()
        {
            var route = ApiRoutesTest.Base;

            var response = await _client.GetAsync(requestUri: route);
            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<List<GetProductDto>>>(responseProducts);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(serviceResponse.Data);            
        }

        [Fact]
        public async Task CreateProduct()
        {
            var route = ApiRoutesTest.Base;

            var response = await _client.GetAsync(requestUri: route);
            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<List<GetProductDto>>>(responseProducts);

            int numberOfProducts = serviceResponse.Data.Count;

            var routeCreate = ApiRoutesTest.Base;
            var routeGetAll = ApiRoutesTest.Base;

            var res = await _client.PostAsJsonAsync(requestUri: routeCreate, new AddProductDto
            {
                Name = ConstantsTest.Empty,
                Description = ConstantsTest.Empty,
                Image = ConstantsTest.Empty,
                Price = ConstantsTest.DefaultValue,
                Rating = ConstantsTest.DefaultValue,
                Reviews = ConstantsTest.DefaultValue
            });

            response = await _client.GetAsync(requestUri: routeGetAll);
            responseProducts = await response.Content.ReadAsStringAsync();

            serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<List<GetProductDto>>>(responseProducts);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(numberOfProducts+1, serviceResponse.Data.Count);
        }

        [Fact]
        public async Task GetProductById()
        {
            var routeGetById = ApiRoutesTest.Base + "1";

            var response = await _client.GetAsync(requestUri: routeGetById);            
            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<GetProductDto>>(responseProducts);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(serviceResponse.Success);
            Assert.Equal(ConstantsTest.ProductId, serviceResponse.Data.ProductId);
            Assert.Equal(ConstantsTest.ProductName, serviceResponse.Data.Name);
            Assert.Equal(ConstantsTest.ProductDesc, serviceResponse.Data.Description);
            Assert.Equal(ConstantsTest.ProductPrice, serviceResponse.Data.Price);
        }

        [Fact]
        public async Task GetProductForInvalidId()
        {
            var routeGetById = ApiRoutesTest.Base + "-1";

            var response = await _client.GetAsync(requestUri: routeGetById);
            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<GetProductDto>>(responseProducts);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.False(serviceResponse.Success);
        }

        [Fact]
        public async Task UpdateProduct()
        {
            var routeUpdateProduct = ApiRoutesTest.Base + "2";

            var response = await _client.PutAsJsonAsync(requestUri: routeUpdateProduct, new UpdateProductDto
            {
                Name = "Update Product",
                Description = "Update Description",
                Image = "Update Image",
                Price = 1,
                Rating = 2,
                Reviews = 3
            });

            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<GetProductDto>>(responseProducts);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(serviceResponse.Success);            
            Assert.Equal("Update Product", serviceResponse.Data.Name);
            Assert.Equal("Update Description", serviceResponse.Data.Description);
            Assert.Equal("Update Image", serviceResponse.Data.Image);
            Assert.Equal(1, serviceResponse.Data.Price);
            Assert.Equal(2, serviceResponse.Data.Rating);
            Assert.Equal(3, serviceResponse.Data.Reviews);
            Assert.Equal(ConstantsTest.UpdateProductSuccess, serviceResponse.message);
        }

        [Fact]
        public async Task UpdateProduct_ThatDoesnotExist()
        {
            var routeUpdateProduct = ApiRoutesTest.Base + "-1";

            var response = await _client.PutAsJsonAsync(requestUri: routeUpdateProduct, new UpdateProductDto());

            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<GetProductDto>>(responseProducts);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.False(serviceResponse.Success);
            Assert.Equal(ConstantsTest.ServiceErrorMsg, serviceResponse.message);
        }

        [Fact]
        public async Task DeleteProduct()
        {
            var route = ApiRoutesTest.Base;

            var response = await _client.GetAsync(requestUri: route);
            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<List<GetProductDto>>>(responseProducts);

            int numberOfProducts = serviceResponse.Data.Count;

            var routeDeleteProduct = ApiRoutesTest.Base + "3";

            response = await _client.DeleteAsync(requestUri: routeDeleteProduct);

            responseProducts = await response.Content.ReadAsStringAsync();

            serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<List<GetProductDto>>>(responseProducts);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(numberOfProducts-1, serviceResponse.Data.Count);
            Assert.True(serviceResponse.Success);
            Assert.Equal(ConstantsTest.DeleteProductSuccess, serviceResponse.message);
        }

        [Fact]
        public async Task DeleteProduct_ThatDoesnotExist()
        {
            var routeDeleteProduct = ApiRoutesTest.Base + "-1";

            var response = await _client.DeleteAsync(requestUri: routeDeleteProduct);

            var responseProducts = await response.Content.ReadAsStringAsync();

            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<GetProductDto>>(responseProducts);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.False(serviceResponse.Success);
            Assert.Equal(ConstantsTest.ServiceErrorMsg, serviceResponse.message);
        }
    }
}
