namespace dotnet_web_api.Src.DTOs
{
    public class StoreDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required int ProductCount { get; set; }
    }
}
