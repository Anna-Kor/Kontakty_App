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
using Windows.UI.Xaml.Navigation;

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
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            kolekcjaOsob.Add(new Osoba("Jan", "Kowalski", "Warszawa", "ms-appx:///Assets/JanKowalski.jfif"));
            kolekcjaOsob.Add(new Osoba("Ala", "Nowak", "Biała Podlaska", "ms-appx:///Assets/AlaNowak.jfif"));
            this.DataContext = this;
            listBoxDane.ItemsSource = kolekcjaOsob;
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            Osoba o = new Osoba();
            o.Przycisk = "dodaj";
            var parameters = o;

            this.Frame.Navigate(typeof(Szczegoly), parameters);
        }

        private void usunButton_Click(object sender, RoutedEventArgs e)
        {
            kolekcjaOsob.Remove(kolekcjaOsob[listBoxDane.SelectedIndex]);
        }

        private void modyfikujButton_Click(object sender, RoutedEventArgs e)
        {
            kolekcjaOsob[listBoxDane.SelectedIndex].Przycisk = "modyfikuj";
            var parameters = kolekcjaOsob[listBoxDane.SelectedIndex];

            this.Frame.Navigate(typeof(Szczegoly), parameters);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter.GetType() != typeof(string))
            {
                Osoba o = (Osoba)e.Parameter;
                if (o.Przycisk == "zapisz")
                {
                    kolekcjaOsob.Add((Osoba)e.Parameter);
                }
                else if (o.Przycisk == "modyfikuj")
                {
                    var parameters = (Osoba)e.Parameter;
                    kolekcjaOsob[listBoxDane.SelectedIndex] = parameters;
                }
            }
        }

        private void szczegolyButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = kolekcjaOsob[listBoxDane.SelectedIndex];
            parameters.Przycisk = "szczegoly";

            this.Frame.Navigate(typeof(Szczegoly), parameters);
        }
    }
}
