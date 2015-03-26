using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using ALFC_SOAP.Model;
//using Xamarin.Forms.Labs.Mvvm;

namespace ALFC_SOAP
{
    class WebPage : ContentPage
    {
        string searchBaseURL = "http://www.biblegateway.com/";
        string baseUrl = "http://www.alfc.us/journal";
        private string SearchUrl
        {
            get 
            { 
                return string.Format("{0}passage?search={1}", searchBaseURL, SearchTerm);
            }
        }

        public string Url {
            get
            { return baseUrl; }
            set
            { baseUrl = value; }
        }

        private string SearchTerm;

        public WebPage()
        {
           
            //addNewItem.Command = BuildCommand();
            BuildTools();
            BuildWebView(Url);
        }

        private void BuildTools()
        {
            ToolbarItem addNewItem = new ToolbarItem
            {
                Name = "New entry",
                Icon = Device.OnPlatform("new.png",
                                         "ic_action_new.png",
                                         "Images/add.png"),
                Order = ToolbarItemOrder.Primary,
                Text = "new"
            };
            addNewItem.Clicked += (sender, args) =>
            {
                // Create unique filename.
                DateTime datetime = DateTime.UtcNow;
                string fileName = string.Format("{0}_{1}.soap", SearchTerm, datetime.ToString("yyyyMMddHHmm"));
                var soap = new Soap(fileName, SearchTerm);
                // Navigate to new Page.
                this.Navigation.PopAsync();
                this.Navigation.PushAsync(new SoapPage(soap, false));
            };
            this.ToolbarItems.Add(addNewItem);
        }


       

        public WebPage(string searchTerm)
        {

            this.SearchTerm = searchTerm;
            BuildTools();
            this.Content = new StackLayout
            {
                Children = 
                {
                    BuildWebView(SearchUrl)
                }
            };
        }


        private WebView BuildWebView(string pageUrl)
        {
            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = pageUrl
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill
            };


            return webView;
        }
    }
}
