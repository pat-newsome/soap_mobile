﻿using Acr.XamForms.Mobile;
using Acr.XamForms.Mobile.IO;
using ALFC_SOAP.Common;
using ALFC_SOAP.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class SoapPage : ContentPage
    {
        Soap soapmessage;
        bool isEdit;
        bool canSave = true;
        ISettings settings = DependencyService.Get<ISettings>();
        ILifecycleHelper helper = DependencyService.Get<ILifecycleHelper>();
        string SearchTerm = "";

        public SoapPage(Soap soap)
        {
            this.SearchTerm = string.Empty;
            this.isEdit = false;
            this.soapmessage = soap;
            Title = "New SOAP";
        }
        public SoapPage(Soap soap, string searchterm, bool isEdit = false)
        {
            this.SearchTerm = searchterm;
            BuildToolBar();
            // Initialize Note object
            this.soapmessage= soap;
            this.isEdit = isEdit;
            Title = isEdit ? "Edit SOAP" : "New SOAP";

            // Create Entry and Editor views.
            Entry entry = new Entry
            {
                Placeholder = Title
            };

            Editor editor0 = new Editor
            {
                Keyboard = Keyboard.Create(KeyboardFlags.All),
                BackgroundColor = Device.OnPlatform(Color.Default, 
                                                    Color.Default, 
                                                    Color.White),
                VerticalOptions = LayoutOptions.FillAndExpand,
                MinimumHeightRequest = 250
            };
            Editor editor1 = new Editor
            {
                Keyboard = Keyboard.Create(KeyboardFlags.All),
                BackgroundColor = Device.OnPlatform(Color.Default,
                                                    Color.Default,
                                                    Color.White),
                VerticalOptions = LayoutOptions.FillAndExpand,
                MinimumHeightRequest = 250
            };
            Editor editor2 = new Editor
            {
                Keyboard = Keyboard.Create(KeyboardFlags.All),
                BackgroundColor = Device.OnPlatform(Color.Default,
                                                    Color.Default,
                                                    Color.White),
                VerticalOptions = LayoutOptions.FillAndExpand,
                MinimumHeightRequest = 250
            };
            Button savebtn = new Button
            {
                
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = AppColors.TextGray,
                BackgroundColor = AppColors.White,
                HeightRequest = 40,
                WidthRequest = 200,
                Text = "save"
            };
            savebtn.Clicked += savebtn_Clicked;

            // Set data bindings.
            this.BindingContext = this.soapmessage;
            entry.SetBinding(Entry.TextProperty, "Scripture");
            editor0.SetBinding(Editor.TextProperty, "Observation");
            editor1.SetBinding(Editor.TextProperty, "Application");
            editor2.SetBinding(Editor.TextProperty, "Prayer");
            // Assemble page.
            StackLayout stackLayout = new StackLayout
            {
                Children = 
                {
                    new Label { Text = "Scripture:" },
                    entry,
                    new Label { Text = "Observation:" },
                    editor0,
                    
                    new Label { Text = "Application:" },
                    editor1,
                    
                    new Label { Text = "Prayer:" },
                    editor2,
                    savebtn
                }
            };

            if (isEdit)
            {
                // Cancel toolbar item.
                ToolbarItem cancelItem = new ToolbarItem
                {
                    Text = "Cancel",
                    Icon = Device.OnPlatform("cancel.png", 
                                             "ic_action_cancel.png", 
                                             "Images/cancel.png"),
                    Order = ToolbarItemOrder.Primary
                };

                cancelItem.Clicked += async (sender, args) =>
                    {
                        canSave = false;
                        bool confirm = await this.DisplayAlert("SOAP Message", 
                                                               "Cancel SOAP edit?", 
                                                               "Yes", "No");
                        if (confirm)
                        {
                            // Return to home page.
                            await this.Navigation.PopAsync();
                        }
                        else
                        { 
                        canSave = true;
                        }
                    };

                this.ToolbarItems.Add(cancelItem);

                // Delete toolbar item.
                ToolbarItem deleteItem = new ToolbarItem
                {
                    Text = "Delete",
                    Icon = Device.OnPlatform("discard.png", 
                                             "ic_action_discard.png", 
                                             "Images/delete.png"),
                    Order = ToolbarItemOrder.Primary
                };

                deleteItem.Clicked += async (sender, args) =>
                    {
                        bool confirm = await this.DisplayAlert("SOAP Message", 
                                                               "Delete this SOAP?", 
                                                               "Yes", "No");
                        if (confirm)
                        {
                            soapmessage.Delete();
                            await this.Navigation.PopAsync();
                        }
                    };

                this.ToolbarItems.Add(deleteItem);
                editor0.Text = soapmessage.Observation;
                editor1.Text = soapmessage.Application;
                editor2.Text = soapmessage.Prayer;
            }
            var scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            this.Content = scrollView;
        }

        private void BuildToolBar()
        {
            ToolbarItem readItem = new ToolbarItem
            {

                //Icon = Device.OnPlatform("view.png",
                //                         "ic_action_view.png",
                //                         "Images/view.png"),
                Order = ToolbarItemOrder.Primary,
                Text = "read"
            };
            readItem.Clicked += (sender, args) =>
            {
                Navigation.PushAsync(new WebPage(this.settings, SearchTerm, true));
            };
            this.ToolbarItems.Add(readItem);
        }

        async void savebtn_Clicked(object sender, EventArgs e)
        {
           await this.Navigation.PopAsync();
           await Navigation.PushAsync(new EntriesPage());
            
        }

        protected override void OnAppearing()
        {
            // Attach handlers for Suspending and Resuming event.
            helper.Suspending += OnSuspending;
            helper.Resuming += OnResuming;

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            // Only save it if there's some text somewhere.
            if (!String.IsNullOrWhiteSpace(soapmessage.Scripture) ||
                !String.IsNullOrWhiteSpace(soapmessage.Observation) ||
                !String.IsNullOrWhiteSpace(soapmessage.Application) ||
                !String.IsNullOrWhiteSpace(soapmessage.Prayer))
            {
                if(canSave)
                soapmessage.Save();
            }

            DetachHandlers();

            base.OnDisappearing();
        }

        private void DetachHandlers()
        {
            // Detach handlers for Suspending and Resuming events.
            helper.Suspending -= OnSuspending;
            helper.Resuming -= OnResuming;
        }

        void OnSuspending()
        {
            
            Task task = Task.Run(() =>
                {
                    soapmessage.Save();
                });

            // Wait for it to finish before finishing event handler.
            task.Wait();
        }

        async void OnResuming()
        {

            
            
        }
    }
}
