namespace FlightReservation.Domain.Entities;

public class PaymentInfo
{
    public string CardNumber { get; set; } = string.Empty;
    public string CardHolderName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public bool IsProcessed { get; set; }
}
