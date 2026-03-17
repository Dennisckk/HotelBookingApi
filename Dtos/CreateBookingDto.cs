namespace HotelBookingApi.Dtos
{
    // creates a booking
    public class CreateBookingDto
    {
        public string GuestName { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}