using FlightReservation.Domain.Entities;

namespace FlightReservation.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation> CreateAsync(Reservation reservation);
    Task<Reservation?> GetByIdAsync(Guid id);
}
