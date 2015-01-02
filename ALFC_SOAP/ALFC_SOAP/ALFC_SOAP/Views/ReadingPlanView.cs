﻿using ALFC_SOAP.Common;
using ALFC_SOAP.Data;
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
       
        public ReadingPlanView()
        {
            var db = new ReadingDataInfo();
            this.ItemsSource = db.GetList();
            this.ItemSelected += ReadingPlanView_ItemSelected;
            this.ItemTemplate = BaseListItemTemplate.GetLabel(AppColors.BGGreen);
            this.BackgroundColor = AppColors.Green;
            this.MinimumHeightRequest = 180;
        }

        void ReadingPlanView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Button btn = (Button)sender;
            Navigation.PushAsync(new PlanPage((int)btn.CommandParameter));
        }
    }
}