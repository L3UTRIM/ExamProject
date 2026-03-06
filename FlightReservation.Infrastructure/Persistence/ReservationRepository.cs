using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Infrastructure.Persistence;

public class ReservationRepository : IReservationRepository
{
    private static readonly List<Reservation> _reservations = new();

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        await Task.Delay(100);
        reservation.Id = Guid.NewGuid();
        _reservations.Add(reservation);
        return reservation;
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        await Task.Delay(50);
        return _reservations.FirstOrDefault(r => r.Id == id);
    }
}
