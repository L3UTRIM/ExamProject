using Microsoft.AspNetCore.Mvc;
using FlightReservation.Application.UseCases;
using FlightReservation.Domain.Entities;
using FlightReservation.API.DTOs;

namespace FlightReservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly SearchFlightsUseCase _searchFlightsUseCase;
    private readonly CreateReservationUseCase _createReservationUseCase;

    public ReservationController(SearchFlightsUseCase searchFlightsUseCase, CreateReservationUseCase createReservationUseCase)
    {
        _searchFlightsUseCase = searchFlightsUseCase;
        _createReservationUseCase = createReservationUseCase;
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchFlights([FromBody] FlightSearchRequest request)
    {
        DateTime date = DateTime.Parse(request.Date);
        var flights = await _searchFlightsUseCase.ExecuteAsync(request.Destination, date);
        return Ok(flights);
    }

    [HttpPost("book")]
    public async Task<IActionResult> CreateReservation([FromBody] ReservationRequest request)
    {
        try
        {
            var reservation = new Reservation
            {
                Flight = new Flight { Id = Guid.Parse(request.FlightId) },
                Passenger = new Passenger 
                { 
                    FirstName = request.FirstName, 
                    LastName = request.LastName, 
                    Email = request.Email, 
                    PhoneNumber = request.PhoneNumber, 
                    PassportNumber = request.PassportNumber 
                },
                Payment = new PaymentInfo 
                { 
                    CardNumber = request.CardNumber, 
                    CardHolderName = request.CardHolderName, 
                    Amount = decimal.Parse(request.Amount) 
                }
            };
            var result = await _createReservationUseCase.ExecuteAsync(reservation);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
