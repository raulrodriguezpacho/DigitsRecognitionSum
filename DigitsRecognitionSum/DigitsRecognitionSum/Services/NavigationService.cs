using DigitsRecognitionSum.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitsRecognitionSum.Services
{
    public class NavigationService : INavigationService
    {
        public Page NavigationPage => Application.Current.MainPage;

        private object _navigationData;
        public object NavigationData => _navigationData;

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            _navigationData = parameter;
            return this.NavigationPage.Navigation.PushAsync(GetPageFromViewModel(typeof(TViewModel)), false);
        }

        public Task NavigateBackAsync()
        {
            return this.NavigationPage.Navigation.PopModalAsync(false);
        }

        public Task NavigateToRootAsync()
        {
            return this.NavigationPage.Navigation.PopToRootAsync(false);
        }

        private Page GetPageFromViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace(".ViewModels.", ".Views.").Replace("ViewModel", "Page");
            var viewType = Type.GetType(viewName);
            return (Page)Activator.CreateInstance(viewType);
        }
    }
}
