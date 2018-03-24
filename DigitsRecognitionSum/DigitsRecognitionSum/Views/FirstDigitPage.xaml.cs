using DigitsRecognitionSum.Base;
using DigitsRecognitionSum.Services;
using DigitsRecognitionSum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitsRecognitionSum.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstDigitPage : ViewPageBase
    {
		public FirstDigitPage ()
		{
			InitializeComponent ();
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ViewModelBase, string>(this, "clear");
            MessagingCenter.Unsubscribe<ViewModelBase, string>(this, "save");
        }
    }
}