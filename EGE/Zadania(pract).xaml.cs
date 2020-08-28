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
using Microsoft.EntityFrameworkCore;
// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace EGE
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Zadania_pract_ : Page
    {
        public Zadania_pract_()
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
        private void Zadaniepract_Click(object sender, TappedRoutedEventArgs e)
        {
            if (numInput.Text.Length > 2)
                return;
            try
            {
                int s = int.Parse(numInput.Text);
            }
            catch (FormatException)
            {
                return;
            }
            if (int.Parse(numInput.Text) >= 1 && int.Parse(numInput.Text) <= 12)
            {
                Task plot = new Task { VariantId = 0, Number = int.Parse(numInput.Text), Subject = 0 };
                this.Frame.Navigate(typeof(MathPract), plot);
            }
        }
        private void Variantpract_Click(object sender, TappedRoutedEventArgs e)
        {
            using (LIS4 db = new LIS4())
            {
                int k = 0;
                Variant variant = new Variant { };
                Task plot = new Task { };
                var variants = db.Variants.FromSql("SELECT * FROM Variants WHERE Status != 0 AND Status != -1 AND Subject = 0 LIMIT 1");
                foreach (var variante in variants)
                {
                    k++;
                    variant = variante;
                    plot = new Task { VariantId = variant.Id, Number = variant.Status + 1, Subject = 0 };
                    this.Frame.Navigate(typeof(MathPract), plot);
                    return;
                }
                variants = db.Variants.FromSql("SELECT * FROM Variants WHERE Status = 0 AND Subject = 0 LIMIT 1");
                foreach (var variante in variants)
                {
                    variant = variante;
                }
                plot = new Task { VariantId = variant.Id , Number = 1, Subject = 0 };
                this.Frame.Navigate(typeof(MathPract), plot);
            }
        }
    }
}
