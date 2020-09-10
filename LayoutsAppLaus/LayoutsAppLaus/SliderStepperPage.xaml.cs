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
        Frame headerFrame;
        Label headerName;
        Slider Slider1;
        Stepper Stepper1;
        Editor Editor1;
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

            Slider1 = new Slider()
            {
                Minimum = 0,
                Maximum = 100,
                Value = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Stepper1 = new Stepper()
            {
                Minimum = 0,
                Maximum = 100,
                Value = 8,
                Increment = 2,
                HorizontalOptions = LayoutOptions.End
            };

            Slider1.ValueChanged += Slider1_ValueChanged;
            Stepper1.ValueChanged += Stepper1_ValueChanged;

            StackLayout SliderLayout = new StackLayout
            {
                Children = { Slider1, Stepper1 },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal
            };

            Editor1 = new Editor() {
                Text = "It\'s maybe will be text",
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout CommonLayout = new StackLayout
            {
                Children = { headerName, headerFrame, SliderLayout, Editor1 }
            };

            Content = CommonLayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Editor1.FontSize = Slider1.Value;
        }

        private void Stepper1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                Editor1.FontSize = e.NewValue;

                Stepper1.Value = e.NewValue;
            }
        }

        private void Slider1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                Editor1.FontSize = e.NewValue;

                Slider1.Value = e.NewValue;
            }
        }
    }
}