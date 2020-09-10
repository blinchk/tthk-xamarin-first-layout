using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LayoutsAppLaus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderStepperPage : ContentPage
    {
        int[] colors = new int[3] { 255, 0, 0 };
        Frame headerFrame, ColorBox;
        Label headerName, RedValue, GreenValue, BlueValue;
        Slider RedSlider, GreenSlider, BlueSlider;
        Button RandomColorButton;
        public SliderStepperPage()
        {
            headerName = new Label()
            {
                Text = "Slider и Stepper",
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

            RedSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 255,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            GreenSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            BlueSlider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            RedSlider.ValueChanged += RedSlider_ValueChanged;
            GreenSlider.ValueChanged += GreenSlider_ValueChanged;
            BlueSlider.ValueChanged += BlueSlider_ValueChanged;

            RedValue = new Label()
            {
                FontSize = 15,
                Text = $"Red = {GetHexColor(colors[0])}",
                HorizontalTextAlignment = TextAlignment.Center
            };

            GreenValue = new Label()
            {
                FontSize = 15,
                Text = $"Green = {GetHexColor(colors[1])}",
                HorizontalTextAlignment = TextAlignment.Center
            };

            BlueValue = new Label()
            {
                FontSize = 15,
                Text = $"Blue = {GetHexColor(colors[2])}",
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
                FontAttributes = FontAttributes.Italic,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 20
            };

            RandomColorButton.Clicked += RandomColorButton_Clicked;

            StackLayout SliderLayout = new StackLayout
            {
                Padding = new Thickness(15, 30, 15, 30),
                Children = { RedSlider, RedValue, GreenSlider, GreenValue, BlueSlider, BlueValue },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical
            };

            StackLayout CommonLayout = new StackLayout
            {
                Children = { headerFrame, ColorBox, SliderLayout, RandomColorButton}
            };

            Content = CommonLayout;
            ChangeColor();
        }

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