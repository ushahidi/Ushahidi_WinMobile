using System.Diagnostics;

namespace Ushahidi.Common.Logging
{
    public class DebugLog : ILog
    {
        public void Info(string text, params object[] parameters)
        {
            Debug.WriteLine(string.Format(text, parameters), "Info");
        }

        public void Exception(string text, params object[] parameters)
        {
            Debug.WriteLine(string.Format(text, parameters), "Exception");
        }

        public void Critical(string text, params object[] parameters)
        {
            Debug.WriteLine(string.Format(text, parameters), "Critical");
        }

    }
}
