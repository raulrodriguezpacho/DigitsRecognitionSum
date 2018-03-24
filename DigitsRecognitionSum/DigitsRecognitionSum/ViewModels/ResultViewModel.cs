using DigitsRecognitionSum.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DigitsRecognitionSum.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

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

        public ResultViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private ICommand _startAgainCommand;
        public ICommand StartAgainCommand
        {
            get
            {
                return _startAgainCommand ?? (_startAgainCommand = new Command(() =>
                {
                    // TODO


                    _navigationService.NavigateToRootAsync();
                }));
            }
        }
    }
}
