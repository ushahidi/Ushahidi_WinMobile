﻿namespace Ushahidi.View.Views
{
    partial class PhotoView
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
            this.SuspendLayout();
            // 
            // IncidentPhotoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = false;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.KeyPreview = true;
            this.Name = "PhotoView";
            this.Text = "Incident Photo";
            this.Click += new System.EventHandler(OnClick);
            this.DoubleClick += new System.EventHandler(OnClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(OnKeyDown);
            this.ResumeLayout(false);

        }

        #endregion


    }
}