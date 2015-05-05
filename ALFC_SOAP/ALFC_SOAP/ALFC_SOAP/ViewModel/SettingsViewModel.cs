using Acr.XamForms.Mobile;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace ALFC_SOAP.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private ISettings currentSettings;
        private string _email;
        private string bibleVersion;
        private string bibleVersionName;
        private string readingPlan;
       

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
            get{ return readingPlan;}
            set 
            {
                Set(ref readingPlan, value);
                AddSetting(Constants.ReadingPlan, value);
            }
        }

        public string BibleVersion
        {
            get
            {
                return bibleVersion;
            }
            set 
            {
                Set("BibleVersion", ref bibleVersion, value);
                AddSetting(Constants.BibleVersion, value);
            }
        }

        public string BibleVersionName
        {
            get
            {
                return bibleVersionName;
            }
            set
            {
                Set("BibleVersionName", ref bibleVersionName, value);
                AddSetting(Constants.BibleVersionName, value);
            }
        }

        public SettingsViewModel(ISettings settings)
        {
            this.currentSettings = settings;
            BibleVersion = currentSettings.Get(Constants.BibleVersion, "NIV");
            BibleVersionName = currentSettings.Get(Constants.BibleVersionName, "New International Version");
            UserEmail = currentSettings.Get(Constants.UserEmail, "gpatnew@hotmail.com");
            ReadingPlan = currentSettings.Get(Constants.ReadingPlan, "Prophecy of Christ");
        }

       

        private void AddSetting(string key, string value)
        {
            this.currentSettings.Set(key, value);
        }
        
    }
}
