using BuildingBlocks.RepositorySpecification.Entity;

namespace Hotel.API.Infrastructure.Entities
{
    public class Hotel : BaseEntity
    {
        public required string Name { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
    }
}