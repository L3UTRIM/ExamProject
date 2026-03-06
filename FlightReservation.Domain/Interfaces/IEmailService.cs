using FlightReservation.Domain.Entities;

namespace FlightReservation.Domain.Interfaces;

public interface IEmailService
{
    Task SendConfirmationEmailAsync(Reservation reservation);
}
