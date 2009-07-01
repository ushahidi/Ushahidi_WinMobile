using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;
using Ushahidi.Model.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Media View
    /// </summary>
    public partial class MediaView : BaseView
    {
        public MediaView()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();
            button.Click += OnLoadOrStop;
            button.Height = textBox.Height;
            Keyboard.KeyboardChanged += OnKeyboardChanged;
            button.Font.ToBold();
            panelContent.BackColor = Colors.Background;
            menuItemAddIncident.Enabled =
            menuItemIncidentList.Enabled =
            menuItemWebsite.Enabled =
            menuItemSettings.Enabled = false;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemAction.Translate("action");
            menuItemSearch.Translate("search");
            menuItemLoad.Translate("load");
            menuItemStop.Translate("stop");
            menuItemAdd.Translate("add");
            menuItemCancel.Translate("cancel");
            if (MediaType == MediaType.Audio)
            {
                this.Translate("addAudioLink");
            }
            else if (MediaType == MediaType.News)
            {
                this.Translate("addNewsLink");
            }
            else if (MediaType == MediaType.Video)
            {
                this.Translate("addVideoLink");
            }
            else if (MediaType == MediaType.Photo)
            {
                this.Translate("addPhoto");
            }
            else
            {
                this.Translate("website");
            }
        }

        public MediaType MediaType
        {
            get { return _MediaType; }
            set { _MediaType = value; }
        }private MediaType _MediaType = MediaType.Unknown;

        public string URL
        {
            get { return textBox.Text; }
            set
            {
                textBox.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    webBrowser.DocumentText = string.Empty;
                }
                else
                {
                    webBrowser.Url = new Uri(value);
                }
            }
        }

        private void OnAdd(object sender, EventArgs e)
        {
            Log.Info("MediaView.OnAdd");
            OnBack(new Media {ID = -1, Link = textBox.Text, Type = (int)MediaType, Upload = true});
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Log.Info("MediaView.OnCancel");
            OnBack(new Media());
        }

        private void OnSearch(object sender, EventArgs e)
        {
            Log.Info("MediaView.OnSearch");
            webBrowser.Navigate(new Uri("http://www.google.com/xhtml"));
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Log.Info("MediaView.OnLoad");
            webBrowser.Navigate(new Uri(textBox.Text));
        }

        private void OnLoadOrStop(object sender, EventArgs e)
        {
            Log.Info("MediaView.OnLoadOrStop");
            if (webBrowser.IsBusy)
            {
                webBrowser.Stop();
            }
            else if (string.IsNullOrEmpty(textBox.Text) == false)
            {
                webBrowser.Navigate(new Uri(textBox.Text));
            }
        }

        private void OnStop(object sender, EventArgs e)
        {
            Log.Info("MediaView.OnStop");
            webBrowser.Stop();
        }

        private void OnActionPopup(object sender, EventArgs e)
        {
            menuItemAdd.Enabled =
            menuItemLoad.Enabled = Uri.IsWellFormedUriString(textBox.Text, UriKind.Absolute) && textBox.Text.StartsWith("http");
            menuItemStop.Enabled = webBrowser.IsBusy;
        }

        private void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Log.Info("MediaView.OnNavigating");
            button.Label = "X";
        }

        private void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Log.Info("MediaView.OnNavigated");
            textBox.Text = e.Url.ToString();
        }

        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Log.Info("MediaView.OnDocumentCompleted");
            button.Label = "GO";
        }

        private void OnTextBoxGotFocus(object sender, EventArgs e)
        {
            textBox.BackColor = Color.LightYellow;
        }

        private void OnTextBoxLostFocus(object sender, EventArgs e)
        {
            textBox.BackColor = Color.White;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), 0, webBrowser.Top - 1, ClientRectangle.Width, webBrowser.Top - 1);
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = Height - args.Bounds.Height;
        }
    }
}