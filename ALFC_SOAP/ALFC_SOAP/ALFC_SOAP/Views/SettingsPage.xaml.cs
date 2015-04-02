using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ALFC_SOAP
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        void Done_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Navigation.PopModalAsync();
        }

        void ExtendedButton_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Navigation.PushModalAsync(new DropdownListPage(btn, btn.CommandParameter.ToString(), ""));
        }
    }
}
