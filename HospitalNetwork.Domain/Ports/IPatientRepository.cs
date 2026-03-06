using HospitalNetwork.Domain.Entities;

namespace HospitalNetwork.Domain.Ports;

public interface IPatientRepository
{
    Task<Patient> RegisterAsync(Patient patient);
    Task<Patient?> GetByIdAsync(Guid id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<bool> UpdateAsync(Patient patient);
}
