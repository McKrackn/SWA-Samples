using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight;

namespace WPFButtonGallery2
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<SBCharacter> Characters { get; } = new ObservableCollection<SBCharacter>();
        public MainViewModel()
        {
            Characters.Add(new SBCharacter(){ Id = 1, Name = "SpongeBob", Job = "Cook"});
            Characters.Add(new SBCharacter(){ Id = 2, Name = "Patrick", Job = "unemployed"});
            Characters.Add(new SBCharacter(){ Id = 3, Name = "Squidward", Job = "Cashier" });
        }
    }
}
