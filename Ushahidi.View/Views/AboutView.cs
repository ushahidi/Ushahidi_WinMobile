﻿using Ushahidi.Model.Extensions;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    public partial class AboutView : BaseView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("about");
            textBlockDescription.Translate("ushahidiDescription");
            textBlockDescription.AdjustHeight();
        }

        public override void Render()
        {
            base.Render();
            textBlockDescription.BackColor = Colors.Background;
        }
    }
}