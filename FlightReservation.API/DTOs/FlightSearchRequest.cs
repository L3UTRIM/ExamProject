namespace FlightReservation.API.DTOs;

public class FlightSearchRequest
{
    public string Destination { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
