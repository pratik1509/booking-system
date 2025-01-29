using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Infrastructure.Data
{
    public class HotelRepository(StoreContext context) : IHotelRepository
    {
        public void AddHotel(Entities.Hotel hotel)
        {
            context.Hotels.Add(hotel);
        }

        public void DeleteHotel(Entities.Hotel hotel)
        {
            context.Hotels.Remove(hotel);
        }

        public async Task<IReadOnlyList<Entities.Hotel>> GetHotelAsync(string? name, string? country, string? city)
        {
            var query = context.Hotels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name == name);

            if (!string.IsNullOrWhiteSpace(country))
                query = query.Where(x => x.Country == country);

            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(x => x.City == city);

            return await query.ToListAsync();
        }

        public async Task<Entities.Hotel?> GetHotelByIdAsync(int id)
        {
            return await context.Hotels.FindAsync(id);
        }

        public bool HotelExist(int id)
        {
            return context.Hotels.Any(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateHotel(Entities.Hotel hotel)
        {
            context.Entry(hotel).State = EntityState.Modified;
        }
    }
}