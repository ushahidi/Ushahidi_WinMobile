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
            View.Locales = DataManager.Locales;
            View.DefaultLocale = DataManager.DefaultLocale;
            View.FirstName = DataManager.FirstName;
            View.LastName = DataManager.LastName;
            View.Email = DataManager.Email;
            View.ShowKeyboard = DataManager.ShowKeyboard;
            View.ImageSizes = DataManager.ImageSizes;
            View.ImageSize = DataManager.ImageSize;
        }

        public override bool Save()
        {
            DataManager.Language = View.Language;
            DataManager.MapType = View.MapType;
            DataManager.DefaultLocale = View.DefaultLocale;
            DataManager.FirstName = View.FirstName;
            DataManager.LastName = View.LastName;
            DataManager.Email = View.Email;
            DataManager.ShowKeyboard = View.ShowKeyboard;
            DataManager.ImageSize = View.ImageSize;
            return DataManager.Save();
        }
    }
}
