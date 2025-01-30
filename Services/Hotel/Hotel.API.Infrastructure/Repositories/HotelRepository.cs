using BuildingBlocks.RepositorySpecification.Repository;
using Hotel.API.Infrastructure.Data;
using Hotel.API.Infrastructure.Specifications;

namespace Hotel.API.Infrastructure.Repositories
{
    public class HotelRepository : GenericRepository<Entities.Hotel>, IHotelRepository
    {
        private readonly StoreContext _dbContext;

        public HotelRepository(StoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entities.Hotel>? GetByIdAsync(int hotelId)
        {
            return await GetByIdAsync(hotelId);
        }

        public async Task<Entities.Hotel> AddAsync(Entities.Hotel hotel)
        {
            base.Add(hotel);
            await SaveAllAsync();
            return hotel;
        }

        public async Task<Entities.Hotel> UpdateAsync(int hotelId, Entities.Hotel hotel)
        {
            var existingHotel = await GetByIdAsync(hotelId);
            if (existingHotel == null)
                return null;

            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.City = hotel.City;
            existingHotel.Country = hotel.Country;
            existingHotel.StarRating = hotel.StarRating;

            base.Update(existingHotel);
            await SaveAllAsync();
            return existingHotel;
        }

        public async Task<bool> DeleteAsync(int hotelId)
        {
            var hotel = await GetByIdAsync(hotelId);
            if (hotel == null)
                return false;

            base.Remove(hotel);
            await SaveAllAsync();
            return true;
        }

        public async Task<IEnumerable<Entities.Hotel>> GetHotelsAsync(HotelSpecificationParams parameters)
        {
            var specification = new HotelSearchSpecification(parameters);
            return await GetEntityListWithSpecAsync(specification);
        }
    }
}