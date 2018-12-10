using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThesisXamarin.Logic;

namespace ThesisXamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectTestPage : ContentPage
	{
		public SelectTestPage ()
		{
			InitializeComponent ();

            openButtonLatencyTestBtn.Pressed += openButtonLatencyTest;
            openLocalListViewTestBtn.Pressed += openLocalListViewTest;
            openNetworkListViewTestBtn.Pressed += openNetworkListViewTest;
            openHeavyComputationTestBtn.Pressed += openHeavyComputationTest;
            openVibrationLatencyTestBtn.Pressed += openVibrationLatencyTest;
            openThirdPartyNoticesPageBtn.Pressed += openThirdPartyNoticesPage;
        }

        private void openButtonLatencyTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ButtonLatencyPage(), false);
        }

        private void openLocalListViewTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ListItemsPage(new LocalListItemsLoader()) { Title = "Local listview" }, false);
        }

        private void openNetworkListViewTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ListItemsPage(new NetworkListItemsLoader()) { Title = "Network listview" }, false);
        }
        
        private void openHeavyComputationTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new HeavyComputationPage(), false);
        }

        private void openVibrationLatencyTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new VibrationLatencyPage(), false);
        }

        private void openThirdPartyNoticesPage(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TestNotImplemented(), false);
        }
    }
}