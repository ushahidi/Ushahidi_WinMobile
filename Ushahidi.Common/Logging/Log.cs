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

        public static void Info(string text, params object[] parameters)
        {
            Instance.Info(text, parameters);
        }

        public static void Info(string sender, string text, params object[] parameters)
        {
            Instance.Info(string.Format("{0} {1}", sender, text), parameters);
        }

        public static void Exception(string text, params object[] parameters)
        {
            Instance.Exception(text, parameters);
        }

        public static void Exception(string sender, string text, params object[] parameters)
        {
            Instance.Exception(string.Format("{0} {1}", sender, text), parameters);
        }

        public static void Critical(string text, params object[] parameters)
        {
            Instance.Critical(text, parameters);
        }

        public static void Critical(string sender, string text, params object[] parameters)
        {
            Instance.Critical(string.Format("{0} {1}", sender, text), parameters);
        }
    }
}
