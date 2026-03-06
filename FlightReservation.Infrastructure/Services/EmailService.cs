using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Infrastructure.Services;

public class EmailService : IEmailService
{
    public async Task SendConfirmationEmailAsync(Reservation reservation)
    {
        await Task.Delay(200);
        Console.WriteLine($"\n=== EMAIL SENT ===\nTo: {reservation.Passenger.Email}\nFlight: {reservation.Flight.FlightNumber}\nConfirmed! Booking ID: {reservation.Id}");
    }
}
