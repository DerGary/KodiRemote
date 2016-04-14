using System.Runtime.CompilerServices;
using Windows.Storage;


namespace KodiRemote.Code.Utils {
    /// <summary>
    /// This class can be used to save Settings of the app in the ApplicationData of the current app provided by Microsoft.
    /// To extend this class one can derive a new app specific class from this base class.
    /// With Method SetSetting a Setting with a simple object can be saved. It can be loaded again with the GetSetting Method.
    /// To Save a more complex Data SetSettingSerialize is used. This method serialises the given Data to json and saves the json as a string in the Application Data.
    /// With GetSettingDeserialize a serialised Setting can be recovered.
    /// In SettingsAccess username and first/lastname of a user will automatically be saved if the app uses the Login Page provided in the soliver universal tools.
    /// </summary>
    public abstract class SettingsAccess {

        /// <summary>
        /// gets the setting with the provided key
        /// </summary>
        /// <param name="key">the key of the settings that shall be returned</param>
        /// <returns>the object that was saved, or null if it didn't exist</returns>
        public static object GetSetting(string key) {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key)) {
                return ApplicationData.Current.LocalSettings.Values[key];
            } else {
                return null;
            }
        }

        /// <summary>
        /// gets the setting with the provided key and deserializes it to the given type T
        /// </summary>
        /// <typeparam name="T">the type and return type of the setting</typeparam>
        /// <param name="key">the key of the settings that shall be returned</param>
        /// <returns>the object that was saved with type T, or null if it didn't exist</returns>
        public static T GetSettingDeserialize<T>(string key) where T : new() {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key)) {
                string json = (string)ApplicationData.Current.LocalSettings.Values[key];
                if (json != null) {
                    return JsonSerializer.FromJson<T>(json);
                }
            }
            return default(T);
        }

        /// <summary>
        /// sets the setting with the given key to the object value
        /// </summary>
        /// <param name="key">the key of the setting that shall be saved</param>
        /// <param name="value">the value the saved setting should have</param>
        public static void SetSetting(string key, object value) {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }

        /// <summary>
        /// sets the setting with the given to a json string representing the object value
        /// </summary>
        /// <param name="key">the key of the setting that shall be saved</param>
        /// <param name="value">the value the saved setting should have</param>
        public static void SetSettingSerialize(string key, object value) {
            if (value != null) {
                ApplicationData.Current.LocalSettings.Values[key] = JsonSerializer.ToJson(value);
            } else {
                ApplicationData.Current.LocalSettings.Values[key] = null;
            }
        }

        public delegate void SettingsChangedEventHandler(string propertyName);
        /// <summary>
        /// EventHandler in case some settings were changed
        /// </summary>
        public static event SettingsChangedEventHandler SettingsChanged;
        /// <summary>
        /// Raises the settings changed event with the propertyName as param
        /// </summary>
        protected static void RaiseSettingsChanged([CallerMemberName] string propertyName = null) {
            if (SettingsChanged != null) {
                SettingsChanged(propertyName);
            }
        }

        //private static string _username;
        //public static string Username {
        //    get {
        //        if (_username == null) {
        //            _username = GetSetting(nameof(Username)) as string;
        //        }
        //        return _username;
        //    }
        //    set {
        //        _username = value;
        //        SetSetting(nameof(Username), value);
        //    }
        //}

        //private static string _password;
        //public static string Password {
        //    get {
        //        if (_password == null) {
        //            _password = GetSetting(nameof(Password)) as string;
        //        }
        //        return _password;
        //    }
        //    set {
        //        _password = value;
        //        SetSetting(nameof(Password), value);
        //    }
        //}
        //public static bool LoggedIn {
        //    get {
        //        return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        //    }
        //}
    }
}
