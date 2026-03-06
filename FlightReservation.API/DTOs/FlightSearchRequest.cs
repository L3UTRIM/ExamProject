using System.Text.Json.Serialization;

namespace FlightReservation.API.DTOs;

public class FlightSearchRequest
{
    [JsonPropertyName("destination")]
    public string Destination { get; set; } = string.Empty;
    
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
}
