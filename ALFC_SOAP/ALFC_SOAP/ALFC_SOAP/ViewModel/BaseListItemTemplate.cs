using System;
using Xamarin.Forms;
using ALFC_SOAP.Common;

namespace ALFC_SOAP
{
    public class BaseListItemTemplate
    {
        public static DataTemplate Get()
        {
            return new DataTemplate(() =>
            {
                Button ListItem = new Button();
                ListItem.TextColor = AppColors.TextGray;
                ListItem.Font = Font.SystemFontOfSize(NamedSize.Medium);
                ListItem.SetBinding(Button.TextProperty, new Binding("Name", BindingMode.OneWay, null, null, "{0}"));
                ListItem.SetBinding(Button.CommandParameterProperty, new Binding("Id", BindingMode.OneWay, null, null, "{0}"));
                ListItem.HorizontalOptions = LayoutOptions.FillAndExpand;
                ListItem.VerticalOptions = LayoutOptions.FillAndExpand;
                ListItem.BackgroundColor = AppColors.White;
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

        public static DataTemplate GetFullLabel(Color bgColor)
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.White;
                ListItem.SetBinding(Label.TextProperty, new Binding("UrlSearch", BindingMode.OneWay, null, null, "{0}"));
                ListItem.Font = Font.SystemFontOfSize(NamedSize.Medium);
                ListItem.HorizontalOptions = LayoutOptions.FillAndExpand;
                ListItem.VerticalOptions = LayoutOptions.FillAndExpand;
                ListItem.BackgroundColor = bgColor;
                ListItem.MinimumHeightRequest = 120;
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
        public static DataTemplate GetFullLabelCheckImage(Color bgColor)
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.White;
                ListItem.SetBinding(Label.TextProperty, new Binding("UrlSearch", BindingMode.OneWay, null, null, "{0}"));
                ListItem.Font = Font.SystemFontOfSize(NamedSize.Medium);
                ListItem.HorizontalOptions = LayoutOptions.FillAndExpand;
                ListItem.VerticalOptions = LayoutOptions.FillAndExpand;
                ListItem.BackgroundColor = bgColor;
                ListItem.MinimumHeightRequest = 120;
                Image checkedImage = new Image{ HeightRequest=24, WidthRequest=24};
                checkedImage.Source = Device.OnPlatform(ImageSource.FromFile("Images/actionUnChecked.png"), ImageSource.FromFile("actionUnChecked.png"), ImageSource.FromFile("Images/actionUnChecked.png"));
                //checkedImage.Source = 
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Padding = new Thickness(5, 0, 10, 5),
                        Spacing = 0,
                        Children = { ListItem, checkedImage }
                    }
                };
            });
        }
        public static DataTemplate GetLabel(Color bgColor)
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.White;
                ListItem.SetBinding(Label.TextProperty, new Binding("Name", BindingMode.OneWay, null, null, "{0}"));
                ListItem.Font = Font.SystemFontOfSize(NamedSize.Medium);
                ListItem.HorizontalOptions = LayoutOptions.FillAndExpand;
                ListItem.VerticalOptions = LayoutOptions.FillAndExpand;
                ListItem.BackgroundColor = bgColor;
                ListItem.MinimumHeightRequest = 120;
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
        public static DataTemplate GetUrl()
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.TextGray;
                ListItem.SetBinding(Label.TextProperty, new Binding("Name", BindingMode.OneWay, null, null, "{0}"));
                ListItem.BackgroundColor = AppColors.White;
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
