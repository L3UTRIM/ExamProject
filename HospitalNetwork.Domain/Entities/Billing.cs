namespace HospitalNetwork.Domain.Entities;

public class Billing
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid AppointmentId { get; set; }
    public string HospitalId { get; set; } = "";
    public decimal Amount { get; set; }
    public string ServiceDescription { get; set; } = "";
    public DateTime BillingDate { get; set; }
    public string PaymentStatus { get; set; } = "Pending";
    public string PaymentMethod { get; set; } = "";
}
