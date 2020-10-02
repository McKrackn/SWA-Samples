using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SWA.Highscores.InClass
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _playerName = "no player";

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                if (_playerName == "Daniel")
                {
                    Points = 9001;
                }
                OnPropertyChanged("PlayerName"); // use nameof
            }
        }

        private int _points;

        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
                OnPropertyChanged("Points");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
