using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoctorsBook
{
    public class Doctor
    {
        //Assigning Variables
        public string RegistrationNo { get; set; }
        public string DoctorName {  get; set; }
        public string City { get; set; }
        public string AreaOfSpecialization { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicTimings { get; set; }
        public string ContactNo { get; set; }
      
        // Method for Accept details from User
        public void AcceptDoctorInformation()
        {
            Console.WriteLine("Enter Registration No");
            RegistrationNo = Console.ReadLine();
            ValidRegNo(RegistrationNo);

            Console.WriteLine("Enter Doctor Name");
            DoctorName = Console.ReadLine();
            OnlyAlphabet(DoctorName);

            Console.WriteLine("Enter City");
            City = Console.ReadLine();
            MandatoryField(City);

            Console.WriteLine("Enter Area of Specialization");
            AreaOfSpecialization = Console.ReadLine();
            OnlyAlphabet(AreaOfSpecialization);

            Console.WriteLine("Enter Clinic Address");
            ClinicAddress = Console.ReadLine();
            MandatoryField(ClinicAddress);

            Console.WriteLine("Enter Clinic Timings");
            ClinicTimings = Console.ReadLine();
            MandatoryField(ClinicTimings);

            Console.WriteLine("Enter Contact No");
            ContactNo = Console.ReadLine();
            ValidContactNo(ContactNo);

        }

        //Method for Valid Registration Number should be only 7 digit numbers
        public void ValidRegNo(string RegNo)
        {
            string DigitPattern = @"^\d{7}$";

            bool isMatch = Regex.IsMatch(RegNo, DigitPattern);
            Console.WriteLine(isMatch);
            Console.WriteLine(!String.IsNullOrEmpty(RegNo));
            if (isMatch && !string.IsNullOrEmpty(RegNo))
                return;
            else
               throw new ArgumentException("Registration No Should be of 7 digit only");

        }

        // Method for Valid Doctor Name and Area of Specialization Accept only alphabets

        public void OnlyAlphabet(string Text)
        {
            string Textpatern = @"^[a-zA-Z]+$";

            bool isTextMatch = Regex.IsMatch(Text, Textpatern);
            if (isTextMatch && !string.IsNullOrEmpty(Text))
                return;
            else
                throw new ArgumentException("Text Should be only aphabets");
        }

        // Method for Valid Contact Number
        public void ValidContactNo(string ContactNumber)
        {
            string ContactNoPattern = @"^\d{10}$";

            bool isMatch = Regex.IsMatch(ContactNumber, ContactNoPattern);
            if (isMatch && !string.IsNullOrEmpty(ContactNumber))
            {
                return;
            }
            else
            {

                throw new ArgumentException("Contact Number Should be of 10 digit only");
            }
        }

        public void MandatoryField(string MandatoryText)
        {
            if (!string.IsNullOrEmpty(MandatoryText))
            {
                return;
            }
            else
            {
                throw new ArgumentException("Mandatory Fileds are missing. Should not be empty");
            }
        }
    }
    
}

