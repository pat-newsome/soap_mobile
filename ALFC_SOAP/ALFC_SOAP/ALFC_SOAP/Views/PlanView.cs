using ALFC_SOAP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    class PlanView : ListView
    {
       
        public PlanView(int planId)
        {
            var db = new ReadingDataInfo();
            this.ItemsSource = db.GetList();
            this.ItemSelected += ReadingPlanView_ItemSelected;
            this.ItemTemplate = BaseListItemTemplate.Get();
        }

        void ReadingPlanView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Button btn = (Button)sender;
            int readingId = (int)btn.CommandParameter;
            DateTime datetime = DateTime.UtcNow;
            string scripture = "3 John 1";
            string fileName = string.Format("{0}_{1}.soap", datetime.ToString("yyyyMMddHHmmssfff"));
            var soap = new Soap(fileName, scripture);
            Navigation.PushAsync(new SoapPage(soap, false));
        }
    }
}
