using HotelBookingApi.Models;

namespace HotelBookingApi.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // check if rooms already exist
            if (context.Rooms.Any())
                return;

            // if no, insert sample rooms
            context.Rooms.AddRange(
                new Room { Id = 1, Name = "101", Type = "Single", IsAvailable = true },
                new Room { Id = 2, Name = "102", Type = "Double", IsAvailable = true },
                new Room { Id = 3, Name = "103", Type = "Suite", IsAvailable = true },
                new Room { Id = 4, Name = "201", Type = "Single", IsAvailable = true },
                new Room { Id = 5, Name = "202", Type = "Double", IsAvailable = true }
            );

            context.SaveChanges();
        }
    }
}