using HospitalNetwork.Domain.Entities;

namespace HospitalNetwork.Domain.Ports;

public interface IBillingRepository
{
    Task<Billing> CreateAsync(Billing billing);
    Task<Billing?> GetByIdAsync(Guid id);
    Task<IEnumerable<Billing>> GetByPatientIdAsync(Guid patientId);
    Task<bool> UpdatePaymentStatusAsync(Guid id, string status);
}
