using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Infrastructure.Persistence;

public class FlightRepository : IFlightRepository
{
    private static readonly List<Flight> _flights = new()
    {
        new Flight { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), FlightNumber = "AB123", Origin = "New York", Destination = "London", DepartureDate = DateTime.Now.AddDays(7), ArrivalDate = DateTime.Now.AddDays(7).AddHours(8), Price = 450.00m, AvailableSeats = 50 },
        new Flight { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), FlightNumber = "CD456", Origin = "Paris", Destination = "Berlin", DepartureDate = DateTime.Now.AddDays(5), ArrivalDate = DateTime.Now.AddDays(5).AddHours(2), Price = 180.00m, AvailableSeats = 30 },
        new Flight { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), FlightNumber = "EF789", Origin = "Los Angeles", Destination = "Tokyo", DepartureDate = DateTime.Now.AddDays(10), ArrivalDate = DateTime.Now.AddDays(10).AddHours(12), Price = 850.00m, AvailableSeats = 20 }
    };

    public async Task<IEnumerable<Flight>> SearchFlightsAsync(string destination, DateTime date)
    {
        await Task.Delay(100);
        return _flights.Where(f => f.Destination.ToLower().Contains(destination.ToLower()) && f.DepartureDate.Date == date.Date);
    }

    public async Task<Flight?> GetByIdAsync(Guid id)
    {
        await Task.Delay(50);
        return _flights.FirstOrDefault(f => f.Id == id);
    }
}
