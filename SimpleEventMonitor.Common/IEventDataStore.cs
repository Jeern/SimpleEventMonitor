using System;
using System.Collections.Generic;

namespace SimpleEventMonitor.Common
{
    public interface IEventDataStore
    {
        void Persist(object evt);
        IEnumerable<SimpleEvent> GetEvents();
    }
}
