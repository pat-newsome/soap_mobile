using Acr.XamForms.Mobile;
using ALFC_SOAP.Common;
using ALFC_SOAP.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class BooksPage : ContentPage
    {

        Book currentBook;
        private ISettings settings;
        public BooksPage(ISettings settings, Book book)
        {
            this.settings = settings;
            this.currentBook = book;
            this.BackgroundColor = AppColors.White;
            this.Content = PageLayout();
        }

        private ScrollView PageLayout()
        {
            var view = new ScrollView { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stack = new StackLayout();

            stack.Children.Add(new BookChaptersView(settings, currentBook));
            view.Content = stack;
            return view;
        }
    }
}
