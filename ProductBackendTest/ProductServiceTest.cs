using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductBackEnd;
using ProductBackEnd.Data.Repository;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;
using ProductBackEnd.Services.ProductService;
using Xunit;

namespace ProductBackendTest
{
    public class ProductServiceTest
    {
        private IMapper mapper;
        public Mock<IProductRepository> mock = new Mock<IProductRepository>();

        public ProductServiceTest()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }).CreateMapper();
        }

        [Fact]
        public async void GetAllProducts()
        {
            var dbProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = ConstantsTest.ProductName },
                new Product { ProductId = 2, Name = ConstantsTest.ProductName },
                new Product { ProductId = 3, Name = ConstantsTest.ProductName },
            };

            mock.Setup(p => p.GetAllproducts()).ReturnsAsync(dbProducts);

            ProductService productService = new ProductService(mapper, mock.Object);

            var result = await productService.GetAllProducts();

            Assert.True(dbProducts.Count.Equals(result.Data.Count));
        }

        [Fact]
        public async void AddProduct()
        {
            var dbProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = ConstantsTest.ProductName },
                new Product { ProductId = 2, Name = ConstantsTest.ProductName, Description = ConstantsTest.ProductDesc, Rating = 10,
                    Price = 5, Image = ConstantsTest.ProductImage, Reviews = 33 },
            };

            AddProductDto addProductDto = GetAddProductDto();          

            mock.Setup(p => p.AddProduct(It.IsAny<Product>())).ReturnsAsync(dbProducts);

            ProductService productService = new ProductService(mapper, mock.Object);

            var result = await productService.AddProduct(addProductDto);

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async void GetProductById()
        {
            Product product = new Product();
            product.Name = ConstantsTest.ProductName;
            mock.Setup(p => p.GetProductById(1)).ReturnsAsync(product);

            ProductService productService = new ProductService(mapper, mock.Object);

            var result = await productService.GetProductById(1);

            Assert.True(result.Data.Name.Equals(product.Name));
        }

        [Fact]
        public async void GetProductByInvalidId()
        {
            Product product = null;

            mock.Setup(p => p.GetProductById(-1)).ReturnsAsync(product);

            ProductService productService = new ProductService(mapper, mock.Object);

            var result = await productService.GetProductById(-1);

            Assert.False(result.Success);
        }

        [Fact]
        public async void UpdateProduct()
        {
            mock.Setup(p => p.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>())).ReturnsAsync(true);

            ProductService productService = new ProductService(mapper, mock.Object);

            UpdateProductDto updateProductDto = GetUpdateProductDto();

            var result = await productService.UpdateProduct(1, updateProductDto);

            GetProductDto getProductDto = result.Data;

            Assert.Equal(getProductDto.Name, updateProductDto.Name);
            Assert.Equal(getProductDto.Description, updateProductDto.Description);
            Assert.Equal(getProductDto.Rating, updateProductDto.Rating);
            Assert.Equal(getProductDto.Price, updateProductDto.Price);
            Assert.Equal(getProductDto.Image, updateProductDto.Image);
            Assert.Equal(getProductDto.Reviews, updateProductDto.Reviews);

            Assert.True(result.Success);
            Assert.Equal(ConstantsTest.UpdateProductSuccess, result.message);
        }

        [Fact]
        public async void UpdateProductWithInvalidId()
        {
            mock.Setup(p => p.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>())).ReturnsAsync(false);

            ProductService productService = new ProductService(mapper, mock.Object);

            UpdateProductDto updateProductDto = GetUpdateProductDto();

            var result = await productService.UpdateProduct(-1, updateProductDto);

            Assert.False(result.Success);
            Assert.Equal(ConstantsTest.ServiceErrorMsg, result.message);
        }

        [Fact]
        public async void DeleteProduct()
        {
            var dbProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = ConstantsTest.ProductName },
                new Product { ProductId = 2, Name = ConstantsTest.ProductName, Description = ConstantsTest.ProductDesc, Rating = 10,
                    Price = 5, Image = ConstantsTest.ProductImage, Reviews = 33 },
            };

            mock.Setup(p => p.DeleteProduct(It.IsAny<int>())).ReturnsAsync(true);
            mock.Setup(p => p.GetAllproducts()).ReturnsAsync(dbProducts);

            ProductService productService = new ProductService(mapper, mock.Object);

            var result = await productService.DeleteProduct(1);

            Assert.True(result.Success);
            Assert.Equal(ConstantsTest.DeleteProductSuccess, result.message);
        }

        [Fact]
        public async void DeleteProductInvalidId()
        {
            mock.Setup(p => p.DeleteProduct(It.IsAny<int>())).ReturnsAsync(false);            

            ProductService productService = new ProductService(mapper, mock.Object);

            var result = await productService.DeleteProduct(-1);

            Assert.False(result.Success);
            Assert.Equal(ConstantsTest.ServiceErrorMsg, result.message);
        }

        public UpdateProductDto GetUpdateProductDto()
        {
            UpdateProductDto updateProductDto = new UpdateProductDto();
            updateProductDto.Name = ConstantsTest.ProductName;
            updateProductDto.Description = ConstantsTest.ProductDesc;
            updateProductDto.Rating = 10;
            updateProductDto.Price = 5;
            updateProductDto.Image = ConstantsTest.ProductImage;
            updateProductDto.Reviews = 33;

            return updateProductDto;
        }

        public AddProductDto GetAddProductDto()
        {
            AddProductDto addProductDto = new AddProductDto();
            addProductDto.Name = ConstantsTest.ProductName;
            addProductDto.Description = ConstantsTest.ProductDesc;
            addProductDto.Rating = 10;
            addProductDto.Price = 5;
            addProductDto.Image = ConstantsTest.ProductImage;
            addProductDto.Reviews = 33;

            return addProductDto;
        }
    }
}
