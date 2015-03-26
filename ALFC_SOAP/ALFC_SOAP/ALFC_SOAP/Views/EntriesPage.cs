using ALFC_SOAP.Common;
using ALFC_SOAP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class EntriesPage : ContentPage
    {
        
        public EntriesPage ()
	    {
            this.BackgroundColor = AppColors.White;
            this.Content = PageLayout();
	    }

        private ScrollView PageLayout()
        {
            var view = new ScrollView { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stack = new StackLayout();

            stack.Children.Add(new JournalEntriesView());
            view.Content = stack;
            return view;
        }
        
    }
}
