using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;

namespace CoffeeLevelSurvey
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<INavigationService>(() => new DefaultNavigationService());
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<InsertSurveyRecordViewModel>();
            SimpleIoc.Default.Register<ShowCurrentStateViewModel>();
        }
        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
        public InsertSurveyRecordViewModel InsertSurveyRecord => SimpleIoc.Default.GetInstance<InsertSurveyRecordViewModel>();
        public ShowCurrentStateViewModel ShowCurrentState => SimpleIoc.Default.GetInstance<ShowCurrentStateViewModel>();
    }
}
