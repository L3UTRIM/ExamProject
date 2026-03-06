namespace FlightReservation.API.DTOs;

public class FlightPlanRequest
{
    public string Destination { get; set; } = "";
    public string Date { get; set; } = "";

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string PassportNumber { get; set; } = "";
}

