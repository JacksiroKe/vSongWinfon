
using System;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace vSongBook
{
    public class AppSettings
    {

        // Our isolated storage settings
        IsolatedStorageSettings settings;

        // The isolated storage key names of our settings
        const string InstalledonSettingKeyName = "InstalledonSetting";
        const string UsermobileSettingKeyName = "UsermobileSetting";
        const string UseridSettingKeyName = "UseridSetting";
        const string ExpiresonSettingKeyName = "ExpiresonSetting";
        const string PaidforSettingKeyName = "PaidforSetting";
        const string InitialSetupSettingKeyName = "InitialSetupSetting";
        const string LoggedinSettingKeyName = "LoggedinSetting";
        const string SeenTutorialSettingKeyName = "SeenTutorialSetting";
        const string FirstTimeSettingKeyName = "FirstTimeSetting";
        const string ListBoxSettingKeyName = "ListBoxSetting";
        const string SkippedRatingSettingKeyName = "SkippedRatingSetting";
        const string RatedVsbwpSettingKeyName = "RatedVsbwpSetting";
        const string CurrSongSettingKeyName = "CurrSongSetting";
        const string CurrFavourSettingKeyName = "CurrFavourSetting";
        const string CurrMysongSettingKeyName = "CurrMysongSetting";
        const string FontSizeSettingKeyName = "FontSizeSetting";
        const string FontTypeSettingKeyName = "FontTypeSetting";
        const string Hint1SettingKeyName = "Hint1Setting";
        const string Hint2SettingKeyName = "Hint2Setting";
        const string Hint3SettingKeyName = "Hint3Setting";
        const string Hint4SettingKeyName = "Hint4Setting";
        const string Hint5SettingKeyName = "Hint5Setting";
        const string Hint6SettingKeyName = "Hint6Setting";
        const string Hint7SettingKeyName = "Hint7Setting";

        // The default value of our settings
        const long InstalledonSettingDefault = 0;
        const long ExpiresonSettingDefault = 0;
        const string UsermobileSettingDefault = "1234567890";
        const int UseridSettingDefault = 0;
        const bool PaidforSettingDefault = false;
        const bool InitialSetupSettingDefault = false;
        const bool LoggedinSettingDefault = false;
        const bool SeenTutorialSettingDefault = false;
        const bool FirstTimeSettingDefault = false;
        const int ListBoxSettingDefault = 0;
        const long SkippedRatingSettingDefault = 0;
        const bool RatedVsbwpSettingDefault = false;
        const int CurrSongSettingDefault = 1;
        const int CurrFavourSettingDefault = 1;
        const int CurrMysongSettingDefault = 1;
        const int FontSizeSettingDefault = 30;
        const string FontTypeSettingDefault = "";
        const bool Hint1SettingDefault = false;
        const bool Hint2SettingDefault = false;
        const bool Hint3SettingDefault = false;
        const bool Hint4SettingDefault = false;
        const bool Hint5SettingDefault = false;
        const bool Hint6SettingDefault = false;
        const bool Hint7SettingDefault = false;

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings()
        {
            try
            {
                // Get the settings for this application.
                settings = IsolatedStorageSettings.ApplicationSettings;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }


        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="valueType"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (valueType)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }

            return value;
        }


        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }

        public long ExpiresonSetting
        {
            get
            {
                return GetValueOrDefault<long>(ExpiresonSettingKeyName, ExpiresonSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(ExpiresonSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        
        public long InstalledonSetting
        {
            get
            {
                return GetValueOrDefault<long>(InstalledonSettingKeyName, InstalledonSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(InstalledonSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public long SkippedRatingSetting
        {
            get
            {
                return GetValueOrDefault<long>(SkippedRatingSettingKeyName, SkippedRatingSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SkippedRatingSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int FontSizeSetting
        {
            get
            {
                return GetValueOrDefault<int>(FontSizeSettingKeyName, FontSizeSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(FontSizeSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        public string FontTypeSetting
        {
            get
            {
                return GetValueOrDefault<string>(FontTypeSettingKeyName, FontTypeSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(FontTypeSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set a Paidfor Setting Key.
        /// </summary>
        public bool PaidforSetting
        {
            get
            {
                return GetValueOrDefault<bool>(PaidforSettingKeyName, PaidforSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(PaidforSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        public int ListBoxSetting
        {
            get
            {
                return GetValueOrDefault<int>(ListBoxSettingKeyName, ListBoxSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(ListBoxSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public bool LoggedinSetting
        {
            get
            {
                return GetValueOrDefault<bool>(LoggedinSettingKeyName, LoggedinSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(LoggedinSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public bool SeenTutorialSetting
        {
            get
            {
                return GetValueOrDefault<bool>(SeenTutorialSettingKeyName, SeenTutorialSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SeenTutorialSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public bool InitialSetupSetting
        {
            get
            {
                return GetValueOrDefault<bool>(InitialSetupSettingKeyName, InitialSetupSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(InitialSetupSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public bool FirstTimeSetting
        {
            get
            {
                return GetValueOrDefault<bool>(FirstTimeSettingKeyName, FirstTimeSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(FirstTimeSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public bool RatedVsbwpSetting
        {
            get
            {
                return GetValueOrDefault<bool>(RatedVsbwpSettingKeyName, RatedVsbwpSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(RatedVsbwpSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a CurrSong Setting Key.
        /// </summary>
        public int CurrSongSetting
        {
            get
            {
                return GetValueOrDefault<int>(CurrSongSettingKeyName, CurrSongSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrSongSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a Userid Setting Key.
        /// </summary>
        public int UseridSetting
        {
            get
            {
                return GetValueOrDefault<int>(UseridSettingKeyName, UseridSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(UseridSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a Usermobile Setting Key.
        /// </summary>
        public string UsermobileSetting
        {
            get
            {
                return GetValueOrDefault<string>(UsermobileSettingKeyName, UsermobileSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(UsermobileSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int CurrFavourSetting
        {
            get
            {
                return GetValueOrDefault<int>(CurrFavourSettingKeyName, CurrFavourSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrFavourSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int CurrMysongSetting
        {
            get
            {
                return GetValueOrDefault<int>(CurrMysongSettingKeyName, CurrMysongSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrMysongSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        

        public bool Hint1Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint1SettingKeyName, Hint1SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint1SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint2Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint2SettingKeyName, Hint2SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint2SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint3Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint3SettingKeyName, Hint3SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint3SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint4Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint4SettingKeyName, Hint4SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint4SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint5Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint5SettingKeyName, Hint5SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint5SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint6Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint6SettingKeyName, Hint6SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint6SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint7Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint7SettingKeyName, Hint7SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint7SettingKeyName, value))
                {
                    Save();
                }
            }
        }

    }
}
