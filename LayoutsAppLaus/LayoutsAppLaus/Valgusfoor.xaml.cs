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
    public partial class Valgusfoor : ContentPage
    {
        internal bool isEnableVf = false; // переменная, которая отвечает за то включен ли светофор
        public Valgusfoor()
        {
            InitializeComponent();
        }

        private void onButton_Clicked(object sender, EventArgs e)
        {
            ValgusfoorWork vf = new ValgusfoorWork();
            isEnableVf = true;
        }

        private void offButton_Clicked(object sender, EventArgs e)
        {
            isEnableVf = false;
        }
    }
}