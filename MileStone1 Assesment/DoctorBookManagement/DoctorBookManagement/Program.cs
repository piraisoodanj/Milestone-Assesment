using System;
using System.Collections.Generic;
using DoctorsBook;

namespace DoctorBookManagement
{
    internal class Program
    {
        // List to store collection of Doctor Details
        static List<Doctor> DoctorsDetials = new List<Doctor>();

        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Doctor Management System");
                Console.WriteLine("1. Add Doctor Information");
                Console.WriteLine("2. Display Doctor's List");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddDoctors();
                        break;
                    case "2":
                        DisplayDoctors();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        //Add Doctor details
        static void AddDoctors()
        {
            try
            {
                Doctor newDoctor = new Doctor();
                newDoctor.AcceptDoctorInformation();
                DoctorsDetials.Add(newDoctor);
                Console.WriteLine("Doctor added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        //Display Doctors List
        static void DisplayDoctors()
        {
            if (DoctorsDetials.Count == 0)
            {
                Console.WriteLine("No Doctors available.");
            }
           else
            {
                foreach (var Doc in DoctorsDetials)
                {
                    
                    Console.WriteLine($"Registration No: {Doc.RegistrationNo}");
                    Console.WriteLine($"Doctor Name: {Doc.DoctorName}");
                    Console.WriteLine($"City: {Doc.City}");
                    Console.WriteLine($"AreaofSpecialization: {Doc.AreaOfSpecialization}");
                    Console.WriteLine($"ClinicAddress: {Doc.ClinicAddress}");
                    Console.WriteLine($"ClinicTimings: {Doc.ClinicTimings}");
                    Console.WriteLine($"Contact No: {Doc.ContactNo}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}