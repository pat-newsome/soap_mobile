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
    class ReadingPlanView : ListView
    {
       
        public ReadingPlanView(bool isSelect = false)
        {
            var db = new PlansData();
            this.ItemsSource = db.GetItems();
            if (!isSelect)
            {
                this.ItemSelected += ReadingPlanView_ItemSelected;
            }
            else 
            { 
                this.ItemSelected += ReadingPlanSelected; 
            }
            this.ItemTemplate = BaseListItemTemplate.GetLabel(AppColors.BGGreen);
            this.BackgroundColor = AppColors.Green;
            this.MinimumHeightRequest = 180;
        }

        void ReadingPlanView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var plan = (ReadingPlan)e.SelectedItem;
            Navigation.PushAsync(new PlanPage(plan));
        }

        void ReadingPlanSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var plan = (ReadingPlan)e.SelectedItem;
            plan.IsSelected = true;
            var db = new PlansData();
            db.SaveItem(plan);
            Navigation.PopModalAsync();
        }
    }
}
