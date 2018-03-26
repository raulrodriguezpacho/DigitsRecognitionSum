using DigitsRecognitionSum.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DigitsRecognitionSum.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDigitClassifierService _digitClassifierService;

        private string _result = "?";
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private string _resultFirstDigit = "";
        public string ResultFirstDigit
        {
            get { return _resultFirstDigit; }
            set
            {
                _resultFirstDigit = value;
                OnPropertyChanged(nameof(ResultFirstDigit));
            }
        }

        private string _resultSecondDigit = "";
        public string ResultSecondDigit
        {
            get { return _resultSecondDigit; }
            set
            {
                _resultSecondDigit = value;
                OnPropertyChanged(nameof(ResultSecondDigit));
            }
        }

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

        public ResultViewModel(INavigationService navigationService, IDigitClassifierService digitClassifierService)
        {
            _navigationService = navigationService;
            _digitClassifierService = digitClassifierService;            
            Task.Run(() => Recognize());            
        }

        async Task<bool> Recognize()
        {
            IsBusy = true;
            bool result = false;
            try
            {
                int? init = _digitClassifierService.Initialize();
                if (init.HasValue)
                {
                    var firstNumber = await _digitClassifierService.RecognizeDigit("/DCIM/DRS/drs28_1.jpg");
                    ResultFirstDigit = firstNumber.ToString();
                    var secondNumber = await _digitClassifierService.RecognizeDigit("/DCIM/DRS/drs28_2.jpg");
                    ResultSecondDigit = secondNumber.ToString();
                    Result = (firstNumber + secondNumber).ToString();                    
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
            return result;
        }

        private ICommand _startAgainCommand;
        public ICommand StartAgainCommand
        {
            get
            {
                return _startAgainCommand ?? (_startAgainCommand = new Command(() =>
                {                    
                    _navigationService.NavigateToRootAsync();
                }));
            }
        }
    }
}
