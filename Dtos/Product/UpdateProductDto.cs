namespace ProductBackEnd.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Rating { get; set; } = 0;
        public int Price { get; set; } = 0;
        public string Image { get; set; } = "";
        public int Reviews { get; set; } = 0;
    }
}