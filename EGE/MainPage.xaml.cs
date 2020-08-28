using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace EGE
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Pract(object sender, TappedRoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(Pract));
            }
        }
        private void Teor(object sender, TappedRoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(Teor));
            }
        }

        private void CloseApp(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Rait_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rait));
        }

        private void Rait(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rait));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
