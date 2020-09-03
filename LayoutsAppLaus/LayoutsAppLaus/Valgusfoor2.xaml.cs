using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;
using Label = Xamarin.Forms.Label;

namespace LayoutsAppLaus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor2 : ContentPage
    {
        internal bool isEnableVf;
        public Valgusfoor2()
        {
            //   InitializeComponent();
            Label headerName = new Label()
            {
                Text = "Valgusfoor",
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.White,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };

            Frame headerFrame = new Frame()
            {
                BackgroundColor = Color.FromHex("#2196F3"),
                Padding = 10,
                Content = headerName
            };

            Frame punane = new Frame()
            {
                CornerRadius = 120,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(80, 7.5, 80, 0)
            };

            Frame kollane = new Frame()
            {
                CornerRadius = 120,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(80, 7.5, 80, 0)
            };

            Frame roheline = new Frame()
            {
                CornerRadius = 120,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(80, 0, 80, 7.5)
            };

            Button onButton = new Button()
            {
                Text = "ВКЛ",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            Button offButton = new Button()
            {
                Text = "ВКЛ",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            StackLayout buttonsLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 65,
                Children = { onButton, offButton }
            };

            StackLayout commonLayout = new StackLayout()
            {
                Children = { headerFrame, punane, kollane, roheline, buttonsLayout }
            };

            Content = commonLayout;

            onButton.Clicked += OnButton_Clicked;
            offButton.Clicked += OffButton_Clicked;
        }
        private void setNone()
        {
            punane.BackgroundColor = Color.Gray;
            kollane.BackgroundColor = Color.Gray;
            roheline.BackgroundColor = Color.Gray;
        }

        private void setRed()
        {
            setNone();
            punane.BackgroundColor = Color.Red;
        }

        private void setYellow()
        {
            setNone();
            kollane.BackgroundColor = Color.Yellow;
        }

        private void setGreen()
        {
            setNone();
            roheline.BackgroundColor = Color.Green;
        }

        private void OffButton_Clicked(object sender, EventArgs e)
        {
            isEnableVf = false;
            setNone();
            throw new NotImplementedException();
        }

        private void OnButton_Clicked(object sender, EventArgs e)
        {
            isEnableVf = true;
            Random random = new Random();
            int rndColor = random.Next(0, 3);
            switch (rndColor)
            {
                case 0:
                    setRed();
                    break;
                case 1:
                    setYellow();
                    break;
                case 2:
                    setGreen();
                    break;
                default:
                    setNone();
                    break;
            }
            throw new NotImplementedException();
        }
    }
}