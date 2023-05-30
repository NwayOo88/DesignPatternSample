using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    //The Strategy pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable.
    //It enables the algorithm to vary independently from clients that use it.

    //For this example, By using the Strategy pattern,
    //we can dynamically switch between different payment strategies (credit card or PayPal in this example)
    //without changing the context code. The context delegates the payment process to the selected strategy,
    //allowing for flexible and interchangeable behavior.

    //Strategy interface
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    //Concrete strategies
    public class CreditCardPaymentStrategy: IPaymentStrategy
    {
        private string cardNumber;
        private string cardType;
        private string cvv;

        public CreditCardPaymentStrategy(string cardNumber, string cardType, string cvv)
        {
            this.cardNumber = cardNumber;
            this.cardType = cardType;
            this.cvv = cvv;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paying ${amount} via credit card: {cardNumber}");
        }
    }

    public class PayPalPaymentStrategy: IPaymentStrategy
    {
        private string emial;
        private string password;

        public PayPalPaymentStrategy(string emial, string password)
        {
            this.emial = emial;
            this.password = password;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paying ${amount} via PayPal account: {emial}");
        }
    }

    //Context
    public class ShoppingCart
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void ProcessPayment(double amount)
        {
            paymentStrategy.Pay(amount);
        }
    }


}
