using System;
using Xamarin.Forms;
using ALFC_SOAP.Common;

namespace ALFC_SOAP
{
    public class BaseListItemTemplate
    {
        public static DataTemplate Get(string currentValue)
        {
            return new DataTemplate(() =>
            {
                Button ListItem = new Button();
                ListItem.TextColor = AppColors.TextGray;
                ListItem.FontSize = 10;
                ListItem.SetBinding(Button.TextProperty, new Binding("Name", BindingMode.OneWay, null, null, "{0}"));
                ListItem.SetBinding(Button.CommandParameterProperty, new Binding("Value", BindingMode.OneWay, null, null, "{0}"));
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
                ListItem.FontSize = 10; ;
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

        public static DataTemplate GetLabelCheckImageShareButton(Color bgColor)
        {
            return new DataTemplate(() =>
            {
                Label ListItem = new Label();
                ListItem.TextColor = AppColors.White;
                ListItem.SetBinding(Label.TextProperty, new Binding("UrlSearch", BindingMode.OneWay, null, null, "{0}"));
                ListItem.FontSize = 12;
                ListItem.HorizontalOptions = LayoutOptions.FillAndExpand;
                ListItem.VerticalOptions = LayoutOptions.FillAndExpand;
                ListItem.BackgroundColor = bgColor;
                
                Image checkedImage = new Image{ HeightRequest=24, WidthRequest=24};
                checkedImage.SetBinding(Image.SourceProperty, new Binding("StatusImage"));
                Image shareImage = new Image { HeightRequest = 24, WidthRequest = 24 };
                shareImage.SetBinding(Image.IsVisibleProperty, new Binding("HaveRead"));
                //TODO Set Action on share to 
                shareImage.Source = Device.OnPlatform(ImageSource.FromFile("Images/actionShare.png"), ImageSource.FromFile("actionShare.png"), ImageSource.FromFile("Images/actionShare.png"));
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Padding = new Thickness(5, 0, 10, 5),
                        Spacing = 0,
                        Children = { ListItem, shareImage, checkedImage }
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
                ListItem.FontSize = 12;
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

        public static DataTemplate TextCell()
        {
            return new DataTemplate(typeof(TextCell));
        }
    }
}
