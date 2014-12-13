using System;
using Xamarin.Forms;
using ALFC_SOAP.Common;

namespace ALFC_SOAP.Views
{
    public class BaseListItemTemplate
    {
        public static DataTemplate Get()
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.TextGray;
                ListItem.SetBinding(Label.TextProperty, new Binding("Name", BindingMode.OneWay, null, null, "{0}"));
                ListItem.BackgroundColor = AppColors.BGBlue;
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Padding = new Thickness(5, 0, 10, 5),
                        Spacing = 0,
                        Children = { ListItem }
                    }
                };
            });
        }

        public static DataTemplate Error()
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.TextRed;
                ListItem.SetBinding(Label.TextProperty, new Binding("Name", BindingMode.OneWay, null, null, "* {0}"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Padding = new Thickness(5, 0, 10, 5),
                        Spacing = 0,
                        Children = { ListItem }
                    }
                };
            });
        }
    }
}
