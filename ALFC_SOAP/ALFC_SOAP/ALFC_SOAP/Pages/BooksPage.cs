using ALFC_SOAP.Common;
using ALFC_SOAP.Entities;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    public class BooksPage : ContentPage
    {
        Book CurrentBook;
        public BooksPage(Book book)
        {
            CurrentBook = book;
            this.BackgroundColor = AppColors.White;
            this.Content = PageLayout();
        }

        private ScrollView PageLayout()
        {
            var view = new ScrollView { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stack = new StackLayout();

            stack.Children.Add(new BookChaptersView(CurrentBook));
            view.Content = stack;
            return view;
        }
    }
}
