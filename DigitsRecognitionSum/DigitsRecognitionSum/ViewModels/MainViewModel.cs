using DigitsRecognitionSum.Services;
using DigitsRecognitionSum.ViewModels;
using DigitsRecognitionSum.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitsRecognitionSum.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDigitClassifierService _digitClassifierService;

        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private bool _isModelAvailable = false;
        public bool IsModelAvailable
        {
            get { return _isModelAvailable; }
            set
            {
                _isModelAvailable = value;
                OnPropertyChanged(nameof(IsModelAvailable));
            }
        }

        public MainViewModel(INavigationService navigationService, IDigitClassifierService digitClassifierService)
        {
            _navigationService = navigationService;
            _digitClassifierService = digitClassifierService;            
        }

        public void Check()
        {
            var result = Task.Run(() => CheckModel());
            if (result.Result)
            {
                Device.StartTimer(TimeSpan.FromSeconds(2), () =>
                {
                    _navigationService.NavigateToAsync<FirstDigitViewModel>();
                    return false;
                });
            }
        }

        async Task<bool> CheckModel()
        {
            bool result = false;
            IsBusy = true;
            try
            {
                result = await Task.Run(() => _digitClassifierService.IsModelAvalilable);
                IsModelAvailable = true;
                Message = "MNIST model available!";
            }
            catch (Exception ex)
            {
                IsModelAvailable = false;
                Message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
            return result;
        }
    }
}
