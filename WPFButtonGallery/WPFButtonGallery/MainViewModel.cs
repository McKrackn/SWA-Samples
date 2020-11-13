using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace WPFButtonGallery
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isSpecial = true;

        public bool IsSpecial
        {
            get => _isSpecial;
            set => this.Set(ref _isSpecial, value, nameof(IsSpecial));
        }
    }
}
