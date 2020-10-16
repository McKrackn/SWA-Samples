using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SWA.Highscores.InClass.Model;

namespace SWA.Highscores.InClass
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<HighScoreItem> HighScoreItems { get; set; }

        #region Properties for Textboxes

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

        #endregion

        public RelayCommand AddCommand { get; set; }

        public MainViewModel()
        {
            HighScoreItems = new ObservableCollection<HighScoreItem>();
            HighScoreItems.Add(new HighScoreItem()
            {
                Name = "Isabella", Points = 800
            });
            HighScoreItems.Add(new HighScoreItem()
            {
                Name = "Benedikt R", Points = 1340
            });

            // AddCommand = new RelayCommand(new Action<object>(Add)); // long version
            // AddCommand = new RelayCommand((parameter) => Add(parameter),
            //                               (parameter) => this.Points > 0);
            AddCommand = new RelayCommand(Add, CanAdd); // short version
        }

        private bool CanAdd(object parameter)
        {
            return this.Points > 0;
        }

        private void Add(object parameter)
        {
            // Observable Collection does the magic to update UI
            HighScoreItems.Add(new HighScoreItem()
            {
                Name = this.PlayerName,
                Points = this.Points,
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
