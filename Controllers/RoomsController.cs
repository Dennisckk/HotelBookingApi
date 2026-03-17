using HotelBookingApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // automatically gives your controller the AppDbContext
        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // reads all rooms from database and returns them
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return Ok(rooms);
        }
    }
}