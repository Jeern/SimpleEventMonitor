using System;
using Newtonsoft.Json;

namespace SimpleEventMonitor.Common
{
    public class SimpleEvent
    {
        public string Name { get; set; }
        public string FullName { get; set; }

        public DateTime LocalTime => UtcTime.ToLocalTime();

        public string FormattedLocalTime
            => $"{LocalTime.ToLongDateString()} {LocalTime.ToLongTimeString()}.{LocalTime.ToString("fff")}";

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
            var type = systemEvent.GetType();
            Name = type.Name;
            FullName = type.FullName;
        }
    }
}
