using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Forms;
using Microsoft.WindowsMobile.Status;
using Ushahidi.Common.Controls;
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
            return ShowDialog(sender, null);
        }

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="sender">sender control</param>
        /// <param name="resolution">image size</param>
        /// <returns>filepath of photo</returns>
        public static FileInfo ShowDialog(Control sender, ImageSize resolution)
        {
            if (SystemState.CameraPresent && SystemState.CameraEnabled)
            {
                using (CameraCaptureDialog cameraCaptureDialog = new CameraCaptureDialog())
                {
                    cameraCaptureDialog.Owner = sender;
                    cameraCaptureDialog.Mode = CameraCaptureMode.Still;
                    cameraCaptureDialog.StillQuality = CameraCaptureStillQuality.Normal;
                    cameraCaptureDialog.Title = "takeIncidentPhoto".Translate();
                    if (resolution != null)
                    {
                        cameraCaptureDialog.Resolution = resolution.ToSize();
                    }
                    if (cameraCaptureDialog.ShowDialog() == DialogResult.OK)
                    {
                        return new FileInfo(cameraCaptureDialog.FileName);
                    }
                }    
            }
            else
            {
                using(OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "JPEG (*.jpg,*.jpeg)|*.jpg;*.jpeg";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        return new FileInfo(openFileDialog.FileName);
                    }
                }
            }
            return null;
        }
    }
}