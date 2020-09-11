using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LayoutsAppLaus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderStepperPage : ContentPage
    {
        int[] colors = new int[3] { 255, 0, 0 };
        Frame ColorBox;
        Label RedValue, GreenValue, BlueValue, GitHubLabel;
        Slider RedSlider, GreenSlider, BlueSlider;
        Button RandomColorButton;
        ToolbarItem RGBButton, HEXButton, ColorListButton;
        public SliderStepperPage()
        {
            Title = "Slider и Stepper";

            RGBButton = new ToolbarItem()
            {
                Text = "RGB",
                Priority = 0,
                Order = ToolbarItemOrder.Primary
            };

            HEXButton = new ToolbarItem()
            {
                Text = "HEX",
                Priority = 1,
                Order = ToolbarItemOrder.Primary
            };

            ColorListButton = new ToolbarItem()
            {
                Text= "ЦВЕТА",
                Priority = 2,
                Order = ToolbarItemOrder.Primary
            };

            ToolbarItems.Add(RGBButton);
            ToolbarItems.Add(HEXButton);
            ToolbarItems.Add(ColorListButton);
            RGBButton.Clicked += RGBButton_Clicked;
            HEXButton.Clicked += HEXButton_Clicked;

            RedSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,    
            };

            GreenSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            BlueSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            RedSlider.ValueChanged += RedSlider_ValueChanged;
            GreenSlider.ValueChanged += GreenSlider_ValueChanged;
            BlueSlider.ValueChanged += BlueSlider_ValueChanged;

            RedValue = new Label()
            {
                FontSize = 15,
                Text = $"Green = {GetHexColor(colors[0])} / {colors[0]}",
                HorizontalTextAlignment = TextAlignment.Center
            };

            GreenValue = new Label()
            {
                FontSize = 15,
                Text = $"Green = {GetHexColor(colors[1])} / {colors[1]}",
                HorizontalTextAlignment = TextAlignment.Center
            };

            BlueValue = new Label()
            {
                FontSize = 15,
                Text = $"Blue = {GetHexColor(colors[2])} / {colors[2]}",
                HorizontalTextAlignment = TextAlignment.Center
            };

            ColorBox = new Frame()
            {
                BackgroundColor = Color.FromHex("#FF0000"),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            RandomColorButton = new Button()
            {
                Text = "Случайный цвет",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 20
            };

            GitHubLabel = new Label()
            {
                Text = "GitHub: @blinchk",
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(0, 0, 0, 10),
                FontSize = 15,
                TextDecorations = TextDecorations.Underline
            };

            RandomColorButton.Clicked += RandomColorButton_Clicked;
            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            GitHubLabel.GestureRecognizers.Add(tap);

            StackLayout SliderLayout = new StackLayout
            {   
                Padding = new Thickness(15, 30, 15, 30),
                Children = { RedSlider, RedValue, GreenSlider, GreenValue, BlueSlider, BlueValue },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical
            };

            StackLayout CommonLayout = new StackLayout
            {
                Children = { ColorBox, SliderLayout, RandomColorButton, GitHubLabel }
            };
            
            Content = CommonLayout;
            GetRandomColor();
            ChangeColor();
        }

        private async void HEXButton_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("HEX", "Введите цвет в HEX: ", "OK", "Отмена", initialValue: "FF, FF, FF");
        }

        private async void RGBButton_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("RGB", "Введите цвет в RGB: ", "OK", "Отмена", initialValue: "255, 255, 255");
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            Frame fr = sender as Frame;
            if (lbl == GitHubLabel)
            {
                Uri uri = new Uri("https://github.com/blinchk");
                OpenBrowser(uri);
            }
            else if (fr == ColorBox)
            {
                string clipboardColor;
            }
        }

        public async void OpenBrowser(Uri uri) => await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);

        private void RandomColorButton_Clicked(object sender, EventArgs e)
        {
            GetRandomColor();
            ChangeColor();
        }

        private string GetHexColor(int color)
        {
            return color.ToString("X2").ToUpper(); // Convert color ToString in upper case
        }

        private void RedSlider_ValueChanged(object sender, ValueChangedEventArgs e) // Red color slider value change
        {
            if (e.NewValue > 0)
            {
                colors[0] = Convert.ToInt32(e.NewValue);
            }
            ChangeColor();
        }

        private void GreenSlider_ValueChanged(object sender, ValueChangedEventArgs e) // Green slider value change
        {
            if (e.NewValue > 1)
            {
                colors[1] = Convert.ToInt32(e.NewValue);
            }
            ChangeColor();
        }

        private void BlueSlider_ValueChanged(object sender, ValueChangedEventArgs e) // Blue slider value change
        {
            if (e.NewValue > 0)
            {
                colors[2] = Convert.ToInt32(e.NewValue);
            }
            ChangeColor();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void GetRandomColor()
        {
            Random random = new Random();
            colors[0] = random.Next(0, 255);
            colors[1] = random.Next(0, 255);
            colors[2] = random.Next(0, 255);
            RedSlider.Value = colors[0];
            GreenSlider.Value = colors[1];
            BlueSlider.Value = colors[2];
        }

        private void ChangeColor()
        {
            RedValue.Text = $"Red = {GetHexColor(colors[0])}";
            GreenValue.Text = $"Green = {GetHexColor(colors[1])}";
            BlueValue.Text = $"Blue = {GetHexColor(colors[2])}"; // Text values of colors
            RedSlider.BackgroundColor = Color.FromRgb(colors[0], 0, 0);
            GreenSlider.BackgroundColor = Color.FromRgb(0, colors[1], 0);
            BlueSlider.BackgroundColor = Color.FromRgb(0, 0, colors[2]); // Color of slider 
            ColorBox.BackgroundColor = Color.FromRgb(colors[0], colors[1], colors[2]); // Color of ColorBox
        }
    }
}