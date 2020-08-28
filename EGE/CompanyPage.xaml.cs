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
    public sealed partial class CompanyPage : Page
    {
        Variant variant;

        public CompanyPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                int id = (int)e.Parameter;
                using (LIS4 db = new LIS4())
                {
                    variant = db.Variants.FirstOrDefault(c => c.Id == id);
                }
            }

            if (variant != null)
            {
                headerBlock.Text = "Редактирование компании";
                subjectBox.Text = variant.Subject.ToString();
                sumBox.Text = variant.Sum.ToString();
                statusBox.Text = variant.Status.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (LIS4 db = new LIS4())
            {
                if (variant != null)
                {
                    variant.Subject = int.Parse(subjectBox.Text);
                    variant.Sum = int.Parse(sumBox.Text);
                    variant.Status = int.Parse(statusBox.Text);
                    db.Variants.Update(variant);
                }
                else
                {
                    db.Variants.Add(new Variant { Subject = int.Parse(subjectBox.Text), Sum = int.Parse(sumBox.Text), Status = int.Parse(statusBox.Text) });
                }
                db.SaveChanges();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            GoToMainPage();
        }

        private void GoToMainPage()
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
            else
                Frame.Navigate(typeof(MainPage));
        }
    }
}
