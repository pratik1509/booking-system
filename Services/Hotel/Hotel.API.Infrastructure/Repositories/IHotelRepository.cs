using Hotel.API.Infrastructure.Specifications;

namespace Hotel.API.Infrastructure.Repositories
{
    public interface IHotelRepository
    {
        Task<Entities.Hotel> AddAsync(Entities.Hotel hotel);
        Task<Entities.Hotel>? GetByIdAsync(int hotelId);
        Task<Entities.Hotel> UpdateAsync(int hotelId, Entities.Hotel hotel);
        Task<bool> DeleteAsync(int hotelId);
        Task<IEnumerable<Entities.Hotel>> GetHotelsAsync(HotelSpecificationParams parameters);
    }
}