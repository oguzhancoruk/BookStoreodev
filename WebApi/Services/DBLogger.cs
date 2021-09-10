using System;

namespace WebApi.Service
{
    public class DBLogger : ILogerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - "+message); 
        }
    }
}