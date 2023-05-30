using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    //The Factory pattern provides an interface for creating objects, 
    //but allows subclasses to decide which class to instantiate.

    //By using the factory, you can create payment processors
    //without having to directly instantiate the specific processor classes.
    //Instead, you rely on the factory to create the appropriate payment processor object
    //based on the payment method provided.
    public abstract class PaymentProcessor
    {
        public abstract void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : PaymentProcessor
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment for amount: {amount:C}");
            // Logic to process credit card payment
        }
    }

    public class PayPalProcessor : PaymentProcessor
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment for amount: {amount:C}");
            // Logic to process PayPal payment
        }
    }

    public class PaymentProcessorFactory
    {
        public PaymentProcessor CreatePaymentProcessor(string paymentMethod)
        {
            PaymentProcessor processor = null;

            if (paymentMethod.Equals("CreditCard"))
            {
                processor = new CreditCardProcessor();
            }
            else if (paymentMethod.Equals("PayPal"))
            {
                processor = new PayPalProcessor();
            }

            return processor;
        }
    }

}
