using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            BuildWebView(Url);
        }

        public WebPage(string searchTerm)
        {
            this.SearchTerm = searchTerm;

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
