namespace FlightReservation.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public Flight Flight { get; set; } = new();
    public Passenger Passenger { get; set; } = new();
    public DateTime BookingDate { get; set; }
    public FlightReservation.Domain.Enums.ReservationStatus Status { get; set; }
    public PaymentInfo Payment { get; set; } = new();
}
