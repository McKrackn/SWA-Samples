using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media.Imaging;

namespace AddressBook.InClass.Model
{
    public class Contact
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ObservableCollection<ContactInfo> InfoList { get; }
            = new ObservableCollection<ContactInfo>();

        private BitmapImage _image;
        public BitmapImage Image
        {
            get
            {
                if (_image == null)
                {
                    _image = new BitmapImage(new Uri($"Images/{Lastname}.png", UriKind.Relative));
                }

                return _image;
            }
            set => _image = value;
        }
    }
}
