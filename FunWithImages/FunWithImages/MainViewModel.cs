using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;

namespace FunWithImages
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BitmapImage Image1 { get; set; }
        public BitmapImage Image2 { get; set; }
        public BitmapImage Image3 { get; set; }

        public MainViewModel()
        {
            // check Images folder's images property window
            // each should set its properties as follows
            //    build process: content (Buildvorgang: Inhalt)
            //    copy to output folder: copy always (In Ausgabeverzeichnis kopieren: Immer kopieren)
            Image1 = new BitmapImage(new Uri("Images/1.png", UriKind.Relative));
            Image2 = new BitmapImage(new Uri("Images/2.png", UriKind.Relative));
            Image3 = new BitmapImage(new Uri("Images/3.png", UriKind.Relative));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
