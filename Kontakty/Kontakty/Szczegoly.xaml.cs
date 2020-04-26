using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Kontakty
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Szczegoly : Page
    {
        public Szczegoly()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButton.IsEnabled = this.Frame.CanGoBack;
                Osoba o = (Osoba)e.Parameter;
                if (o.Przycisk == "szczegoly")
                {
                    base.OnNavigatedTo(e);
                    var parameters = (Osoba)e.Parameter;
                    this.DataContext = parameters;
                    edycjaImienia.IsEnabled = false;
                    edycjaNazwiska.IsEnabled = false;
                    edycjaMiasta.IsEnabled = false;
                    edycjaZdjecia.IsTapEnabled = false;
                    przyciskZapisz.IsEnabled = false;
                    przyciskZapisz.Visibility = Visibility.Collapsed;
                    przyciskModyfikuj.IsEnabled = false;
                    przyciskModyfikuj.Visibility = Visibility.Collapsed;
                    zmienZdjecie.IsEnabled = false;
                    zmienZdjecie.Visibility = Visibility.Collapsed;
                }
                else if (o.Przycisk == "dodaj")
                {
                    base.OnNavigatedTo(e);
                    przyciskModyfikuj.IsEnabled = false;
                    przyciskModyfikuj.Visibility = Visibility.Collapsed;
                }
                else if (o.Przycisk == "modyfikuj")
                {
                    base.OnNavigatedTo(e);
                    var parameters = (Osoba)e.Parameter;
                    this.DataContext = parameters;
                    przyciskZapisz.IsEnabled = false;
                    przyciskZapisz.Visibility = Visibility.Collapsed;
                }
            
        }

        private void przyciskZapisz_Click(object sender, RoutedEventArgs e)
        {
            if (bi2.UriSource == null)
            {
                var parameters = (new Osoba(edycjaImienia.Text, edycjaNazwiska.Text, edycjaMiasta.Text));
                parameters.Przycisk = "zapisz";
                this.Frame.Navigate(typeof(MainPage), parameters);
            }
            else
            {
                var parameters = (new Osoba(edycjaImienia.Text, edycjaNazwiska.Text, edycjaMiasta.Text, bi2.UriSource.ToString()));
                parameters.Przycisk = "zapisz";
                this.Frame.Navigate(typeof(MainPage), parameters);
            }
            
        }

        private void przyciskModyfikuj_Click(object sender, RoutedEventArgs e)
        {
            if (bi2.UriSource == null)
            {
                var parameters = (new Osoba(edycjaImienia.Text, edycjaNazwiska.Text, edycjaMiasta.Text));
                parameters.Przycisk = "modyfikuj";
                this.Frame.Navigate(typeof(MainPage), parameters);
            }
            else
            {
                var parameters = (new Osoba(edycjaImienia.Text, edycjaNazwiska.Text, edycjaMiasta.Text, bi2.UriSource.ToString()));
                parameters.Przycisk = "modyfikuj";
                this.Frame.Navigate(typeof(MainPage), parameters);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private async void zmienZdjecie_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();

            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                await bi2.SetSourceAsync(fileStream);
                edycjaZdjecia.Source = bi2;
            }
        }
    }
}
