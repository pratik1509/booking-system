using System.ComponentModel.DataAnnotations;
using BuildingBlocks.RepositorySpecification.Entity;

namespace Hotel.API.Infrastructure.Entities
{
    public class Hotel : BaseEntity
    {
        [Required, MaxLength(255)]
        public required string Name { get; set; }

        [Required, MaxLength(500)]
        public required string Description { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public int StarRating { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public List<Room> Rooms { get; set; } = [];
    }
}