namespace Ushahidi.Common.Logging
{
    public interface ILog
    {
        void Info(string text, params object[] parameters);
        
        void Exception(string text, params object[] parameters);
        
        void Critical(string text, params object[] parameters);
    }
}
