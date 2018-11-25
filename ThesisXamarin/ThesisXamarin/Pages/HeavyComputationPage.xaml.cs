using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisXamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeavyComputationPage : ContentPage
	{
        private CancellationTokenSource curCancellationSource = null;

		public HeavyComputationPage ()
		{
			InitializeComponent ();

            startComputationBtn.Pressed += startComputation;
        }

        private async void startComputation(object sender, EventArgs args)
        {
            stateLabel.Text = "Computing";
            activityIndicator.IsRunning = true;

            curCancellationSource?.Cancel();

            CancellationTokenSource myCancellationSource = new CancellationTokenSource();
            curCancellationSource = myCancellationSource;

            await Task.Run(() => { findPrimesBelow(3000000); });

            if (!myCancellationSource.IsCancellationRequested)
            {
                stateLabel.Text = "Done";
                activityIndicator.IsRunning = false;
            }
        }

        private List<int> findPrimesBelow(int below)
        {
            List<int> primes = new List<int>();

            for (int i = 1; i <= below; ++i)
            {
                if (isPrimeNumber(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        private bool isPrimeNumber(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            double numberSqrt = Math.Sqrt(number);
            for (int i = 2; i <= numberSqrt; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}