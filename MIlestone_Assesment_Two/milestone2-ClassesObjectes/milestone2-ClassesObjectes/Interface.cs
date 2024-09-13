using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milestone2
{
    public interface IOrderProcessor
    {
        void ProcessOrder(int orderId);
        void CancelOrder(int orderId);
    }

    // Implement the IOrderProcessor interface in PaymentProcessor class
    public class PaymentProcessor : IOrderProcessor
    {
        public void ProcessOrder(int orderId)
        {
            Console.WriteLine($"Processing payment for order ID: {orderId}");
        }

        public void CancelOrder(int orderId)
        {
            Console.WriteLine($"Cancelling payment for order ID: {orderId}");
        }
    }

    // Implement the IOrderProcessor interface in ShippingProcessor class
    public class ShippingProcessor : IOrderProcessor
    {
        public void ProcessOrder(int orderId)
        {
            Console.WriteLine($"Shipping order ID: {orderId}");
        }

        public void CancelOrder(int orderId)
        {
            Console.WriteLine($"Cancelling shipping for order ID: {orderId}");
        }
    }

    class Interface
    {
        static void Main()
        {
            IOrderProcessor paymentProcessor = new PaymentProcessor();
            IOrderProcessor shippingProcessor = new ShippingProcessor();

            int orderId = 745657;

            paymentProcessor.ProcessOrder(orderId);
            paymentProcessor.CancelOrder(orderId);

            shippingProcessor.ProcessOrder(orderId);
            shippingProcessor.CancelOrder(orderId);
        }
    }
}
