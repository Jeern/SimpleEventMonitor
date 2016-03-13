using System;
using System.Collections.Generic;

namespace SimpleEventMonitor.Core
{
    public interface IEventDataStore
    {
        void Publish(object evt);
        void PersistAndPublish(object evt);
        IEnumerable<SimpleEvent> GetEvents(long startIdx = 0, long endIdx = long.MaxValue);
        /// <summary>
        /// For paging when I get around to it
        /// </summary>
        long TotalCount { get; }
    }
}
