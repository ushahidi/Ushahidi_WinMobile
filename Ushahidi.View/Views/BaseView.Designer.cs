namespace Ushahidi.View.Views
{
    public partial class BaseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseView));
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItemAction = new System.Windows.Forms.MenuItem();
            this.menuItemMenu = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncident = new System.Windows.Forms.MenuItem();
            this.menuItemIncidentList = new System.Windows.Forms.MenuItem();
            this.menuItemIncidentMap = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemSynchronize = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            this.menuItemSettings = new System.Windows.Forms.MenuItem();
            this.menuItemWebsite = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator3 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItemAction);
            this.mainMenu.MenuItems.Add(this.menuItemMenu);
            // 
            // menuItemAction
            // 
            this.menuItemAction.Text = "";
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.MenuItems.Add(this.menuItemAddIncident);
            this.menuItemMenu.MenuItems.Add(this.menuItemIncidentList);
            this.menuItemMenu.MenuItems.Add(this.menuItemIncidentMap);
            this.menuItemMenu.MenuItems.Add(this.menuItemSeparator1);
            this.menuItemMenu.MenuItems.Add(this.menuItemSynchronize);
            this.menuItemMenu.MenuItems.Add(this.menuItemSeparator2);
            this.menuItemMenu.MenuItems.Add(this.menuItemSettings);
            this.menuItemMenu.MenuItems.Add(this.menuItemWebsite);
            this.menuItemMenu.MenuItems.Add(this.menuItemSeparator3);
            this.menuItemMenu.MenuItems.Add(this.menuItemExit);
            this.menuItemMenu.Text = "Menu";
            this.menuItemMenu.Popup += new System.EventHandler(this.OnMenuPopup);
            // 
            // menuItemAddIncident
            // 
            this.menuItemAddIncident.Text = "Add Incident";
            this.menuItemAddIncident.Click += new System.EventHandler(this.OnAddIncident);
            // 
            // menuItemIncidentList
            // 
            this.menuItemIncidentList.Text = "Incident List";
            this.menuItemIncidentList.Click += new System.EventHandler(this.OnIncidentList);
            // 
            // menuItemIncidentMap
            // 
            this.menuItemIncidentMap.Text = "Incident Map";
            this.menuItemIncidentMap.Click += new System.EventHandler(this.OnIncidentMap);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemSynchronize
            // 
            this.menuItemSynchronize.Text = "Synchronize";
            this.menuItemSynchronize.Click += new System.EventHandler(this.OnSync);
            // 
            // menuItemSeparator2
            // 
            this.menuItemSeparator2.Text = "-";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Text = "Settings";
            this.menuItemSettings.Click += new System.EventHandler(this.OnSettings);
            // 
            // menuItemWebsite
            // 
            this.menuItemWebsite.Text = "Website";
            this.menuItemWebsite.Click += new System.EventHandler(this.OnWebsite);
            // 
            // menuItemSeparator3
            // 
            this.menuItemSeparator3.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.OnExit);
            // 
            // BaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "BaseView";
            this.Text = "Ushahidi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemSeparator1;
        private System.Windows.Forms.MenuItem menuItemSeparator2;
        public System.Windows.Forms.MenuItem menuItemAction;
        public System.Windows.Forms.MenuItem menuItemMenu;
        public System.Windows.Forms.MenuItem menuItemExit;
        public System.Windows.Forms.MenuItem menuItemAddIncident;
        public System.Windows.Forms.MenuItem menuItemIncidentMap;
        public System.Windows.Forms.MenuItem menuItemIncidentList;
        public System.Windows.Forms.MenuItem menuItemSettings;
        public System.Windows.Forms.MenuItem menuItemWebsite;
        public System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemSynchronize;
        private System.Windows.Forms.MenuItem menuItemSeparator3;
    }
}