using HospitalNetwork.Domain.Entities;
using HospitalNetwork.Domain.Ports;
using HospitalNetwork.Application.UseCases;

namespace HospitalNetwork.Application.Adapters;

public class HospitalNetworkFacade
{
    private readonly RegisterPatientUseCase _registerPatientUseCase;
    private readonly ScheduleAppointmentUseCase _scheduleAppointmentUseCase;
    private readonly ProcessBillingUseCase _processBillingUseCase;

    public HospitalNetworkFacade(
        RegisterPatientUseCase registerPatientUseCase,
        ScheduleAppointmentUseCase scheduleAppointmentUseCase,
        ProcessBillingUseCase processBillingUseCase)
    {
        _registerPatientUseCase = registerPatientUseCase;
        _scheduleAppointmentUseCase = scheduleAppointmentUseCase;
        _processBillingUseCase = processBillingUseCase;
    }

    public async Task<Patient> RegisterPatientAsync(Patient patient)
    {
        return await _registerPatientUseCase.ExecuteAsync(patient);
    }

    public async Task<Appointment> ScheduleAppointmentAsync(Appointment appointment)
    {
        return await _scheduleAppointmentUseCase.ExecuteAsync(appointment);
    }

    public async Task<Billing> ProcessBillingAsync(Billing billing)
    {
        return await _processBillingUseCase.ExecuteAsync(billing);
    }

    public async Task<PatientAppointmentBillingResponse> RegisterPatientWithAppointmentAsync(
        Patient patient, Appointment appointment, Billing billing)
    {
        var registeredPatient = await _registerPatientUseCase.ExecuteAsync(patient);
        
        appointment.PatientId = registeredPatient.Id;
        var scheduledAppointment = await _scheduleAppointmentUseCase.ExecuteAsync(appointment);
        
        billing.PatientId = registeredPatient.Id;
        billing.AppointmentId = scheduledAppointment.Id;
        var processedBilling = await _processBillingUseCase.ExecuteAsync(billing);

        return new PatientAppointmentBillingResponse
        {
            Patient = registeredPatient,
            Appointment = scheduledAppointment,
            Billing = processedBilling
        };
    }
}

public class PatientAppointmentBillingResponse
{
    public Patient Patient { get; set; } = new();
    public Appointment Appointment { get; set; } = new();
    public Billing Billing { get; set; } = new();
}
