namespace Hotel.API.Infrastructure.Data
{
    public interface IHotelRepository
    {
        Task<IReadOnlyList<Entities.Hotel>> GetHotelAsync(string? name, string? country, string? city);
        Task<Entities.Hotel?> GetHotelByIdAsync(int id);
        void AddHotel(Entities.Hotel hotel);
        void UpdateHotel(Entities.Hotel hotel);
        void DeleteHotel(Entities.Hotel hotel);
        bool HotelExist(int id);
        Task<bool> SaveChangesAsync();
    }
}