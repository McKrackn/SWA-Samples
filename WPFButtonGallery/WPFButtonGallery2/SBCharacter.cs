using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace WPFButtonGallery2
{
    public class SBCharacter : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _job;

        public int Id
        {
            get { return _id; }
            set { this.Set(ref _id, value, nameof(Id)); }
        }


        public string Name
        {
            get { return _name; }
            set => this.Set(ref _name, value, nameof(Name));
        }

        public string Job
        {
            get { return _job; }
            set 
            {
                this.Set(ref _job, value, nameof(Job));
            }
        }

    }
}
