namespace Ushahidi.View.Views
{
    partial class MediaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuItemAdd = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.menuItemStop = new System.Windows.Forms.MenuItem();
            this.menuItemSearch = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.button = new Ushahidi.Common.Controls.ImageButton();
            this.textBox = new System.Windows.Forms.TextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.menuItemLoad = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemSearch);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator1);
            this.menuItemAction.MenuItems.Add(this.menuItemLoad);
            this.menuItemAction.MenuItems.Add(this.menuItemStop);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator2);
            this.menuItemAction.MenuItems.Add(this.menuItemAdd);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            this.menuItemAction.Popup += new System.EventHandler(this.OnActionPopup);
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.Text = "Add";
            this.menuItemAdd.Click += new System.EventHandler(this.OnAdd);
            // 
            // menuItemCancel
            // 
            this.menuItemCancel.Text = "Cancel";
            this.menuItemCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // menuItemStop
            // 
            this.menuItemStop.Text = "Stop";
            this.menuItemStop.Click += new System.EventHandler(this.OnStop);
            // 
            // menuItemSearch
            // 
            this.menuItemSearch.Text = "Search";
            this.menuItemSearch.Click += new System.EventHandler(this.OnSearch);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Text = "-";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.button);
            this.panelContent.Controls.Add(this.textBox);
            this.panelContent.Controls.Add(this.webBrowser);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button.BackColor = System.Drawing.Color.Gainsboro;
            this.button.BackColorSelected = System.Drawing.Color.Gray;
            this.button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.button.DisabledImage = null;
            this.button.Image = null;
            this.button.Label = "GO";
            this.button.Location = new System.Drawing.Point(150, 4);
            this.button.Momentary = false;
            this.button.Name = "button";
            this.button.Pressed = false;
            this.button.Size = new System.Drawing.Size(22, 22);
            this.button.TabIndex = 4;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(4, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(142, 22);
            this.textBox.TabIndex = 2;
            this.textBox.GotFocus += new System.EventHandler(this.OnTextBoxGotFocus);
            this.textBox.LostFocus += new System.EventHandler(this.OnTextBoxLostFocus);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(0, 30);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(176, 150);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.OnNavigating);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.OnDocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.OnNavigated);
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Text = "Load";
            this.menuItemLoad.Click += new System.EventHandler(this.OnLoad);
            // 
            // menuItemSeparator2
            // 
            this.menuItemSeparator2.Text = "-";
            // 
            // MediaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panelContent);
            this.Name = "MediaView";
            this.Text = "Media";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemAdd;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private System.Windows.Forms.MenuItem menuItemStop;
        private System.Windows.Forms.MenuItem menuItemSearch;
        private System.Windows.Forms.MenuItem menuItemSeparator1;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.WebBrowser webBrowser;
        private Ushahidi.Common.Controls.ImageButton button;
        private System.Windows.Forms.MenuItem menuItemLoad;
        private System.Windows.Forms.MenuItem menuItemSeparator2;
    }
}