using FlightReservation.Domain.Entities;

namespace FlightReservation.Domain.Interfaces;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> SearchFlightsAsync(string destination, DateTime date);
    Task<Flight?> GetByIdAsync(Guid id);
    Task<bool> TryReserveSeatAsync(Guid flightId);
    Task ReleaseSeatAsync(Guid flightId);
}
