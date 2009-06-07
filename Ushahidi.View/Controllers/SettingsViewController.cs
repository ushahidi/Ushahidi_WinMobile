using Ushahidi.Model;
using Ushahidi.View.Languages;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Settings View Controller
    /// </summary>
    public class SettingsViewController : BaseViewController<SettingsView>
    {
        /// <summary>
        /// Save error caption
        /// </summary>
        public override string SaveErrorCaption
        {
            get { return "missingFields".Translate(); }
        }

        /// <summary>
        /// Save error message
        /// </summary>
        public override string SaveErrorMessage
        {
            get { return "missingFieldsVerify".Translate(); }
        }

        public override void Load(object[] parameters)
        {
            View.Languages = LanguageManager.Languages;
            View.Language = LanguageManager.Language;
            View.ShowKeyboard = DataManager.ShowKeyboard;
            View.FirstName = DataManager.FirstName;
            View.LastName = DataManager.LastName;
            View.Email = DataManager.Email;
        }

        public override bool Save()
        {
            if (View.ShouldSave)
            {
                LanguageManager.Language = View.Language;
                DataManager.Language = View.Language.Name;
                DataManager.ShowKeyboard = View.ShowKeyboard;
                DataManager.FirstName = View.FirstName;
                DataManager.LastName = View.LastName;
                DataManager.Email = View.Email;
                return DataManager.Save();
            }
            return true;
        }
    }
}
