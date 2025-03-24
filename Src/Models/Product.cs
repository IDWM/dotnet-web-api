using System.ComponentModel.DataAnnotations;

namespace dotnet_web_api.Src.Models
{
    public class Product
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
        public required string Description { get; set; }

        [Required]
        [Range(0, 100000)]
        public required float Price { get; set; }

        // Navigation Properties
        public required int StoreId { get; set; }
        public required Store Store { get; set; }
    }
}
