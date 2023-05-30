using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    //The Singleton pattern ensures that only one instance of a class is created
    //and provides a global point of access to it.

    public class Logger
    {
        private static Logger instance;
        private static readonly object lockObject = new object();

        private Logger()
        {
            // Private constructor to prevent instantiation from outside the class
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"Logging message: {message}");
            // Logic to write the message to a log file
        }
    }
}
