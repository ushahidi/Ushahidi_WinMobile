using System;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Disposable wait cursor
    /// </summary>
    public class WaitCursor : IDisposable
    {
        private readonly Cursor _WaitCursor;

        public WaitCursor() : this(Cursors.WaitCursor) { }
        public WaitCursor(Cursor newCursor)
        {
            _WaitCursor = Cursor.Current;
            Cursor.Current = newCursor;
        }

        public void Dispose()
        {
            Cursor.Current = _WaitCursor;
        }
    }
}
