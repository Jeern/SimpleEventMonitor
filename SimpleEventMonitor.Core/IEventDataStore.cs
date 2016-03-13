using System;
using System.Collections.Generic;

namespace SimpleEventMonitor.Core
{
    public interface IEventDataStore
    {
        void Persist(object evt);
        IEnumerable<SimpleEvent> GetEvents(int startIdx = 0, int endIdx = int.MaxValue);
        /// <summary>
        /// For paging when I get around to it
        /// </summary>
        int TotalCount { get; }
    }
}
