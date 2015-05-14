using ALFC_SOAP.Common;
using ALFC_SOAP.Data;
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
           //App.SoapFolder.Refresh();
            SOAPData db = new SOAPData();
           this.ItemsSource = db.GetItems();
           this.ItemTemplate = BaseListItemTemplate.TextCell();
           this.VerticalOptions = LayoutOptions.FillAndExpand;
           this.ItemTemplate.SetBinding(TextCell.TextProperty, "Identifier");

            // Handle item selection for editing and deleting.
           this.ItemSelected += (sender, args) =>
            {
                if (args.SelectedItem != null)
                {
                    // Deselect the item.
                    this.SelectedItem = null;

                    // Navigate to SOAP page.
                    var soap = (Soap)args.SelectedItem;
                    this.Navigation.PushAsync(new SoapPage(soap, soap.Identifier, true));
                }
            };
        }

        
    }
}
