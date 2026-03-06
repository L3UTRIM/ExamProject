using HospitalNetwork.Domain.Ports;
using HospitalNetwork.Domain.Entities;
using HospitalNetwork.Application.UseCases;
using HospitalNetwork.Application.Adapters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddScoped<RegisterPatientUseCase>();
builder.Services.AddScoped<ScheduleAppointmentUseCase>();
builder.Services.AddScoped<ProcessBillingUseCase>();
builder.Services.AddScoped<HospitalNetworkFacade>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital Network API v1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();
app.MapControllers();
app.Run();

public class PatientRepository : IPatientRepository
{
    private static readonly List<Patient> _patients = new();
    
    public async Task<Patient> RegisterAsync(Patient patient)
    {
        await Task.Delay(100);
        patient.Id = Guid.NewGuid();
        _patients.Add(patient);
        return patient;
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        await Task.Delay(50);
        return _patients.FirstOrDefault(p => p.Id == id);
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        await Task.Delay(50);
        return _patients;
    }

    public async Task<bool> UpdateAsync(Patient patient)
    {
        await Task.Delay(50);
        var index = _patients.FindIndex(p => p.Id == patient.Id);
        if (index >= 0) { _patients[index] = patient; return true; }
        return false;
    }
}

public class AppointmentRepository : IAppointmentRepository
{
    private static readonly List<Appointment> _appointments = new();
    
    public async Task<Appointment> ScheduleAsync(Appointment appointment)
    {
        await Task.Delay(100);
        appointment.Id = Guid.NewGuid();
        _appointments.Add(appointment);
        return appointment;
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        await Task.Delay(50);
        return _appointments.FirstOrDefault(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId)
    {
        await Task.Delay(50);
        return _appointments.Where(a => a.PatientId == patientId);
    }

    public async Task<bool> UpdateStatusAsync(Guid id, string status)
    {
        await Task.Delay(50);
        var apt = _appointments.FirstOrDefault(a => a.Id == id);
        if (apt != null) { apt.Status = status; return true; }
        return false;
    }
}

public class BillingRepository : IBillingRepository
{
    private static readonly List<Billing> _billings = new();
    
    public async Task<Billing> CreateAsync(Billing billing)
    {
        await Task.Delay(100);
        billing.Id = Guid.NewGuid();
        _billings.Add(billing);
        return billing;
    }

    public async Task<Billing?> GetByIdAsync(Guid id)
    {
        await Task.Delay(50);
        return _billings.FirstOrDefault(b => b.Id == id);
    }

    public async Task<IEnumerable<Billing>> GetByPatientIdAsync(Guid patientId)
    {
        await Task.Delay(50);
        return _billings.Where(b => b.PatientId == patientId);
    }

    public async Task<bool> UpdatePaymentStatusAsync(Guid id, string status)
    {
        await Task.Delay(50);
        var billing = _billings.FirstOrDefault(b => b.Id == id);
        if (billing != null) { billing.PaymentStatus = status; return true; }
        return false;
    }
}
