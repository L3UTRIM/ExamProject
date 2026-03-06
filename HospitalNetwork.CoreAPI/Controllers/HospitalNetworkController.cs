using Microsoft.AspNetCore.Mvc;
using HospitalNetwork.Domain.Entities;
using HospitalNetwork.Application.Adapters;

namespace HospitalNetwork.CoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HospitalNetworkController : ControllerBase
{
    private readonly HospitalNetworkFacade _facade;

    public HospitalNetworkController(HospitalNetworkFacade facade)
    {
        _facade = facade;
    }

    [HttpPost("patient/register")]
    public async Task<IActionResult> RegisterPatient([FromBody] Patient patient)
    {
        var result = await _facade.RegisterPatientAsync(patient);
        return Ok(result);
    }

    [HttpPost("appointment/schedule")]
    public async Task<IActionResult> ScheduleAppointment([FromBody] Appointment appointment)
    {
        var result = await _facade.ScheduleAppointmentAsync(appointment);
        return Ok(result);
    }

    [HttpPost("billing/process")]
    public async Task<IActionResult> ProcessBilling([FromBody] Billing billing)
    {
        var result = await _facade.ProcessBillingAsync(billing);
        return Ok(result);
    }

    [HttpPost("patient/complete-registration")]
    public async Task<IActionResult> CompletePatientRegistration([FromBody] CompleteRegistrationRequest request)
    {
        var patient = new Patient
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = DateTime.Parse(request.DateOfBirth),
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Address = request.Address,
            BloodType = request.BloodType,
            Allergies = request.Allergies.Split(',').ToList(),
            AssignedHospitalId = request.HospitalId
        };

        var appointment = new Appointment
        {
            HospitalId = request.HospitalId,
            Department = request.Department,
            DoctorName = request.DoctorName,
            AppointmentDate = DateTime.Parse(request.AppointmentDate),
            Notes = request.AppointmentNotes
        };

        var billing = new Billing
        {
            HospitalId = request.HospitalId,
            Amount = decimal.Parse(request.BillingAmount),
            ServiceDescription = request.ServiceDescription
        };

        var result = await _facade.RegisterPatientWithAppointmentAsync(patient, appointment, billing);
        return Ok(result);
    }
}

public class CompleteRegistrationRequest
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string DateOfBirth { get; set; } = "";
    public string Gender { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public string BloodType { get; set; } = "";
    public string Allergies { get; set; } = "";
    public string HospitalId { get; set; } = "";
    public string Department { get; set; } = "";
    public string DoctorName { get; set; } = "";
    public string AppointmentDate { get; set; } = "";
    public string AppointmentNotes { get; set; } = "";
    public string BillingAmount { get; set; } = "";
    public string ServiceDescription { get; set; } = "";
}
