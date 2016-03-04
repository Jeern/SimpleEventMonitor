using System;
using System.Collections.Generic;

namespace SimpleEventMonitor.Common
{
    public abstract class EventDataStoreBase : IEventDataStore
    {
        public void Persist(object evt)
        {
            var simpleEvent = new SimpleEvent(evt);
            Persist(simpleEvent);
            OnSimpleEventHappened(simpleEvent);
        }

        protected abstract void Persist(SimpleEvent evt);

        public abstract IEnumerable<SimpleEvent> GetEvents();

        private void OnSimpleEventHappened(SimpleEvent evt)
        {
            _simpleEventHappened(this, new SimpleEventEventArgs(evt));
        }

        private event EventHandler<SimpleEventEventArgs> _simpleEventHappened = delegate { };
        public event EventHandler<SimpleEventEventArgs> SimpleEventHappened
        {
            add { _simpleEventHappened += value;  }
            remove { _simpleEventHappened -= value; }
        }
    }
}
