using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class App
    {

        static SoapFolder soapFolder = new SoapFolder();

        internal static readonly string TransientFilename = "TempSOAP.save";

        internal static SoapFolder SoapFolder
        {
            get { return soapFolder; }
        }
        public static Page GetMainPage()
        {

            return new NavigationPage(new HomePage());
          
        }
    }
}
