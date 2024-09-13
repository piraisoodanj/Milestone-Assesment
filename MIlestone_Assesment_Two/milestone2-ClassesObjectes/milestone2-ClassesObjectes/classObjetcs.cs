using System;
using System.Collections.Generic;
using System.Linq;


namespace milestone2
{

    //product class
       public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }

             public Product(string name, double price, string category)
            {
                Name = name;
                Price = price;
                Category = category;
            }

            public override string ToString()
            {
                return $"Product(Name={Name}, Price={Price:C}, Category={Category})";
            }
        }


    //user class
    public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }

            public User(string username, string password, string email)
            {
                Username = username;
                Password = password;
                Email = email;
            }

            public void ChangePassword(string newPassword)
            {
                Password = newPassword;
            }

            public override string ToString()
            {
                return $"User(Username={Username}, Email={Email})";
            }
        }

        //Order class
        public class Order
        {
            public int OrderId { get; set; }
            public User User { get; set; }
            private List<(Product Product, int Quantity)> products = new List<(Product, int)>();

            public Order(int orderId, User user)
            {
                OrderId = orderId;
                User = user;
            }

            public void AddProduct(Product product, int quantity)
            {
                products.Add((product, quantity));
            }

            public double TotalPrice()
            {
                return products.Sum(p => p.Product.Price * p.Quantity);
            }

            public override string ToString()
            {
                var productsList = string.Join(", ", products.Select(p => $"{p.Product.Name} (x{p.Quantity})"));
                return $"Order(OrderId={OrderId}, User={User}, Products=[{productsList}], TotalPrice={TotalPrice():C})";
            }
        }

        class classObjetcs
        {
            static void Main1()
            {
                // Create some products
                var product1 = new Product("Television", 55.5, "Electronics");
                var product2 = new Product("Laptop", 20.7, "Accessories");

                // Create a user
                var user = new User("Piraisoodan", "Password123", "Piraisoodan.Jayakumar@ust.com");

                // Create an order for the user
                var order = new Order(1, user);

                // Add products to the order
                order.AddProduct(product1, 1);
                order.AddProduct(product2, 2);

                // Print the details
                Console.WriteLine(product1);  
                Console.WriteLine(product2);  
                Console.WriteLine(user);     
                Console.WriteLine(order);    
            }
        }



    
}