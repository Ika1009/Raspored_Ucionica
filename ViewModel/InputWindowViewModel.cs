using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Raspored_Ucionica.ViewModel
{
    public class InputWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        bool checked11;
        public bool Checked11
        {
            get => checked11;
            set
            {
                checked11 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
            }
        }
        bool checked12;
        public bool Checked12
        {
            get => checked12;
            set
            {
                checked12 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
            }
        }
        bool checked13;
        public bool Checked13
        {
            get => checked13;
            set
            {
                checked13 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
            }
        }
        bool checked21;
        public bool Checked21
        {
            get => checked21;
            set
            {
                checked21 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked22;
        public bool Checked22
        {
            get => checked22;
            set
            {
                checked22 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked23;
        public bool Checked23
        {
            get => checked23;
            set
            {
                checked23 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked31;
        public bool Checked31
        {
            get => checked31;
            set
            {
                checked31 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked32;
        public bool Checked32
        {
            get => checked32;
            set
            {
                checked32 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked33;
        public bool Checked33
        {
            get => checked33;
            set
            {
                checked33 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked41;
        public bool Checked41
        {
            get => checked41;
            set
            {
                checked41 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked42;
        public bool Checked42
        {
            get => checked42;
            set
            {
                checked42 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        bool checked43;
        public bool Checked43
        {
            get => checked43;
            set
            {
                checked43 = value;
                Broj_lutajucih++;
                NotifyPropertyChanged();
                }
            }
        int broj_lutajucih;
        public int Broj_lutajucih 
        { 
            get => broj_lutajucih;
            set
            {
                if(broj_lutajucih != value)
                {
                    broj_lutajucih = value;
                    NotifyPropertyChanged();
                } 
            } 
        }
        public InputWindowViewModel()
        {
            checked11 = false;
            Broj_lutajucih = 0;
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
