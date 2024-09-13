using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milestone2
{
    
    public class Orders
    {
        // Base method for calculating total amount without a discount
        public virtual double CalculateTotalAmount(double baseAmount)
        {
            return baseAmount;
        }

        // Method to add a product with just the name and price
        public void AddProduct(string productName, double price)
        {
            Console.WriteLine($"Product added: {productName} at ${price}");
        }

        // Overloaded method to add a product with name, price, and quantity
        public void AddProduct(string productName, double price, int quantity)
        {
            Console.WriteLine($"Product added: {productName} at ${price} with quantity {quantity}");
        }

        // Overloaded method to add a product with name, price, quantity, and category
        public void AddProduct(string productName, double price, int quantity, string category)
        {
            Console.WriteLine($"Product added: {productName} at ${price}, quantity {quantity}, category {category}");
        }
    }

    public class DiscountedOrder : Orders
    {
        // Override method to calculate total amount with a discount
        public override double CalculateTotalAmount(double baseAmount)
        {
            double discount = 0.5; 
            return baseAmount - (baseAmount * discount);
        }
    }

    class Inheritance
    {
        static void Main3()
        {
            // Create instances of Order and DiscountedOrder
            Orders regularOrder = new Orders();
            DiscountedOrder discountOrder = new DiscountedOrder();

            double baseAmount = 100.00;

            // Demonstrate method overriding
            Console.WriteLine("Total amount without discount: $" + regularOrder.CalculateTotalAmount(baseAmount));
            Console.WriteLine("Total amount with discount: $" + discountOrder.CalculateTotalAmount(baseAmount));

            // Demonstrate method overloading
            regularOrder.AddProduct("Laptop", 100.50);
            regularOrder.AddProduct("Mouse", 25.50, 2);
            regularOrder.AddProduct("Keyboard", 75.40, 1, "Electronics");
        }
    }
}
