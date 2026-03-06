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
        var flights = await _searchFlightsUseCase.ExecuteAsync(request.Destination, request.Date);
        return Ok(flights);
    }

    [HttpPost("book")]
    public async Task<IActionResult> CreateReservation([FromBody] ReservationRequest request)
    {
        try
        {
            var reservation = MapToReservation(request);
            var result = await _createReservationUseCase.ExecuteAsync(reservation);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    private Reservation MapToReservation(ReservationRequest request)
    {
        return new Reservation
        {
            Flight = new Flight { Id = request.FlightId },
            Passenger = new Passenger { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, PhoneNumber = request.PhoneNumber, PassportNumber = request.PassportNumber },
            Payment = new PaymentInfo { CardNumber = request.CardNumber, CardHolderName = request.CardHolderName, Amount = request.Amount }
        };
    }
}
