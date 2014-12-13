using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ALFC_SOAP.Common;
namespace ALFC_SOAP
{
    class HomePage : ContentPage
    {
        private Command<Type> navigateCommand;
        public HomePage()
        {
            this.BackgroundColor = AppColors.White;
            navigateCommand =
                new Command<Type>(async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await this.Navigation.PushAsync(page);
                });

            this.Content = this.PageLayout();
        }

        private ScrollView PageLayout()
        {
            var scroll = new ScrollView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            var readingPlan = BuildReading();

            return scroll;
        }

        private StackLayout BuildReading()
        {
            var stack = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            stack.BackgroundColor = AppColors.BGBlue;

            return stack;
        }
    }
}
