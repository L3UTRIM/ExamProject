using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Enums;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Application.UseCases;

public class CreateReservationUseCase
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly IEmailService _emailService;
    private readonly IPaymentService _paymentService;

    public CreateReservationUseCase(
        IReservationRepository reservationRepository,
        IFlightRepository flightRepository,
        IEmailService emailService,
        IPaymentService paymentService)
    {
        _reservationRepository = reservationRepository;
        _flightRepository = flightRepository;
        _emailService = emailService;
        _paymentService = paymentService;
    }

    public async Task<Reservation> ExecuteAsync(Reservation reservation)
    {
        var flight = await _flightRepository.GetByIdAsync(reservation.Flight.Id);
        
        if (flight == null || flight.AvailableSeats <= 0)
            throw new InvalidOperationException("Flight not available");

        // TWO PROCESSES RUN SIMULTANEOUSLY
        var paymentTask = _paymentService.ProcessPaymentAsync(reservation.Payment);
        var seatTask = ReserveSeatAsync(flight.Id);

        await Task.WhenAll(paymentTask, seatTask);

        var paymentResult = await paymentTask;
        
        if (!paymentResult.Success)
            throw new InvalidOperationException("Payment failed");

        reservation.Status = ReservationStatus.Confirmed;
        reservation.BookingDate = DateTime.UtcNow;
        
        await _reservationRepository.CreateAsync(reservation);

        await _emailService.SendConfirmationEmailAsync(reservation);

        return reservation;
    }

    private async Task ReserveSeatAsync(Guid flightId)
    {
        await Task.Delay(100);
    }
}
