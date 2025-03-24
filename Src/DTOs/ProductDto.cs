namespace dotnet_web_api.Src.DTOs
{
    public class ProductDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required int StoreId { get; set; }
        public required string StoreName { get; set; }
    }
}
