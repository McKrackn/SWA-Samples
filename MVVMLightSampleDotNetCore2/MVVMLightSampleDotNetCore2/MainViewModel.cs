using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVMLightSampleDotNetCore2
{
    public class MainViewModel : ViewModelBase
    {
        private string _title;

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                Title = "Main (Design)";
            }
            else
            {
                Title = "Main (Live)";
            }

            SetTitleCommand = new RelayCommand(
                () =>
                {
                    Title = $"Changed at {DateTime.Now.Second}";
                });
        }

        public RelayCommand SetTitleCommand { get; set; }= null;
        public string Title
        {
            get => _title; 
            set => Set(ref _title, value, nameof(Title)); 
        }
    }
}
