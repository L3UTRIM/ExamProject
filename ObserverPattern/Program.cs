namespace ObserverPattern
{
    // Subject Interface
    public interface IFlightSubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Concrete Subject - Flight
    public class Flight : IFlightSubject
    {
        private List<IObserver> _observers = new();
        public string FlightNumber { get; private set; }
        public string Status { get; private set; }

        public Flight(string flightNumber)
        {
            FlightNumber = flightNumber;
            Status = "On Time";
        }

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);
        public void Notify() => _observers.ForEach(o => o.Update(this));

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"\n=== FLIGHT STATUS CHANGED: {FlightNumber} is now {Status} ===");
            Notify();
        }
    }

    // Observer Interface
    public interface IObserver
    {
        void Update(Flight flight);
    }

    // Concrete Observer - Passenger
    public class PassengerNotification : IObserver
    {
        public string PassengerName { get; set; } = "";
        public string Email { get; set; } = "";

        public void Update(Flight flight)
        {
            Console.WriteLine($"[Email to {Email}]");
            Console.WriteLine($"  Dear {PassengerName},");
            Console.WriteLine($"  Your flight {flight.FlightNumber} status: {flight.Status}");
            Console.WriteLine();
        }
    }

    // Concrete Observer - Airline Staff
    public class AirlineStaffNotification : IObserver
    {
        public string StaffName { get; set; } = "";

        public void Update(Flight flight)
        {
            Console.WriteLine($"[Staff Alert for {StaffName}]");
            Console.WriteLine($"  Flight {flight.FlightNumber} status changed to: {flight.Status}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("   OBSERVER PATTERN DEMO - Flight Alerts   ");
        Console.WriteLine("===========================================\n");

        var flight = new ObserverPattern.Flight("AB123");

        var passenger1 = new ObserverPattern.PassengerNotification { PassengerName = "John Doe", Email = "john@example.com" };
        var passenger2 = new ObserverPattern.PassengerNotification { PassengerName = "Jane Smith", Email = "jane@example.com" };
        var staff = new ObserverPattern.AirlineStaffNotification { StaffName = "Airport Control" };

        flight.Attach(passenger1);
        flight.Attach(passenger2);
        flight.Attach(staff);

        Console.WriteLine("--- Flight is ON TIME ---");
        flight.UpdateStatus("On Time");

        Console.WriteLine("\n--- Flight is DELAYED ---");
        flight.UpdateStatus("Delayed");

        Console.WriteLine("\n--- Flight is CANCELLED ---");
        flight.UpdateStatus("Cancelled");

        Console.WriteLine("\n--- Jane Smith unsubscribes ---");
        flight.Detach(passenger2);

        Console.WriteLine("\n--- Flight rescheduled to NEW TIME ---");
        flight.UpdateStatus("Rescheduled");

        Console.WriteLine("\n===========================================");
        Console.WriteLine("   Observer Pattern: ONE Subject, MANY Observers   ");
        Console.WriteLine("   When flight status changes, ALL observers are notified!");
        Console.WriteLine("===========================================");
    }
}
