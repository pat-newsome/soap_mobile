﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ALFC_SOAP.Common;
using ALFC_SOAP.Entities;
namespace ALFC_SOAP
{
    class HomePage : ContentPage
    {
        private Command<Type> navigateCommand;
        public HomePage()
        {
            this.BackgroundColor = AppColors.BGPurple;
            
            navigateCommand =
                new Command<Type>(async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await this.Navigation.PushAsync(page);
                });

            this.Content = this.BuildReading();

            ToolbarItem addNewItem = new ToolbarItem
            {
                Name = "New entry",
                Icon = Device.OnPlatform("new.png",
                                         "ic_action_new.png",
                                         "Images/add.png"),
                Order = ToolbarItemOrder.Primary
            };

            addNewItem.Activated += (sender, args) =>
            {
                // Create unique filename.
                DateTime datetime = DateTime.UtcNow;
                string filename = datetime.ToString("yyyyMMddHHmmssfff") + ".soap";

                // Navigate to new Page.
                Soap page = new Soap(filename);
                this.Navigation.PushAsync(new SoapPage(page));
            };

            this.ToolbarItems.Add(addNewItem);
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
           // stack.BackgroundColor = AppColors.BGBlue;
            var myListOfFileBtn = new Button { Text = "all my entries", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = AppColors.BGRed };
            myListOfFileBtn.Clicked += myListOfFileBtn_Clicked;
            stack.Children.Add(myListOfFileBtn);
            stack.Children.Add(new Label { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, Font = Font.SystemFontOfSize(NamedSize.Large), BackgroundColor= AppColors.White, TextColor = AppColors.Blue, Text = "plans" });
            stack.Children.Add(new ReadingPlanView());
            stack.Children.Add(new Label { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, Font = Font.SystemFontOfSize(NamedSize.Large), BackgroundColor = AppColors.White, TextColor = AppColors.Green, Text = "books" });
            stack.Children.Add(BuildBooksList());
            return stack;
        }

        private StackLayout BuildBooksList()
        {
            var stack = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand,  Padding = 10};
            var list = new BookListView();
            list.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
               
                var book = (Book)e.Item;

                if (book.ChapterCount == 1)
                {
                    Navigation.PushAsync(new WebPage(book.Name));
                }
                else
                {
                    Navigation.PushAsync(new BookChaptersPage(book));
                }
            };
            stack.Children.Add(list);
            stack.BackgroundColor = AppColors.BGGreen;
            

            return stack;
        }
        void myListOfFileBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntriesPage());
        }
    }
}
