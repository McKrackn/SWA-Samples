using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CoffeeLevelSurvey
{
    public class InsertSurveyRecordViewModel : ViewModelBase
    {
        public RelayCommand<string> InsertSurveyEntryCommand { get; set; }

        public InsertSurveyRecordViewModel()
        {
            InsertSurveyEntryCommand = new RelayCommand<string>(level =>
                //Log.Add($"{DateTime.Now:T}: {level}")
                this.MessengerInstance.Send(new NewSurveyRecordMessage(){Level = level}));
        }
    }
}
