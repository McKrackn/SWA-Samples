using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AddressBook.InClass
{
    public class MainViewModel : ViewModelBase
    {
        public ContactStore ContactStore { get; }
        public event EventHandler<EventArgs> CloseRequested;

        private DispatcherTimer _timer;

        public string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString("T");
            }
        }

        public RelayCommand ExitCommand { get; set; }

        public MainViewModel(ContactStore contactStore)
        {
            this.ContactStore = contactStore;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            // _timer.Tick += (sender, e) => RaisePropertyChanged(nameof(CurrentTime));
            _timer.Tick += _timer_Tick;
            _timer.Start();

            ExitCommand = new RelayCommand(() =>
            {
                CloseRequested?.Invoke(this, EventArgs.Empty);
            });
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            RaisePropertyChanged(nameof(CurrentTime));
        }
    }

}
