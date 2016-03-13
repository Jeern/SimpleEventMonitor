using System;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using SimpleEventMonitor.Store.Redis;

namespace SimpleEventMonitor.SampleSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sending events...");
            var rnd = new Random();

            while (true)
            {
                Thread.Sleep(rnd.Next(0, 10000));
                RedisEventDataStore.Current.Persist(new SomeEvent());
            }
        }
    }
}
