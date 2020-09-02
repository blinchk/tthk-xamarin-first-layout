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
    public partial class StartPage : ContentPage
    {
        int clicks = 0;
        public StartPage()
        {
            InitializeComponent();
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            clicks++;
            btn.Text = clicks.ToString();
            if (clicks % 5 == 0)
                lbl.Text = "";
            else
                lbl.Text = "Click me!";
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            clicks = 0;
            btn.Text = clicks.ToString();
        }
    }
}