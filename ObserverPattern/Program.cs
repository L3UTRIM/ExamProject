using ObserverPattern;

Console.WriteLine("===========================================");
Console.WriteLine("   OBSERVER PATTERN DEMO - Flight Alerts   ");
Console.WriteLine("===========================================\n");

var flight = new Flight("AB123");

var passenger1 = new PassengerNotification { PassengerName = "John Doe", Email = "john@example.com" };
var passenger2 = new PassengerNotification { PassengerName = "Jane Smith", Email = "jane@example.com" };
var staff = new AirlineStaffNotification { StaffName = "Airport Control" };

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
