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
    public partial class Valgusfoor2 : ContentPage
    {
        public Valgusfoor2()
        {
            //   InitializeComponent();
            Label punane = new Label()
            { 
                Text = "Punane",
                TextColor = Color.Red,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };
            Label kollane = new Label()
            {
                Text = "Kollane",
                TextColor = Color.Yellow,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };
            Label roheline = new Label()
            {
                Text = "Roheline",
                TextColor = Color.Green,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };
            StackLayout layout = new StackLayout()
            {
                Children = { punane, kollane, roheline }
            };
            Content = layout;
        }
    }
}