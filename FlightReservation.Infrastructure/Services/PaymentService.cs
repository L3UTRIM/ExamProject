using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    public async Task<PaymentResult> ProcessPaymentAsync(PaymentInfo payment)
    {
        await Task.Delay(300);
        
        if (string.IsNullOrEmpty(payment.CardNumber) || payment.CardNumber.Length < 16)
            return new PaymentResult { Success = false, Message = "Invalid card number" };

        if (payment.Amount <= 0)
            return new PaymentResult { Success = false, Message = "Invalid amount" };

        payment.IsProcessed = true;
        return new PaymentResult { Success = true, Message = "Payment processed successfully" };
    }
}
