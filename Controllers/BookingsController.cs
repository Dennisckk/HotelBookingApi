using HotelBookingApi.Data;
using HotelBookingApi.Dtos;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto request)
        {
            // Check guest name
            if (string.IsNullOrWhiteSpace(request.GuestName))
            {
                return BadRequest("Guest name is required.");
            }

            // Check dates
            if (request.CheckInDate >= request.CheckOutDate)
            {
                return BadRequest("Check-out date must be later than check-in date.");
            }

            // Find room
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == request.RoomId);

            // Check if room exists
            if (room == null)
            {
                return NotFound("Room not found.");
            }

            // Check if room is available
            if (!room.IsAvailable)
            {
                return BadRequest("Room is not available.");
            }

            // Create booking object
            var booking = new Booking
            {
                GuestName = request.GuestName,
                RoomId = request.RoomId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate
            };

            // Save booking and update room status
            _context.Bookings.Add(booking);

            room.IsAvailable = false;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Booking created successfully.",
                booking
            });
        }
    }
}