using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ALFC_SOAP.Common;
using ALFC_SOAP.Model;
using ALFC_SOAP.ViewModel;
using Acr.XamForms.Mobile;
namespace ALFC_SOAP
{
    public class HomePage : ContentPage
    {
        private Command<Type> navigateCommand;
        private ISettings settings;
        public HomePage(ISettings settings)
        {
            this.Content = this.BuildReading();
            this.settings = settings;
            BuildToolBar();
        }

        private void BuildToolBar()
        {
            ToolbarItem addNewItem = new ToolbarItem
            {
                
                Icon = Device.OnPlatform("new.png",
                                         "ic_action_new.png",
                                         "Images/add.png"),
                Order = ToolbarItemOrder.Primary,
                Text = "new"
            };


            ToolbarItem subItem1 = new ToolbarItem
            {
                Text = "Settings",
                Order = ToolbarItemOrder.Secondary
            };
            ToolbarItem subItem2 = new ToolbarItem
            {
                Text = "Social Media",

                Order = ToolbarItemOrder.Secondary
            };
            addNewItem.Clicked += (sender, args) =>
            {
                // Create unique filename.
                DateTime datetime = DateTime.UtcNow;
                string filename = datetime.ToString("yyyyMMddHHmmss") + ".soap";

                // Navigate to new Page.
                Soap page = new Soap(filename);
                this.Navigation.PushAsync(new SoapPage(page, "", false));
            };

            subItem1.Clicked += (sender, args) =>
            {
                //Open the settings modal
                var setting = new SettingsPage();
                setting.BindingContext = new SettingsViewModel(settings);
                this.Navigation.PushModalAsync(setting);
            };
            this.ToolbarItems.Add(addNewItem);
            this.ToolbarItems.Add(subItem1);
            this.ToolbarItems.Add(subItem2);
        }

        private ScrollView PageLayout()
        {
            var scroll = new ScrollView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            scroll.Content = BuildReading();
            return scroll;
        }

        private StackLayout BuildReading()
        {
            var stack = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
          
            var myListOfFileBtn = new Button { Text = "My entries", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = AppColors.BGRed };
            myListOfFileBtn.Clicked += myListOfFileBtn_Clicked;
            stack.Children.Add(myListOfFileBtn);
            
            stack.Children.Add(new Label { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, Font = Font.SystemFontOfSize(NamedSize.Large), BackgroundColor = AppColors.White, TextColor = AppColors.Blue, Text = "Reading plans" });
                stack.Children.Add(new ReadingPlanView());
                stack.Children.Add(new Label { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, Font = Font.SystemFontOfSize(NamedSize.Large), BackgroundColor = AppColors.White, TextColor = AppColors.Green, Text = "Books of the Bible" });
                stack.Children.Add(BuildBooksList());
            
            return stack;
        }

        private StackLayout BuildBooksList()
        {
            var stack = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor= AppColors.BGBlue,  Padding = 10};
            var list = new BookListView();
            list.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
               
                var book = (Book)e.Item;

                if (book.ChapterCount == 1)
                {
                    Navigation.PushAsync(new WebPage(this.settings, book.Name, false));
                }
                else
                {
                    Navigation.PushAsync(new BookChaptersPage(this.settings, book));
                }
            };
            stack.Children.Add(list);

            return stack;
        }

        void myListOfFileBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntriesPage());
        }
    }
}
