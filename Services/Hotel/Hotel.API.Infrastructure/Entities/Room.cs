using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hotel.API.Infrastructure.Entities
{
    public class Room
    {
        [Required]
        public int HotelId { get; set; } // Foreign Key
        public required Hotel Hotel { get; set; }

        [Required]
        public required string RoomType { get; set; } // e.g. Deluxe, Suite, Standard

        public required string Description { get; set; }

        [Required]
        public decimal PricePerNight { get; set; } // Example: 99.99

        public int Capacity { get; set; } // Number of guests the room can accommodate

        public bool IsAvailable { get; set; } = true; // Available for booking?
    }
}