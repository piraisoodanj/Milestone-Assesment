using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milestone2
{


    public class Product1
    {
        private string _name;
        private double _price;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    Console.WriteLine("Product name cannot be empty.");
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                    _price = value;
                else
                    Console.WriteLine("Price cannot be negative.");
            }
        }

        public Product1(string name, double price)
        {
            Name = name; 
            Price = price;
        }

        public void UpdatePrice(double newPrice)
        {
            Price = newPrice; 
        }
    }

    public class Users
    {
        private string _username;
        private string _email;
        private string _password; 

        public string Username
        {
            get { return _username; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _username = value;
                else
                    Console.WriteLine("Username cannot be empty.");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Contains("@"))
                    _email = value;
                else
                    Console.WriteLine("Invalid email format.");
            }
        }

        
        private string Password
        {
            get { return _password; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _password = value;
                else
                    Console.WriteLine("Password cannot be empty.");
            }
        }

       
        public Users(string username, string email, string password)
        {
            Username = username; 
            Email = email; 
            Password = password; 
        }

       
        public void UpdateDetails(string username, string email, string password)
        {
            Username = username; 
            Email = email; 
            Password = password; 
        }
    }

    class Encapsulation
    {
        static void Main5()
        {
            // Create a product and demonstrate encapsulation
            Product1 product = new Product1("Laptop", 91.50);
            Console.WriteLine($"Product: {product.Name}, Price: ${product.Price}");

            // Update price with validation
            product.UpdatePrice(100.96);
            Console.WriteLine($"Updated Price: ${product.Price}\n");

            // Attempt to set invalid price
            product.UpdatePrice(-10); 
            Console.WriteLine("Updated Price:${product.Price}\n");

            // Create a user and demonstrate encapsulation
            Users user = new Users("Piraisoodan", "Piraisoodan.Jayakumar@ust.com", "Password123");
            Console.WriteLine($"User: {user.Username}, Email: {user.Email}");

            user.UpdateDetails("Piraisoodan_123", "Piraisoodan.J@ust.com", "pass1234567");
            Console.WriteLine($"Updated User: {user.Username}, Email: {user.Email}\n");

            user.Email = "invalidemail";
            Console.WriteLine($"Email: {user.Email}\n");

        }
    }
}
