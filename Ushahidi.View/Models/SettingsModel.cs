using System.Collections.Generic;
using System.Globalization;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;
using Ushahidi.Model;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Settings Model
    /// </summary>
    public class SettingsModel : BaseModel
    {
        /// <summary>
        /// Server Address
        /// </summary>
        public string ServerAddress
        {
            get { return DataManager.ServerAddress; }
            set { _ServerAdress = value; }
        }private string _ServerAdress;

        /// <summary>
        /// Show keyboard?
        /// </summary>
        public bool ShowKeyboard
        {
            get { return DataManager.ShowKeyboard; }
            set { DataManager.ShowKeyboard = value; }
        }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName
        {
            get { return DataManager.FirstName; }
            set { DataManager.FirstName = value; }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName
        {
            get { return DataManager.LastName; }
            set { DataManager.LastName = value; }
        }

        /// <summary>
        /// Languages
        /// </summary>
        public IEnumerable<CultureInfo> Languages
        {
            get { return LanguageManager.Languages; }
        }

        /// <summary>
        /// Language
        /// </summary>
        public CultureInfo Language
        {
            get { return LanguageManager.Language; }
            set { LanguageManager.Language = value; }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return DataManager.Email; }
            set { DataManager.Email = value; }
        }

        public override bool Save()
        {
            Log.Info("SettingsModel.Save()");
            if (_ServerAdress.HasText() && Language != null)
            {
                DataManager.ServerAddress = _ServerAdress;
                DataManager.Language = Language.Name;
                return DataManager.Save();
            }
            return false;
        }
    }
}
