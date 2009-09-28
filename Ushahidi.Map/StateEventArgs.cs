using System;

namespace Ushahidi.Map
{
    public class StateEventArgs : EventArgs
    {
        public StateEventArgs(string name)
        {
            Name = name;
        }

        public StateEventArgs(string name, string deviceState, string serviceState)
        {
            Name = name;
            DeviceState = deviceState;
            ServiceState = serviceState;
        }

        public string Name { get; private set; }
        public string DeviceState { get; private set; }
        public string ServiceState { get; private set; }

    }
}
