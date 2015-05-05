using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ALFC_SOAP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ALFC_SOAP.Droid
{
    
    [Activity( Label = "SOAP Journal", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity :  global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            //SetPage(App.GetMainPage());
        }
    }
}

