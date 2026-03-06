namespace FlightReservation.Domain.Entities;

public class Passenger
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
}
