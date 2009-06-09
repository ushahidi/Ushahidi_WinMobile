using Ushahidi.Common.MVC;
using Ushahidi.Model.Models;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident Map View
    /// </summary>
    public partial class MapView : BaseView
    {
        public MapView()
        {
            InitializeComponent();    
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("incidentMap");
            comboBoxCategories.Translate("category");
        }

        /// <summary>
        /// Categories
        /// </summary>
        public Models<Category> Categories
        {
            set { comboBoxCategories.DataSource = value; }
        }
    }
}
