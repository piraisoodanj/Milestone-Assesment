using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FlightBookingSystem
{
    // Abstract class Flight
    public abstract class Flight
    {
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public double BaseFare { get; set; }

        public abstract double CalculateFare();
        public abstract void DisplayDetails();
    }

    // Derived class DomesticFlight
    public class DomesticFlight : Flight
    {
        public override double CalculateFare()
        {
            return BaseFare * 1.5;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Domestic Flight: {FlightNumber}, Destination: {Destination}, Fare: {CalculateFare():C}");
        }
    }

    // Derived class InternationalFlight
    public class InternationalFlight : Flight
    {
        public override double CalculateFare()
        {
            return BaseFare * 1.75;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"International Flight: {FlightNumber}, Destination: {Destination}, Fare: {CalculateFare():C}");
        }
    }

    // Passenger class
    public class Passenger
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    // Booking interface
    public interface IBooking
    {
        void BookTicket(Flight flight, Passenger passenger);
        void CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
    }

    // OnlineBooking class implementing IBooking
    public class OnlineBooking : IBooking
    {
        private List<Booking> bookings = new List<Booking>();
        private int bookingIdCounter = 1;

        public void BookTicket(Flight flight, Passenger passenger)
        {
            Booking booking = new Booking { Id = bookingIdCounter++, Flight = flight, Passenger = passenger };
            bookings.Add(booking);
            Console.WriteLine($"Booking successful for {passenger.Name} on {flight.FlightNumber}.");
        }

        public void CancelBooking(int bookingId)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                bookings.Remove(booking);
                Console.WriteLine($"Booking ID {bookingId} has been cancelled.");
            }
            else
            {
                Console.WriteLine("Booking ID not found.");
            }
        }

        public Booking GetBookingDetails(int bookingId)
        {
            return bookings.FirstOrDefault(b => b.Id == bookingId);
        }
    }

    // AgencyBooking class implementing IBooking
    public class AgencyBooking : IBooking
    {
        private List<Booking> bookings = new List<Booking>();
        private int bookingIdCounter = 1;

        public void BookTicket(Flight flight, Passenger passenger)
        {
            Booking booking = new Booking { Id = bookingIdCounter++, Flight = flight, Passenger = passenger };
            bookings.Add(booking);
            Console.WriteLine($"Agency booking successful for {passenger.Name} on {flight.FlightNumber}.");
        }

        public void CancelBooking(int bookingId)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                bookings.Remove(booking);
                Console.WriteLine($"Agency booking ID {bookingId} has been cancelled.");
            }
            else
            {
                Console.WriteLine("Booking ID not found.");
            }
        }

        public Booking GetBookingDetails(int bookingId)
        {
            return bookings.FirstOrDefault(b => b.Id == bookingId);
        }
    }

    // Booking class
    public class Booking
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
    }

    // FlightManager class for managing flights
    public partial class FlightManager
    {
        private Flight[] flightArray;
        private List<Flight> flightList;

        public FlightManager(int fixedSize)
        {
            flightArray = new Flight[fixedSize];
            flightList = new List<Flight>();
        }

        public void AddFlightToArray(Flight flight, int index)
        {
            if (index < flightArray.Length)
                flightArray[index] = flight;
        }

        public void AddFlightToList(Flight flight)
        {
            flightList.Add(flight);
        }

        public void RemoveFlightFromList(Flight flight)
        {
            flightList.Remove(flight);
        }

        public Flight SearchFlightInArray(string flightNumber)
        {
            return flightArray.FirstOrDefault(f => f?.FlightNumber == flightNumber);
        }

        public Flight SearchFlightInList(string flightNumber)
        {
            return flightList.FirstOrDefault(f => f.FlightNumber == flightNumber);
        }

        public IEnumerable<Flight> GetFlightsByDestination(string destination)
        {
            return flightList.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Flight> GetSortedFlightsByFare()
        {
            return flightList.OrderBy(f => f.CalculateFare());
        }

        public IEnumerable<IGrouping<string, Flight>> GroupFlightsByCategory()
        {
            return flightList.GroupBy(f => f is DomesticFlight ? "Domestic" : "International");
        }

        public void DisplayFlightDetails()
        {
            foreach (var flight in flightList)
            {
                flight.DisplayDetails();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            FlightManager flightManager = new FlightManager(5);

            // Creating flights
            Flight flight1 = new DomesticFlight { FlightNumber = "FL1234", Destination = "Bangalore", BaseFare = 200 };
            Flight flight2 = new InternationalFlight { FlightNumber = "FL4567", Destination = "London", BaseFare = 300 };

            // Adding flights
            flightManager.AddFlightToArray(flight1, 0);
            flightManager.AddFlightToList(flight1);
            flightManager.AddFlightToList(flight2);

            // Display flights
            Console.WriteLine("All Flights:");
            flightManager.DisplayFlightDetails();

            // Booking demonstration
            Passenger passenger = new Passenger { Name = "Piraisoodan J", Email = "Piraisoodan.J@ust.com", Phone = "9087285957" };
            IBooking bookingSystem = new OnlineBooking();
            bookingSystem.BookTicket(flight1, passenger);

            // LINQ Queries
            Console.WriteLine("\nFlights to Bangalore:");
            var flightsToNY = flightManager.GetFlightsByDestination("Bangalore");
            foreach (var flight in flightsToNY)
            {
                flight.DisplayDetails();
            }

            Console.WriteLine("\nSorted Flights by Fare:");
            var sortedFlights = flightManager.GetSortedFlightsByFare();
            foreach (var flight in sortedFlights)
            {
                flight.DisplayDetails();
            }

            Console.WriteLine("\nGrouped Flights by Category:");
            var groupedFlights = flightManager.GroupFlightsByCategory();
            foreach (var group in groupedFlights)
            {
                Console.WriteLine(group.Key + " Flights:");
                foreach (var flight in group)
                {
                    flight.DisplayDetails();
                }
            }

            // File handling
            string filePath = "flights.csv";
            flightManager.WriteFlightsToCsv(filePath);
            flightManager.ReadFlightsFromCsv(filePath);
        }
    }

    // Regex validation methods
    public static class Validator
    {
        public static bool ValidFlightNumber(string flightNumber)
        {
            return Regex.IsMatch(flightNumber, @"^FL\d{4}$");
        }

        public static bool ValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool ValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
    }

    // CSV file handling
    public partial class FlightManager
    {
        public void ReadFlightsFromCsv(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    Flight flight = parts[1].Trim().ToLower() == "domestic"
                        ? new DomesticFlight { FlightNumber = parts[0], Destination = parts[2], BaseFare = double.Parse(parts[3]) }
                        : new InternationalFlight { FlightNumber = parts[0], Destination = parts[2], BaseFare = double.Parse(parts[3]) };
                    AddFlightToList(flight);
                }
                Console.WriteLine("Flights loaded from CSV successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading flights from CSV: {ex.Message}");
            }
        }

        public void WriteFlightsToCsv(string filePath)
        {
            try
            {
                var lines = flightList.Select(f => $"{f.FlightNumber},{(f is DomesticFlight ? "Domestic" : "International")},{f.Destination},{f.BaseFare}");
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Flights written to CSV successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing flights to CSV: {ex.Message}");
            }
        }
    }
}