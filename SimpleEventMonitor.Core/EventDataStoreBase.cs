using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;

namespace SimpleEventMonitor.Core
{
    public abstract class EventDataStoreBase : IEventDataStore
    {
        protected EventDataStoreBase(string hubBaseUrl)
        {
            _connection = new HubConnection(hubBaseUrl);
        }

        private readonly HubConnection _connection;

        private IHubProxy _eventHub;
        private IHubProxy EventHub
        {
            get
            {
                if (_connection.State == ConnectionState.Connecting || _connection.State == ConnectionState.Reconnecting)
                    return null; //Det virker nok, men ikke lige nu

                if (_eventHub == null)
                {
                    _eventHub = _connection.CreateHubProxy("EventHub");
                }

                if (_connection.State == ConnectionState.Disconnected)
                {
                    _connection.Start().ContinueWith(task => {
                        if (task.IsFaulted)
                        {
                            Console.WriteLine("Error opening eventHub connection:{0}", task.Exception?.GetBaseException());
                        }
                        else {
                            Console.WriteLine("Connected");
                        }

                    }).Wait();
                }
                return _eventHub;
            }
        }

        public void Persist(object evt)
        {
            var simpleEvent = new SimpleEvent(evt);
            Persist(simpleEvent);
            PublishViaSignalR(simpleEvent);
        }

        protected abstract void Persist(SimpleEvent evt);

        public abstract IEnumerable<SimpleEvent> GetEvents();

        private void PublishViaSignalR(SimpleEvent evt)
        {
            EventHub.Invoke<SimpleEvent>("Publish", evt).ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling publish: {0}", task.Exception?.GetBaseException());
                }
            });
        }
    }
}
