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

        ILifecycleHelper helper = DependencyService.Get<ILifecycleHelper>();

        public EntriesPage ()
	    {
            this.BackgroundColor = AppColors.White;
            
	    }

        private ScrollView PageLayout()
        {
            var view = new ScrollView { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stack = new StackLayout();

            stack.Children.Add(new JournalEntriesView());
            view.Content = stack;
            return view;
        }
        protected override void OnAppearing()
        {
            // Attach handlers for Suspending and Resuming event.
            this.Content = PageLayout();
            helper.Resuming += OnResuming;

            base.OnAppearing();
        }
        async void OnResuming()
        {
            this.Content = PageLayout();
        }

        protected override void OnDisappearing()
        {

            helper.Resuming -= OnResuming;
            base.OnDisappearing();
        }
    }
}
