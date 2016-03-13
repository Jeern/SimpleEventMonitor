using System;

namespace SimpleEventMonitor.Sample.Sender
{
    public class SomeEvent
    {
        public SomeEvent()
        {
            Id = Guid.NewGuid();
            HappenedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}
