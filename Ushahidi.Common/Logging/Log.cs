using System;

namespace Ushahidi.Common.Logging
{
    public static class Log
    {
        public static ILog Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DebugLog();
                }
                return _Instance;
            }
            set { _Instance = value;}
        }private static ILog _Instance;

        public static void Info(string format, params object[] parameters)
        {
            try
            {
                Instance.Info(format, parameters);
            }
            catch
            {
                Console.WriteLine("Info: " + format + " " + parameters);
            }
        }

        public static void Info(string sender, string format, params object[] parameters)
        {
            try
            {
                Instance.Info(string.Format("{0} {1}", sender, format), parameters);
            }
            catch
            {
                Console.WriteLine("Info: " + sender + " " + format + " " + parameters);
            }
        }

        public static void Exception(string format, params object[] parameters)
        {
            try
            {
                Instance.Exception(format, parameters);
            }
            catch
            {
                Console.WriteLine("Info: " + format + " " + parameters);
            } 
        }

        public static void Exception(string sender, string format, params object[] parameters)
        {
            try
            {
                Instance.Exception(string.Format("{0} {1}", sender, format), parameters);
            }
            catch 
            {
                Console.WriteLine("Exception: " + sender + " " + format + " " + parameters);        
            }
        }

        public static void Critical(string format, params object[] parameters)
        {
            try
            {
                Instance.Critical(format, parameters);
            }
            catch
            {
                Console.WriteLine("Critical: " + format + " " + parameters);   
            }            
        }

        public static void Critical(string sender, string format, params object[] parameters)
        {
            try
            {
                Instance.Critical(string.Format("{0} {1}", sender, format), parameters);
            }
            catch
            {
                Console.WriteLine("Critical: " + sender + " " + format + " " + parameters);
            }
        }
    }
}
