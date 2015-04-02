using ALFC_SOAP.Common;
using ALFC_SOAP.Model;
using ALFC_SOAP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class DropdownListPage : ContentPage
    {
        public DropdownListPage(Button button, string listview, string limitValue = "")
        {
            var list = GetListView(listview, limitValue);
            Content = list;
            this.BackgroundColor = AppColors.White;
            list.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                SelectListItem selectItem = (SelectListItem)e.Item;
                button.Text = !string.IsNullOrEmpty(selectItem.Name) ? selectItem.Name : Constants.BibleVersion;
                button.CommandParameter = selectItem.Value;

                try { Navigation.PopModalAsync(); }
                catch (Exception) { };

            };
        }
       


        private ListView GetListView(string listview, string limitValue)
        {
            //Work around there is null exception thrown second time using a listview passed in
            switch (listview)
            {
                case "BIBLEVERSIONS":
                    return new BiblesListView();
              
                default:
                    return null;

            }
        }
    }
}
