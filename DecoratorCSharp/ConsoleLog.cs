using System;

namespace DecoratorCSharp
{
    public class ConsoleLog : ILog
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
