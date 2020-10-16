using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Bimaru.SWA.InClass
{
    public class MainViewModel : ViewModelBase
    {
        private RawBoardProvider _provider;

        public Board Board { get; }

        private string _message;
        public string Message
        {
            get => _message;
            set => Set(ref _message, value, nameof(Message));
        }

        public RelayCommand<string> ToggleCommand { get; set; }

        public MainViewModel()
        {
            _provider = new RawBoardProvider();
            this.Board = new Board(_provider.GetBoardRaw());
            this.ToggleCommand= new RelayCommand<string>(Toggle, CanExecuteToggle);
        }

        private bool CanExecuteToggle(string arg)
        {
            return true;
            // return !Board.IsPreset(int.Parse(arg));
        }

        public void Toggle (string index)
        {
            int integerIndex = int.Parse(index);
            Board.Toggle(integerIndex);
            Message = $"Toggled at {integerIndex}";
            RaisePropertyChanged(nameof(Board));

            if (Board.CheckSolved())
            {
                Message = Message + Environment.NewLine + "congrats";
            }
        }
    }
}
