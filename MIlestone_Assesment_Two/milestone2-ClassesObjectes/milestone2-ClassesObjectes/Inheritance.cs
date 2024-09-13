using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milestone2
{

    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"Person(Name={Name}, Email={Email})";
        }
    }



    public class Customer : Person
    {
        public string CustomerID { get; set; }

        public Customer(string name, string email, string customerID) : base(name, email)
        {
            CustomerID = customerID;
        }

        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer Info: {ToString()}, CustomerID={CustomerID}");
        }

        public override string ToString()
        {
            return $"Customer(Name={Name}, Email={Email}, CustomerID={CustomerID})";
        }
    }


    public class Admin : Person
    {
        public string AdminRole { get; set; }

        public Admin(string name, string email, string adminRole) : base(name, email)
        {
            AdminRole = adminRole;
        }

        public void DisplayAdminInfo()
        {
            Console.WriteLine($"Admin Info: {ToString()}, AdminRole={AdminRole}");
        }

        public override string ToString()
        {
            return $"Admin(Name={Name}, Email={Email}, AdminRole={AdminRole})";
        }
    }

    class Inheritance1
    {
        static void Main2()
        {
            // Create a Customer instance
            var customer = new Customer("Pirai", "Piraisoodan.jayakumar@ust.com", "12345");
            customer.DisplayCustomerInfo(); 

            // Create an Admin instance
            var admin = new Admin("Admin", "Admin@ust.com", "System Admin");
            admin.DisplayAdminInfo();  

            // Show inherited properties
            Console.WriteLine(customer);
            Console.WriteLine(admin);     
        }

    }
}