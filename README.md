# HotelBookingApi

A simple Hotel Room Booking REST API built with ASP.NET Core Web API and Entity Framework Core InMemory database.

## Tech Stack
- C# (.NET 8)
- ASP.NET Core Web API
- Entity Framework Core InMemory
- Swagger (if enabled)

## Features
- Get all rooms
- Get all bookings
- Create a booking
- Prevent booking if a room is unavailable
- Automatically set `IsAvailable = false` after a successful booking

## Project Structure
- `Controllers` - API endpoints
- `Models` - entity models
- `Dtos` - request models
- `Data` - DbContext and seed data

## How to Run

### 1. Clone the repository
```bash
git clone <your-github-repo-link>
cd HotelBookingApi
```

### 2. Restore packages
```bash
dotnet restore
```

### 3. Run the application
```bash
dotnet run
```

### 4. Access the API
```bash
https://localhost:<port>/swagger
```

## API Endpoints
GET /api/rooms
Returns a list of all rooms.

GET /api/bookings
Returns all bookings.

POST /api/bookings
Creates a new booking.

Example request body:
{
  "guestName": "John Doe",
  "roomId": 1,
  "checkInDate": "2025-05-01",
  "checkOutDate": "2025-05-03"
}

## Design Decisions
- Used ASP.NET Core Web API because it matches the assessment requirement and is suitable for building REST APIs.
- Used Entity Framework Core InMemory database to keep the project simple and aligned with the assessment requirement.
- Used separate folders such as Controllers, Models, Dtos, and Data to make the project easier to read and maintain.
- Added basic validation in booking creation:
    - guest name must not be empty
    - check-out date must be later than check-in date
    - room must exist
    - room must be available before booking

## Author
Dennis Chong
