using DigitsRecognitionSum.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitsRecognitionSum.Services
{
    public interface INavigationService
    {
        Page NavigationPage { get; }
        object NavigationData { get; }
        Task NavigateBackAsync();
        Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : ViewModelBase;
        Task NavigateToRootAsync();
    }
}
