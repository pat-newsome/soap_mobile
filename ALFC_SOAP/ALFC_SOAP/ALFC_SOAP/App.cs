using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class App
    {
        public static Page GetMainPage()
        {

            return new NavigationPage(new HomePage());
            //return new ContentPage
            //{
            //    Content = new Label
            //    {
            //        Text = "SOAP  Journal",
            //        VerticalOptions = LayoutOptions.CenterAndExpand,
            //        HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    },
            //};
        }
    }
}
