using System.Diagnostics;

namespace Ushahidi.Common.Logging
{
    public class DebugLog : ILog
    {
        public void Info(string format, params object[] parameters)
        {
            Debug.WriteLine(string.Format(format, parameters), "Info");
        }

        public void Exception(string format, params object[] parameters)
        {
            Debug.WriteLine(string.Format(format, parameters), "Exception");
        }

        public void Critical(string format, params object[] parameters)
        {
            Debug.WriteLine(string.Format(format, parameters), "Critical");
        }

    }
}
