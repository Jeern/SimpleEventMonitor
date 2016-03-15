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

            var redisEventDataStore = new RedisEventDataStore("localhost", 6379);

            while (true)
            {
                Thread.Sleep(rnd.Next(0, 3000));
                redisEventDataStore.PersistAndPublish(new SomeEvent());
            }
        }
    }
}
