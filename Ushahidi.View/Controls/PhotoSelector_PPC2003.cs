using System;
using System.IO;
using System.Windows.Forms;

namespace Ushahidi.View.Controls
{
    public class PhotoSelector
    {
        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="sender">sender control</param>
        /// <returns>filepath of photo</returns>
        public static FileInfo ShowDialog(Control sender)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "*.jpg";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new FileInfo(openFileDialog.FileName);
                }
            }
            return null;
        }
    }
}
