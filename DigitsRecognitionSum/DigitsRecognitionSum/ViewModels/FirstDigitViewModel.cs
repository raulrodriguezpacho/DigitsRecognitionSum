using DigitsRecognitionSum.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DigitsRecognitionSum.ViewModels
{
    public class FirstDigitViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDeviceService _deviceService;

        private double _digitSize = 28;
        public double DigitSize
        {
            get { return _digitSize; }
            set
            {
                _digitSize = value;
                OnPropertyChanged(nameof(DigitSize));
            }
        }
        
        public FirstDigitViewModel(INavigationService navigationService, IDeviceService deviceService)
        {
            _navigationService = navigationService;
            _deviceService = deviceService;

            var deviceSize = _deviceService.GetDeviceSize();
            DigitSize = (int)deviceSize.Width;            
        }

        private ICommand _sumCommand;
        public ICommand SumCommand
        {
            get
            {
                return _sumCommand ?? (_sumCommand = new Command(() =>
                {                    
                    MessagingCenter.Send<ViewModelBase, string>(this, "save", "1");
                    _navigationService.NavigateToAsync<SecondDigitViewModel>();
                }));
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new Command(() =>
                {                    
                    MessagingCenter.Send<ViewModelBase, string>(this, "clear", "1");                    
                }));
            }
        }
    }
}
