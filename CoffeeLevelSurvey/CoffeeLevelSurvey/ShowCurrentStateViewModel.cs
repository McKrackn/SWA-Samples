using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace CoffeeLevelSurvey
{
    public class ShowCurrentStateViewModel : ViewModelBase
    {
        public string State { get; set; }
        public ShowCurrentStateViewModel()
        {
            State = "?";

            this.MessengerInstance.Register<NewSurveyRecordMessage>(this, message =>
            {
                State = message.Level;
                this.RaisePropertyChanged(nameof(State));
            });
        }
    }
}
