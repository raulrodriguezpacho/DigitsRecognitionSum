using Autofac.Core;
using DigitsRecognitionSum.Base;
using DigitsRecognitionSum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DigitsRecognitionSum
{
	public partial class App : Application
	{		
        public App(IModule platformModule)
        {
            LocatorBase.Register(platformModule, false);
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
