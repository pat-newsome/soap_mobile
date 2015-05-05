using ALFC_SOAP.Common;
using ALFC_SOAP.ViewModel;
using System;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class DropdownListPage : ContentPage
    {
        public DropdownListPage( ExtendedButton currentButton, string listview, string limitValue = "")
        {
            var list = GetListView(listview, limitValue);
            Content = list;
            this.BackgroundColor = AppColors.White;
            list.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                IDataListItem selectItem = (IDataListItem)e.Item;
                currentButton.Text = !string.IsNullOrEmpty(selectItem.Name) ? selectItem.Name : "select";
                currentButton.CommandParameter = selectItem.Value;
            };
        }
       


        private ListView GetListView(string listview, string currentValue)
        {
            ListView list = null;
            
            switch (listview)
            {
                case "BIBLEVERSIONS":
                    list = new BiblesListView(currentValue);
                    break;
                case "READINGPLANS":
                    list = new ReadingPlanView(true); 
                    break;
                

            }
            return list;
        }
    }
}
