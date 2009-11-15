using Ushahidi.Common;
using Ushahidi.Model;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Settings View Controller
    /// </summary>
    public class SettingsViewController : BaseViewController<SettingsView>
    {
        public override void Load(object[] parameters)
        {
            View.Version = Runtime.AppVersion;
            View.Languages = DataManager.Languages;
            View.Language = DataManager.Language;
            View.MapTypes = DataManager.MapTypes;
            View.MapType = DataManager.MapType;
            View.FirstName = DataManager.FirstName;
            View.LastName = DataManager.LastName;
            View.Email = DataManager.Email;
            View.ShowKeyboard = DataManager.ShowKeyboard;
        }

        public override bool Save()
        {
            DataManager.Language = View.Language;
            DataManager.MapType = View.MapType;
            DataManager.FirstName = View.FirstName;
            DataManager.LastName = View.LastName;
            DataManager.Email = View.Email;
            DataManager.ShowKeyboard = View.ShowKeyboard;
            return DataManager.Save();
        }
    }
}
