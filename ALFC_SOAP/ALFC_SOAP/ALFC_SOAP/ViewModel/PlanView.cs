using ALFC_SOAP.Common;
using ALFC_SOAP.Data;
using ALFC_SOAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    class PlanView : StackLayout
    {
       
        public PlanView(ReadingPlan plan)
        {
            this.Children.Add(new Label { Text = plan.Name, Font = Font.SystemFontOfSize(NamedSize.Large), BackgroundColor = AppColors.BGBlue, TextColor = AppColors.White });
            this.Children.Add(new Label { Text = "             reading", Font = Font.SystemFontOfSize(NamedSize.Medium), BackgroundColor = AppColors.White, TextColor = AppColors.Blue });
            this.Children.Add(BuildReadingList(plan.Id));
            
        }

        private ListView BuildReadingList(int planId)
        {
            var scroll = new ListView();
            var db = new ReadingDataInfo();
            scroll.ItemsSource = db.GetListReadings(planId);
            scroll.ItemSelected += ReadingPlanView_ItemSelected;
            scroll.ItemTemplate = BaseListItemTemplate.GetFullLabelCheckImage(AppColors.BGGreen);
            return scroll;
        }


        void ReadingPlanView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var reading = (Reading)e.SelectedItem;
            
            DateTime datetime = DateTime.UtcNow;
            string fileName = string.Format("{0}_{1}.soap", reading.Name, datetime.ToString("yyyyMMddHHmm"));
            var soap = new Soap(fileName, reading.UrlSearch);
            Navigation.PushAsync(new SoapPage(soap, false));
        }
    }
}
