using System.ComponentModel.DataAnnotations;

namespace dotnet_web_api.Src.Models
{
    public class Store
    {
        // Properties
        [Required]
        [Key]
        public required int Id { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string Address { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        // Navigation Properties
        public List<Product> Products { get; set; } = [];
    }
}
