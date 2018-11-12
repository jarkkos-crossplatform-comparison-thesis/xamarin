using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonLatencyPage : ContentPage
    {
        private int counter = 0;

        public ButtonLatencyPage()
        {
            InitializeComponent();

            updateCounterText();
            incrementCounterBtn.Pressed += incrementCounter;
        }

        private void incrementCounter(object sender, EventArgs args)
        {
            counter++;
            updateCounterText();
        }
       

        private void updateCounterText()
        {
            counterText.Text = counter.ToString();
        }
    }
}