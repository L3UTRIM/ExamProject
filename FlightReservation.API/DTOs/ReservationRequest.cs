using System.Text.Json.Serialization;

namespace FlightReservation.API.DTOs;

public class ReservationRequest
{
    [JsonPropertyName("flightId")]
    public Guid FlightId { get; set; }
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;
    
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [JsonPropertyName("passportNumber")]
    public string PassportNumber { get; set; } = string.Empty;
    
    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; } = string.Empty;
    
    [JsonPropertyName("cardHolderName")]
    public string CardHolderName { get; set; } = string.Empty;
    
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}
