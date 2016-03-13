using System;
using System.Threading;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.Sample.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sending events...");
            var rnd = new Random();

            var redisEventDataStore = new RedisEventDataStore("http://localhost:2419", "localhost", 6379);

            while (true)
            {
                Thread.Sleep(rnd.Next(0, 10000));
                redisEventDataStore.Persist(new SomeEvent());
            }
        }
    }
}
