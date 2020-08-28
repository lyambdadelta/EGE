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
    public sealed partial class RusTeor : Page
    {
        Task com = new Task { };
        Task plot = new Task { };
        Variant variant = new Variant { };
        public RusTeor()
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
        private void Rusteor_Click(object sender, TappedRoutedEventArgs e)
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
            if (int.Parse(numInput.Text) >= 1 && int.Parse(numInput.Text) <= 25)
            {
                Task plot = new Task { VariantId = -1, Number = int.Parse(numInput.Text), Subject = 1 };
                this.Frame.Navigate(typeof(RusTeor), plot);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {

                plot = (Task)e.Parameter;
                textBlock.Text = "Задание " + plot.Number;
                using (LIS4 db = new LIS4())
                {
                    var comps = db.Tasks.FromSql("SELECT * FROM Tasks WHERE Subject = {0} AND Number = {1} AND Status = 0 AND VariantId = -1 LIMIT 1", plot.Subject, plot.Number).ToList();
                    foreach (var comp in comps)
                    {
                        com = comp;
                    }
                    if (com.VariantId != 0)
                    {
                        var variants = db.Variants.FromSql("SELECT * FROM Variants WHERE Id = {0} LIMIT 1", com.VariantId);
                        foreach (var variante in variants)
                        {
                            variant = variante;
                        }
                    }
                }
                if (com.Text != null)
                    Quest.Text = com.Text + '\n' + '\r';
                else
                    Quest.Text = "Поздравляем, вы тра-та-та, заданий нет, не нажимайте, пожалуйста, кнопку ответить";
                if (com.ImageQuest != 0)
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage
                    {
                        UriSource = new Uri("ms-appx:///assets/images/" + com.Id + ".1" + ".jpg")
                    };
                    imageQuest.Source = bitmap;
                }
            }
        }
    }
}
