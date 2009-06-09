using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Forms;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Photo select dialog
    /// </summary>
    public class PhotoSelector
    {
        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="sender">sender control</param>
        /// <returns>filepath of photo</returns>
        public static FileInfo ShowDialog(Control sender)
        {
            using (CameraCaptureDialog cameraCaptureDialog = new CameraCaptureDialog())
            {
                cameraCaptureDialog.Owner = sender;
                cameraCaptureDialog.Mode = CameraCaptureMode.Still;
                cameraCaptureDialog.Title = "takeIncidentPhoto".Translate();
                if (cameraCaptureDialog.ShowDialog() == DialogResult.OK)
                {
                    return new FileInfo(cameraCaptureDialog.FileName);
                }
            }
            return null;
        }
    }
}
