using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Application.UseCases;

public class SearchFlightsUseCase
{
    private readonly IFlightRepository _flightRepository;

    public SearchFlightsUseCase(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<IEnumerable<Flight>> ExecuteAsync(string destination, DateTime date)
    {
        return await _flightRepository.SearchFlightsAsync(destination, date);
    }
}
