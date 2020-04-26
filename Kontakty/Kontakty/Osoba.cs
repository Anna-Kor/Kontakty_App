using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kontakty
{
    public class Osoba: INotifyPropertyChanged
    {
        private string _Imie;
        private string _Nazwisko;
        private string _Miasto;
        private string _Zdjecie;
        private string _Przycisk;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string Imie
        {
            get { return _Imie; }
            set
            {
                _Imie = value;
                this.OnPropertyChanged();
            }
        }

        public string Nazwisko
        {
            get { return _Nazwisko; }
            set
            {
                _Nazwisko = value;
                this.OnPropertyChanged();
            }
        }

        public string Miasto
        {
            get { return _Miasto; }
            set
            {
                _Miasto = value;
                this.OnPropertyChanged();
            }
        }

        public string Zdjecie
        {
            get { return _Zdjecie; }
            set
            {
                _Zdjecie = value;
                this.OnPropertyChanged();
            }
        }

        public string Przycisk
        {
            get { return _Przycisk; }
            set
            {
                _Przycisk = value;
                this.OnPropertyChanged();
            }
        }

        public Osoba()
        {

        }

        public Osoba(string _imie, string _nazwisko, string _miasto)
        {
            Imie = _imie;
            Nazwisko = _nazwisko;
            Miasto = _miasto;
        }

        public Osoba(string _imie, string _nazwisko, string _miasto, string _zdjecie)
        {
            Imie = _imie;
            Nazwisko = _nazwisko;
            Miasto = _miasto;
            Zdjecie = _zdjecie;
        }
    }
}
