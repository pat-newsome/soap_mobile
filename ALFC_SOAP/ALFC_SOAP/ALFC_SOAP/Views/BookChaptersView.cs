using System;
using System.Collections;
using Xamarin.Forms;
using ALFC_SOAP.Data;
using ALFC_SOAP.Entities;
using ALFC_SOAP.Common;
namespace ALFC_SOAP
{
    public class BookChaptersView : StackLayout
    {
        Book CurrentBook;

        public BookChaptersView(Book book)
        {
            CurrentBook = book;
            this.Children.Add(new Label{ Text = CurrentBook.Name, Font= Font.SystemFontOfSize(NamedSize.Large), BackgroundColor = AppColors.BGBlue, TextColor= AppColors.White}) ;
            this.Children.Add(new Label { Text = "             chapters", Font = Font.SystemFontOfSize(NamedSize.Medium), BackgroundColor = AppColors.White, TextColor = AppColors.Blue});
            this.Children.Add(BuildGrid());           
        }

        private Grid BuildGrid()
        {
            var tileGrid = new Grid
            {
                MinimumHeightRequest = 800,
                MinimumWidthRequest = 400,
                RowSpacing = 10,
                ColumnSpacing = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = AppColors.Transparent
            };
            tileGrid.ColumnDefinitions = new ColumnDefinitionCollection
                { 
                new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)}, 
                new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)}, 
                new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)}, 
                new ColumnDefinition{ Width = new GridLength(1,GridUnitType.Star)}
                };

            int rowCount = 0;
            int colCount = 0;
            for (int i = 1; i <= CurrentBook.ChapterCount; i++)
            {
                tileGrid.Children.Add(BuildTile(i, CurrentBook.Name), colCount, rowCount);
                colCount++;

                if (i % 4 == 0)
                {
                    colCount = 0;
                    rowCount++;
                }
            }
            return tileGrid;
        }

        private View BuildTile(int i, string Name)
        {
            var stack = new StackLayout();
            stack.MinimumHeightRequest = 80;
            stack.MinimumWidthRequest = 80;
            stack.VerticalOptions = LayoutOptions.CenterAndExpand;
            stack.HorizontalOptions = LayoutOptions.CenterAndExpand;
            stack.BackgroundColor = AppColors.Transparent;
            stack.Padding = 4;


            Button button = new Button
            {
                Text = i.ToString(),
                TextColor = AppColors.White,
                BackgroundColor = AppColors.BGBlue,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            button.CommandParameter = string.Format("{0} {1}", CurrentBook.Name, i);
            button.BorderWidth = 0;
            button.BorderColor = AppColors.Rose;
            button.Clicked += (object sender, EventArgs e) =>
            {

                var btn = (Button)sender;
                Navigation.PushAsync(new WebPage(btn.CommandParameter.ToString()));

            };
            stack.Children.Add(button);

            return stack;
        }

    }
}
