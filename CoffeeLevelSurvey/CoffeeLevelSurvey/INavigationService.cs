using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace CoffeeLevelSurvey
{
    public interface INavigationService
    {
        string CurrentViewModelName { get; }
        ViewModelBase GetViewModel(string viewModelName);
    }
}
