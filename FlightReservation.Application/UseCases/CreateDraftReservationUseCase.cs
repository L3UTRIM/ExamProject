using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Interfaces;

namespace FlightReservation.Application.UseCases;

public record DraftReservationResult(Passenger Passenger, IReadOnlyList<Flight> AvailableFlights);

public class CreateDraftReservationUseCase
{
    private readonly IFlightRepository _flightRepository;

    public CreateDraftReservationUseCase(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<DraftReservationResult> ExecuteAsync(string destination, DateTime date, Passenger passenger)
    {
        // TWO ACTIVITIES RUN SIMULTANEOUSLY: passenger data processing + flight search
        var passengerTask = Task.Run(() => NormalizeAndValidate(passenger));
        var flightsTask = _flightRepository.SearchFlightsAsync(destination, date);

        await Task.WhenAll(passengerTask, flightsTask);

        var normalizedPassenger = await passengerTask;
        var flights = (await flightsTask).ToList();

        return new DraftReservationResult(normalizedPassenger, flights);
    }

    private static Passenger NormalizeAndValidate(Passenger passenger)
    {
        passenger.FirstName = passenger.FirstName.Trim();
        passenger.LastName = passenger.LastName.Trim();
        passenger.Email = passenger.Email.Trim();
        passenger.PhoneNumber = passenger.PhoneNumber.Trim();
        passenger.PassportNumber = passenger.PassportNumber.Trim();

        if (string.IsNullOrWhiteSpace(passenger.FirstName) ||
            string.IsNullOrWhiteSpace(passenger.LastName) ||
            string.IsNullOrWhiteSpace(passenger.Email))
            throw new InvalidOperationException("Passenger data is incomplete");

        return passenger;
    }
}

