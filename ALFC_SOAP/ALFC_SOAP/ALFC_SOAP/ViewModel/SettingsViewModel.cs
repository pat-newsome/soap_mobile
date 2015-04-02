using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using Acr.XamForms.Mobile;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace ALFC_SOAP.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private ISettings currentSettings;
        private string _email;
        private string _bibleVersion;
        private string _readingPlan;
       

        public Color EntryTextColor { get{ return Common.AppColors.Black;}}
        public Color EntryBgColor { get { return Common.AppColors.White; } }
        public string UserEmail
        {
            get{ return _email;}
            set
            {
                Set(ref _email, value);
                AddSetting(Constants.UserEmail, value);
            }
        }

        public string ReadingPlan
        {
            get{ return _readingPlan;}
            set 
            {
                Set(ref _readingPlan, value);
                AddSetting(Constants.ReadingPlan, value);
            }
        }

        public string BibleVersion
        {
            get
            {
                return _bibleVersion;
            }
            set 
            {
                Set(ref _bibleVersion, value);

                AddSetting(Constants.BibleVersion, value);
            }
        }

        
        public SettingsViewModel(ISettings settings)
        {
            this.currentSettings = settings;
            BibleVersion = currentSettings.Get(Constants.BibleVersion, "NIV");
            UserEmail = currentSettings.Get(Constants.UserEmail, "gpatnew@hotmail.com");
            ReadingPlan = currentSettings.Get(Constants.ReadingPlan, "Prophecy of Christ");
        }

       

        private void AddSetting(string key, string value)
        {
            this.currentSettings.Set(key, value);
        }
        
    }
}
