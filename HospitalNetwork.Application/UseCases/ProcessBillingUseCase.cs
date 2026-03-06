using HospitalNetwork.Domain.Entities;
using HospitalNetwork.Domain.Ports;

namespace HospitalNetwork.Application.UseCases;

public class ProcessBillingUseCase
{
    private readonly IBillingRepository _billingRepository;

    public ProcessBillingUseCase(IBillingRepository billingRepository)
    {
        _billingRepository = billingRepository;
    }

    public async Task<Billing> ExecuteAsync(Billing billing)
    {
        billing.Id = Guid.NewGuid();
        billing.BillingDate = DateTime.UtcNow;
        billing.PaymentStatus = "Pending";
        return await _billingRepository.CreateAsync(billing);
    }
}
