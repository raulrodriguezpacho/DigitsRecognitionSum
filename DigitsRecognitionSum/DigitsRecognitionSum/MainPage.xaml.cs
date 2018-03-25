using DigitsRecognitionSum.Base;
using DigitsRecognitionSum.ViewModels;
using DigitsRecognitionSum.Views;
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
    public partial class MainPage : ViewPageBase
    {
		public MainPage()
		{
			InitializeComponent();            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainViewModel)this.BindingContext).Check();
        }
    }
}
