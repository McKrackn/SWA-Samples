using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace CoffeeLevelSurvey
{
    public class DefaultNavigationService : INavigationService
    {
        public string CurrentViewModelName { get; private set; }

        public ViewModelBase GetViewModel(string viewModelName)
        {
            CurrentViewModelName = viewModelName;
            if (CurrentViewModelName == "insert new record")
            {
                return SimpleIoc.Default.GetInstance<InsertSurveyRecordViewModel>();
            }
            return SimpleIoc.Default.GetInstance<ShowCurrentStateViewModel>();
        }
    }
}
