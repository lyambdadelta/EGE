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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace EGE
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class mathTeor1 : Page
    {
        public mathTeor1()
        {
            this.InitializeComponent();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Rait_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rait));
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        private void Zadanieteor_Click(object sender, TappedRoutedEventArgs e)
        {
            if (nameInput.Text == "1")
                this.Frame.Navigate(typeof(mathTeor1));
            if (nameInput.Text == "2")
                this.Frame.Navigate(typeof(MathTeor2));
            if (nameInput.Text == "3")
                this.Frame.Navigate(typeof(MathTeor3));
            if (nameInput.Text == "4")
                this.Frame.Navigate(typeof(MathTeor4));
            if (nameInput.Text == "5")
                this.Frame.Navigate(typeof(MathTeor5));
            if (nameInput.Text == "6")
                this.Frame.Navigate(typeof(MathTeor6));
            if (nameInput.Text == "7")
                this.Frame.Navigate(typeof(MathTeor7));
            if (nameInput.Text == "8")
                this.Frame.Navigate(typeof(MathTeor8));
            if (nameInput.Text == "9")
                this.Frame.Navigate(typeof(MathTeor9));
            if (nameInput.Text == "10")
                this.Frame.Navigate(typeof(MathTeor10));
            if (nameInput.Text == "11")
                this.Frame.Navigate(typeof(MathTeor11));
            if (nameInput.Text == "12")
                this.Frame.Navigate(typeof(MathTeor12));
        }
    }
}
