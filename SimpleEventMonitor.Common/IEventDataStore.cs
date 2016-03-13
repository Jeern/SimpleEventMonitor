using System.Collections.Generic;

namespace SimpleEventMonitor.Core
{
    public interface IEventDataStore
    {
        void Persist(object evt);
        IEnumerable<SimpleEvent> GetEvents();
    }
}
