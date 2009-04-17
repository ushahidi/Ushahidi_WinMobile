using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Settings View Controller
    /// </summary>
    public class SettingsViewController : BaseViewController<SettingsView, SettingsModel>
    {
        /// <summary>
        /// Save error caption
        /// </summary>
        public override string SaveErrorCaption
        {
            get { return "Missing Fields"; }
        }

        /// <summary>
        /// Save error message
        /// </summary>
        public override string SaveErrorMessage
        {
            get { return "Please verify all required fields are entered"; }
        }

        public override void Load(object[] parameters)
        {
            View.Languages = Model.Languages;
            View.Language = Model.Language;
            View.ServerAddress = Model.ServerAddress;
            View.ShowKeyboard = Model.ShowKeyboard;
            View.FirstName = Model.FirstName;
            View.LastName = Model.LastName;
            View.Email = Model.Email;
        }

        public override bool Save()
        {
            if (View.ShouldSave)
            {
                Model.Language = View.Language;
                Model.ServerAddress = View.ServerAddress;
                Model.ShowKeyboard = View.ShowKeyboard;
                Model.FirstName = View.FirstName;
                Model.LastName = View.LastName;
                Model.Email = View.Email;
                return Model.Save();
            }
            return true;
        }
    }
}
