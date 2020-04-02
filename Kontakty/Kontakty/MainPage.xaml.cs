using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Kontakty
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Osoba> kolekcjaOsob = new ObservableCollection<Osoba>();

        public MainPage()
        {
            this.InitializeComponent();
            kolekcjaOsob.Add(new Osoba("Jan", "Kowalski", "Warszawa", "ms-appx:///Assets/JanKowalski.jfif"));
            kolekcjaOsob.Add(new Osoba("Ala", "Nowak", "Biała Podlaska", "ms-appx:///Assets/AlaNowak.jfif"));
            this.DataContext = this;
            listBoxDane.ItemsSource = kolekcjaOsob;
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (bi.UriSource == null)
            {
                kolekcjaOsob.Add(new Osoba(imieTextBox.Text, nazwiskoTextBox.Text, miastoTextBox.Text));
            }
            else
            {
                kolekcjaOsob.Add(new Osoba(imieTextBox.Text, nazwiskoTextBox.Text, miastoTextBox.Text, bi.UriSource.ToString()));
            }
        }

        private void usunButton_Click(object sender, RoutedEventArgs e)
        {
            kolekcjaOsob.Remove(kolekcjaOsob[listBoxDane.SelectedIndex]);
        }

        private void modyfikujButton_Click(object sender, RoutedEventArgs e)
        {
            Osoba o = kolekcjaOsob[listBoxDane.SelectedIndex];
            o.Imie = imieTextBox.Text;
            o.Nazwisko = nazwiskoTextBox.Text;
            o.Miasto = miastoTextBox.Text;
            if (bi.UriSource != null)
            {
                o.Zdjecie = bi.UriSource.ToString();
            }
        }

        private void szczegolyButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = kolekcjaOsob[listBoxDane.SelectedIndex];

            this.Frame.Navigate(typeof(Szczegoly), parameters);
        }

        private async void zdjecieBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Osoba o = kolekcjaOsob[listBoxDane.SelectedIndex];

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                 o.Zdjecie = file.Path;
            }
        }
    }
}
