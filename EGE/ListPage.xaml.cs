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
    public sealed partial class ListPage : Page
    {
        public ListPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (LIS4 db = new LIS4())
            {
                companiesList.ItemsSource = db.Variants.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CompanyPage));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделеный пункт меню
            if (companiesList.SelectedItem != null)
            {
                Variant company = companiesList.SelectedItem as Variant;
                if (company != null)
                    Frame.Navigate(typeof(CompanyPage), company.Id);
            }
        }
        private void PhonesList_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PhonesListPage));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделеный пункт меню
            if (companiesList.SelectedItem != null)
            {
                Variant company = companiesList.SelectedItem as Variant;
                if (company != null)
                {
                    using (LIS4 db = new LIS4())
                    {
                        db.Variants.Remove(company);
                        db.SaveChanges();
                        companiesList.ItemsSource = db.Variants.ToList();
                    }
                }
            }
        }
    }
}
