using HospitalNetwork.Domain.Entities;
using HospitalNetwork.Domain.Ports;

namespace HospitalNetwork.Application.UseCases;

public class ScheduleAppointmentUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;

    public ScheduleAppointmentUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> ExecuteAsync(Appointment appointment)
    {
        appointment.Id = Guid.NewGuid();
        appointment.Status = "Scheduled";
        return await _appointmentRepository.ScheduleAsync(appointment);
    }
}
