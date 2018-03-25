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
            Task.Run(() => Classyfy());            
        }

        async Task<bool> Classyfy()
        {
            IsBusy = true;
            bool result = false;
            try
            {
                var firstNumber = await _digitClassifierService.Classify("");

                var secondNumber = await _digitClassifierService.Classify("");

                Result = (firstNumber + secondNumber).ToString();
                result = true;
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
