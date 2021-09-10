using System;

namespace WebApi.Service
{
    public class ConsoleLogger : ILogerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - "+message); 
        }
    }
}