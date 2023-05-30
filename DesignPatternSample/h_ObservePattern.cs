using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    //The Observer pattern allows decoupling between the subject and its observers,
    //enabling the subject to notify multiple observers without having direct knowledge of their existence.

    //Subject (Publisher)
    public interface INewsPublisher
    {
        void AddSubscriber(INewsSubscriber subscriber);
        void RemoveSubscriber(INewsSubscriber subscriber);
        void NotifySubscribers(string newsUpdate);
    }

    // Observer (Subscriber)
    public interface INewsSubscriber
    {
        string Name { get; }
        void ReceiveUpdate(string newsUpdate);
    }

    //Concrete Subject (Concrete Publisher)
    public class NewsAgency : INewsPublisher
    {
        private List<INewsSubscriber> subscribers = new List<INewsSubscriber>();

        public void AddSubscriber(INewsSubscriber subscriber) 
        { 
            subscribers.Add(subscriber);
            Console.WriteLine($"New subscriber added: {subscriber.Name}");
        } 

        public void RemoveSubscriber(INewsSubscriber subscriber)
        {
            subscribers.Remove(subscriber);
            Console.WriteLine($"Subscriber removed: {subscriber.Name}");
        }

        public void NotifySubscribers(string newsUpdate)
        {
            Console.WriteLine($"News Agency publishing update: {newsUpdate}");
            Console.WriteLine("----------------------------------------");
            foreach (var subscriber in subscribers)
            {
                subscriber.ReceiveUpdate(newsUpdate);
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    // Concrete Observer (Concrete Subscriber)
    public class EmailSubscriber : INewsSubscriber
    {
        public string Name { get; private set; }

        public EmailSubscriber(string name)
        {
            Name = name;
        }

        public void ReceiveUpdate(string newsUpdate)
        {
            Console.WriteLine($"[{Name}] New email notification received: {newsUpdate}");
        }
    }

    // Concrete Observer (Concrete Subscriber)
    public class SMSSubscriber : INewsSubscriber
    {
        public string Name { get; private set; }
        public SMSSubscriber(string name)
        {
            Name = name;
        }
        public void ReceiveUpdate(string newsUpdate)
        {
            Console.WriteLine($"[{Name}] New SMS received: {newsUpdate}");
        }
    }
}
