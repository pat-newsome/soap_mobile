using ALFC_SOAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP.Views
{
    class JournalEntriesView :ListView
    {

        public JournalEntriesView()
        {
            App.SoapFolder.Refresh();
           this.ItemsSource = App.SoapFolder.SoapMessages;
           this.ItemTemplate = new DataTemplate(typeof(TextCell));
           this.VerticalOptions = LayoutOptions.FillAndExpand;
           this.ItemTemplate.SetBinding(TextCell.TextProperty, "Identifier");

            // Handle item selection for editing and deleting.
           this.ItemSelected += (sender, args) =>
            {
                if (args.SelectedItem != null)
                {
                    // Deselect the item.
                    this.SelectedItem = null;

                    // Navigate to NotePage.
                    var soap = (Soap)args.SelectedItem;
                    this.Navigation.PushAsync(new SoapPage(soap, soap.Identifier, true));
                }
            };
        }
    }
}
