using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Model interface
    /// </summary>
    public interface IModel : IDisposable
    {
        int ID { get; set; }

        bool Upload { get; set; }

        string FilePath { get; set; }
    }
}
