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
    public partial class VibrationLatencyPage : ContentPage
    {
        public VibrationLatencyPage()
        {
            InitializeComponent();

            vibrateDeviceBtn.Pressed += vibrateDevice;
        }

        private void vibrateDevice(object sender, EventArgs args)
        {
            Xamarin.Essentials.Vibration.Vibrate(400);
        }
    }
}