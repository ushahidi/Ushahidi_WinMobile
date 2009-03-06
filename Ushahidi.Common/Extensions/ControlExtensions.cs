using System.Collections.Generic;
using System.Windows.Forms;

namespace Ushahidi.Common.Extensions
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> All(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                yield return control;
            }
        }

        public static IEnumerable<Control> Children(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;

                yield return control;
            }
        }

    }
}
