using HospitalNetwork.Domain.Entities;

namespace HospitalNetwork.Domain.Ports;

public interface IAppointmentRepository
{
    Task<Appointment> ScheduleAsync(Appointment appointment);
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId);
    Task<bool> UpdateStatusAsync(Guid id, string status);
}
