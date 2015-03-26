using ALFC_SOAP.Common;
using ALFC_SOAP.Model;
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
        ReadingPlan Plan { get; set; }

        public PlanPage(ReadingPlan plan)
        {
            Plan= plan;
            this.BackgroundColor = AppColors.Green;
            this.Content = PageLayout();
        }

        private StackLayout PageLayout()
        {
           
            var stack = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            stack.Children.Add(new PlanView(Plan));
            
            return stack;
        }
    }
}
