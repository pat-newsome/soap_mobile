using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Acr.XamForms.UserDialogs.iOS;
using Acr.XamForms.Mobile.iOS.Net;

namespace ALFC_SOAP.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
            new UserDialogService();
            new NetworkService();
         

        }
    }
}
