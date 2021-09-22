namespace ProductBackendTest
{
    public static class ConstantsTest
    {
        public const string ServiceErrorMsg = "Product doesn't exist";
        public const string UpdateProductSuccess = "Product is updated successfully";
        public const string DeleteProductSuccess = "Product is deleted successfully";

        public const string Empty = "";
        public const int DefaultValue = 0;

        public const int ProductId = 1;
        public const string ProductName = "Test Product";
        public const string ProductDesc = "Test Desc";
        public const string ProductImage = "Test Image";
        public const int ProductRating = 10;
        public const int ProductReviews = 300;
        public const int ProductPrice = 200;

        public const int StatusCodeOk = 200;
        public const int StatusCodeNotFound = 404;
    }    

    public static class ApiRoutesTest
    {
        public const string Base = "/api/products";

        public const string GetDetail = "get-detail";
        public const string GetAll = "get-all";
        public const string CreateProduct = "create-product";
        public const string UpdateProduct = "update-product";
        public const string DeleteProduct = "delete-product";
    }
}
