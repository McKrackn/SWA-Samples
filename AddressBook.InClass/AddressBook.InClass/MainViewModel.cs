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

        public class DateTimeFormat
        {
            public string Name { get; set; }
            public string Format { get; set; }
        }

        public List<DateTimeFormat> SupportedFormats
        {
            get;
        } = new List<DateTimeFormat>()
        {
            new DateTimeFormat(){Format = "T", Name = "Time with seconds"},
            new DateTimeFormat(){Format = "t", Name = "Time without seconds"}
        };

        private DateTimeFormat _selectedDateTimeFormat = null;
        public DateTimeFormat SelectedDateTimeFormat
        {
            get
            {
                if (_selectedDateTimeFormat == null)
                {
                    _selectedDateTimeFormat = SupportedFormats[0];
                }
                return _selectedDateTimeFormat;
            }
            set
            {
                _selectedDateTimeFormat = value;
                RaisePropertyChanged(nameof(CurrentTime));
            }
        }

        public string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString(SelectedDateTimeFormat.Format);
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
