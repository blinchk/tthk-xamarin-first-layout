using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;
using Label = Xamarin.Forms.Label;

namespace LayoutsAppLaus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor2 : ContentPage
    {
        Frame punane, kollane, roheline, headerFrame;
        Label punaneText, kollaneText, rohelineText, headerName;
        Button onButton, offButton;
        Uri uri;
        internal bool isEnableVf;
        public Valgusfoor2()
        {
            //   InitializeComponent();
            headerName = new Label()
            {
                Text = "Valgusfoor",
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = Color.White,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };

            headerFrame = new Frame()
            {
                BackgroundColor = Color.FromHex("#2196F3"),
                Padding = 10,
                Content = headerName
            };

            punaneText = new Label()
            {
                Text = "Punane",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            kollaneText = new Label()
            {
                Text = "Kollane",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            rohelineText = new Label()
            {
                Text = "Roheline",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            punane = new Frame()
            {
                Content = punaneText,
                CornerRadius = 120,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(80, 7.5, 80, 0)
            };

            kollane = new Frame()
            {
                Content = kollaneText,
                CornerRadius = 120,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(80, 7.5, 80, 0)
            };

            roheline = new Frame()
            {
                Content = rohelineText,
                CornerRadius = 120,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(80, 0, 80, 7.5)
            };

            onButton = new Button()
            {
                Text = "SISSE",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            offButton = new Button()
            {
                Text = "VÄLJA",
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
            onButton.Clicked += OnButton_Clicked;
            offButton.Clicked += OffButton_Clicked;

            Content = commonLayout;

            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            punane.GestureRecognizers.Add(tap);
            kollane.GestureRecognizers.Add(tap);
            roheline.GestureRecognizers.Add(tap);
            headerName.GestureRecognizers.Add(tap);
            headerFrame.GestureRecognizers.Add(tap);
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

        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (isEnableVf == false)
            {
                Frame fr = sender as Frame;
                Label lbl = sender as Label;
                if (fr == headerFrame || lbl == headerName)
                {
                    uri = new Uri("https://github.com/blinchk");
                    OpenBrowser(uri);
                }
                else
                    DisplayAlert("Lihtsalt valgusfoor", "Lülitage sisse valgusfoorit.", "Ikka");
            }
            else
            {
                Frame fr = sender as Frame;
                if (fr == punane)
                    punaneText.Text = "Seisa ja oota!";
                else if (fr == kollane)
                    kollaneText.Text = "Tähelepanu!";
                else if (fr == roheline)
                    rohelineText.Text = "Mine";
            }
        }
        public async void OpenBrowser(Uri uri) => await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);

        private void OffButton_Clicked(object sender, EventArgs e)
        {
            isEnableVf = false;
            punaneText.Text = "Punane";
            kollaneText.Text = "Kollane";
            rohelineText.Text = "Roheline";
            setNone();
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
        }
    }
}