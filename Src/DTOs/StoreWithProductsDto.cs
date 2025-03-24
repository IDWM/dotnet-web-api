namespace dotnet_web_api.Src.DTOs
{
    public class StoreWithProductsDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required List<ProductDto> Products { get; set; } = [];
    }
}
