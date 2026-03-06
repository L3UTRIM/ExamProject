namespace FlightReservation.API.DTOs;

public class ReservationRequest
{
    public string FlightId { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string PassportNumber { get; set; } = "";
    public string CardNumber { get; set; } = "";
    public string CardHolderName { get; set; } = "";
    public string Amount { get; set; } = "";
}
