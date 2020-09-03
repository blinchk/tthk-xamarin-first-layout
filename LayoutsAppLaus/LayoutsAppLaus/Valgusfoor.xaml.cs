using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LayoutsAppLaus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        internal bool isEnableVf; // переменная, которая отвечает за то включен ли светофор
        public Valgusfoor()
        {
            InitializeComponent();
            isEnableVf = false;
        }

        private void setNone()
        {
            Punane.BackgroundColor = Color.Gray;
            Kollane.BackgroundColor = Color.Gray;
            Roheline.BackgroundColor = Color.Gray;
        }

        private void setRed()
        {
            setNone();
            Punane.BackgroundColor = Color.Red;
        }
        
        private void setYellow()
        {
            setNone();
            Kollane.BackgroundColor = Color.Yellow;
        }

        private void setGreen()
        {
            setNone();
            Roheline.BackgroundColor = Color.Green;

        }

        private void onButton_Clicked(object sender, EventArgs e) // кнопка включения
        {
            isEnableVf = true;
            Random random = new Random();
            int rndColor = random.Next(0, 3);
            switch(rndColor)
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

        private void offButton_Clicked(object sender, EventArgs e) // кнопка выключения
        {
            isEnableVf = false;
            setNone();
        }
    }
}