using System;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class SoapPage : ContentPage
    {
         Soap soapmessage;
        bool isEdit;
        ILifecycleHelper helper = DependencyService.Get<ILifecycleHelper>();

        public SoapPage(Soap soap, bool isEdit = false)
        {
            // Initialize Note object
            this.soapmessage= soap;
            this.isEdit = isEdit;
            Title = isEdit ? "Edit SOAP" : "New SOAP";

            // Create Entry and Editor views.
            Entry entry = new Entry
            {
                Placeholder = "Title (optional)"
            };

            Editor editor = new Editor
            {
                Keyboard = Keyboard.Create(KeyboardFlags.All),
                BackgroundColor = Device.OnPlatform(Color.Default, 
                                                    Color.Default, 
                                                    Color.White),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Set data bindings.
            this.BindingContext = soapmessage;
            entry.SetBinding(Entry.TextProperty, "Title");
            editor.SetBinding(Editor.TextProperty, "Text");

            // Assemble page.
            StackLayout stackLayout = new StackLayout
            {
                Children = 
                {
                    new Label { Text = "Title:" },
                    entry,
                    new Label { Text = "Note:" },
                    editor,
                }
            };

            if (isEdit)
            {
                // Cancel toolbar item.
                ToolbarItem cancelItem = new ToolbarItem
                {
                    Name = "Cancel",
                    Icon = Device.OnPlatform("cancel.png", 
                                             "ic_action_cancel.png", 
                                             "Images/cancel.png"),
                    Order = ToolbarItemOrder.Primary
                };

                cancelItem.Activated += async (sender, args) =>
                    {
                        bool confirm = await this.DisplayAlert("SOAP Message", 
                                                               "Cancel SOAP edit?", 
                                                               "Yes", "No");
                        if (confirm)
                        {
                            // Reload note.
                            await soapmessage.LoadAsync();

                            // Return to home page.
                            await this.Navigation.PopAsync();
                        }
                    };

                this.ToolbarItems.Add(cancelItem);

                // Delete toolbar item.
                ToolbarItem deleteItem = new ToolbarItem
                {
                    Name = "Delete",
                    Icon = Device.OnPlatform("discard.png", 
                                             "ic_action_discard.png", 
                                             "Images/delete.png"),
                    Order = ToolbarItemOrder.Primary
                };

                deleteItem.Activated += async (sender, args) =>
                    {
                        bool confirm = await this.DisplayAlert("SOAP Message", 
                                                               "Delete this SOAP?", 
                                                               "Yes", "No");
                        if (confirm)
                        {
                            // Delete Note file and remove from collection.
                            await soapmessage.DeleteAsync();
                            App.SoapFolder.SoapMessages.Remove(soap);

                            // Return to home page.
                            await this.Navigation.PopAsync();
                        }
                    };

                this.ToolbarItems.Add(deleteItem);
            }

            this.Content = stackLayout;
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
                soapmessage.SaveAsync();

                if (!isEdit)
                {
                    App.SoapFolder.SoapMessages.Add(soapmessage);
                }
            }

            // Detach handlers for Suspending and Resuming events.
            helper.Suspending -= OnSuspending;
            helper.Resuming -= OnResuming;

            base.OnDisappearing();
        }

        void OnSuspending()
        {
            // Save transient data and state.
            string str = soapmessage.Filename + "|" +
                         isEdit.ToString() + "|" +
                         soapmessage.Scripture + "|" +
                         soapmessage.Observation + "|" +
                         soapmessage.Application  + "|" +
                         soapmessage.Prayer;

            // WriteTextAsync in separate thread.
            Task task = Task.Run(() =>
                {
                    FileHelper.WriteTextAsync(App.TransientFilename, str);
                });

            // Wait for it to finish before finishing event handler.
            task.Wait();
        }

        async void OnResuming()
        {
            // Delete transient data and state.
            if (await FileHelper.ExistsAsync(App.TransientFilename))
            {
                await FileHelper.DeleteFileAsync(App.TransientFilename);
            }
        }
    }
}
