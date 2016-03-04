using System;

namespace SimpleEventMonitor.Common
{
    public class SimpleEventEventArgs : EventArgs
    {
        public SimpleEvent Evt { get; }

        public SimpleEventEventArgs(SimpleEvent evt)
        {
            Evt = evt;
        }
    }
}
