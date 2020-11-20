using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WPFButtonGallery
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isSpecial = true;
        private string _state= "created...";

        public bool IsSpecial
        {
            get => _isSpecial;
            set => this.Set(ref _isSpecial, value, nameof(IsSpecial));
        }

        public string State
        {
            get { return _state; }
            set { this.Set(ref _state, value, nameof(State)); }
        }

        public RelayCommand SquidwardTentaclesActivatedCommand { get; }

        public MainViewModel()
        {
            SquidwardTentaclesActivatedCommand = new RelayCommand(() => State = "Squidward got focus");
        }
    }
}
