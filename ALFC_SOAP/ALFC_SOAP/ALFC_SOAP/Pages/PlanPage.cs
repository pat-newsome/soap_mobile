using ALFC_SOAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    class PlanPage : ContentPage
    {
        int PlanId {get;set;}

        public PlanPage(int planId)
        {
            PlanId = planId;
            this.BackgroundColor = AppColors.White;
            this.Content = PageLayout();
        }

        private ScrollView PageLayout()
        {
            var view = new ScrollView { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stack = new StackLayout();

            stack.Children.Add(new PlanView(PlanId));
            view.Content = stack;
            return view;
        }
    }
}
