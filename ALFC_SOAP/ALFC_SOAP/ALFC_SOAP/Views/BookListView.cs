using System;
using System.Collections;
using Xamarin.Forms;
using ALFC_SOAP.Data;
namespace ALFC_SOAP
{
    public class BookListView : ListView
    {
        

        public BookListView()
        {
            BibleDataInfo db = new BibleDataInfo();
            this.ItemsSource = db.GetList();

        }
    }
}
