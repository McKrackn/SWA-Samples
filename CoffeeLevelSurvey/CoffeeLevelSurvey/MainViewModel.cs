using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace CoffeeLevelSurvey
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

        public RelayCommand RequestNewSurveyRecordCommand { get; set; }

        private ViewModelBase _currentViewModel = null;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                this.Set(ref _currentViewModel, value, nameof(CurrentViewModel));
                RequestNewSurveyRecordCommand?.RaiseCanExecuteChanged();
            }
        }

        private INavigationService _navigationService;

        public MainViewModel(INavigationService naviagationService)
        {
            this._navigationService = naviagationService;

            CurrentViewModel = _navigationService.GetViewModel("show current state");
            
            RequestNewSurveyRecordCommand = new RelayCommand(() => {
                CurrentViewModel = _navigationService.GetViewModel("insert new record");
            }, 
            () => _navigationService.CurrentViewModelName == "show current state");

            this.MessengerInstance.Register<NewSurveyRecordMessage>(this, message =>
            {
                Log.Add($"{DateTime.Now:T}: {message.Level}");
                CurrentViewModel = _navigationService.GetViewModel("show current state");
            });
        }
    }
}
