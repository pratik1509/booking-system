using BuildingBlocks.RepositorySpecification.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Infrastructure.Data
{
    public class HotelRepository(IGenericRepository<Entities.Hotel> genericRepository) : IHotelRepository
    {
        public void AddHotel(Entities.Hotel hotel)
        {
            genericRepository.Add(hotel);
            genericRepository.SaveAllAsync();
        }

        public void DeleteHotel(Entities.Hotel hotel)
        {
            genericRepository.Remove(hotel);
            genericRepository.SaveAllAsync();
        }

        public async Task<IReadOnlyList<Entities.Hotel>> GetHotelAsync(string? name, string? country, string? city)
        {

            return null;
            // var query = genericRepository.AsQueryable();

            // if (!string.IsNullOrWhiteSpace(name))
            //     query = query.Where(x => x.Name == name);

            // if (!string.IsNullOrWhiteSpace(country))
            //     query = query.Where(x => x.Country == country);

            // if (!string.IsNullOrWhiteSpace(city))
            //     query = query.Where(x => x.City == city);

            // return await query.ToListAsync();
        }

        public async Task<Entities.Hotel?> GetHotelByIdAsync(int id)
        {
            return null;
            //   return await context.Hotels.FindAsync(id);
        }

        public bool HotelExist(int id)
        {
            return false;
            //return context.Hotels.Any(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return false;
            //return await context.SaveChangesAsync() > 0;
        }

        public void UpdateHotel(Entities.Hotel hotel)
        {
            //context.Entry(hotel).State = EntityState.Modified;
        }
    }
}