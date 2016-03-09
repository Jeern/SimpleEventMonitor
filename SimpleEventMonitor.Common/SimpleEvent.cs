using System;
using Newtonsoft.Json;

namespace SimpleEventMonitor.Common
{
    public class SimpleEvent
    {
        public string Name => SystemEvent.GetType().Name;
        public string FullName => SystemEvent.GetType().FullName;

        public DateTime LocalTime => UtcTime.ToLocalTime();

        public DateTime UtcTime { get; set; }
        public object SystemEvent { get; set; }
        public string Content => JsonConvert.SerializeObject(SystemEvent);

        public SimpleEvent()
        {
            //For serialization
        }

        public SimpleEvent(object systemEvent)
        {
            SystemEvent = systemEvent;
            UtcTime = DateTime.UtcNow;
        }
    }
}
