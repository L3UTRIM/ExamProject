using HospitalNetwork.Domain.Entities;
using HospitalNetwork.Domain.Ports;

namespace HospitalNetwork.Application.UseCases;

public class RegisterPatientUseCase
{
    private readonly IPatientRepository _patientRepository;

    public RegisterPatientUseCase(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient> ExecuteAsync(Patient patient)
    {
        patient.Id = Guid.NewGuid();
        return await _patientRepository.RegisterAsync(patient);
    }
}
