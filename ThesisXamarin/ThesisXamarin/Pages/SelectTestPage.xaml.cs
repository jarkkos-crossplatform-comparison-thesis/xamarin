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
            Navigation.PushAsync(new ButtonLatencyPage());
        }

        private void openLocalListViewTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ListItemsPage(new LocalListItemsLoader()));
        }

        private void openNetworkListViewTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ListItemsPage(new NetworkListItemsLoader()));
        }
        
        private void openHeavyComputationTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new HeavyComputationPage());
        }

        private void openVibrationLatencyTest(object sender, EventArgs args)
        {
            Navigation.PushAsync(new VibrationLatencyPage());
        }

        private void openThirdPartyNoticesPage(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TestNotImplemented());
        }
    }
}