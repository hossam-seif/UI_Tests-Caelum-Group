using System;

namespace TestFramework
{
    public class ConsoleLogger : ILogger
    {
        public void Print(string message)
        {
            Console.WriteLine(DateTime.Now + " : " + message);
        }
    }
}
