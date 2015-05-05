using System.ComponentModel;
using Xamarin.Forms;
using GalaSoft.MvvmLight;
namespace ALFC_SOAP.Common
{
    public class ExtendedButton : Button
    {
        object buttonValue;
        
        public object Value {
            get { return buttonValue;}
            set { buttonValue = value;}
        }
    }
}
