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
    public sealed partial class Rait : Page
    {
        public Rait()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Out.Text = "";
            using (LIS4 db = new LIS4())
            {
                Task com = new Task { };
                Variant variant = new Variant { };
                int i;
                for(i = 1; i <= 12; i++)
                {
                    float k = 0, p = 0;
                    Out.Text += "Математика, задание " + i + ": "; 
                    var comps = db.Tasks.FromSql("SELECT * FROM Tasks WHERE Subject = 0 AND Number = {0} AND Status != 0 ", i).ToList();
                    foreach (var comp in comps)
                    {
                        k++;
                        if (comp.Status == 1)
                            p += comp.Result;
                    }
                    if (k == 0)
                        Out.Text += "не приступали" + '\n' + '\r';
                    else
                    {
                        float t = p*100/k;
                        Out.Text += "Верно решено " + p + " из " + k + " ~(" + Convert.ToInt32(t) + "%)" + '\n' + '\r';
                    }
                }
                for (i = 1; i <= 24; i++)
                {
                    float k = 0, p = 0, f;
                    Out.Text += "Русский язык, задание " + i + ":";
                    var comps = db.Tasks.FromSql("SELECT * FROM Tasks WHERE Subject = 1 AND Number = {0} AND Status != 0 ", i).ToList();
                    foreach (var comp in comps)
                    {
                        k++;
                        com = comp;
                        if (comp.Status == 1)
                            p += comp.Result;
                    }
                    if (k == 0)
                        Out.Text += "не приступали" + '\n' + '\r';
                    else
                    {
                        if ((com.Number == 1) || (com.Number == 15))
                            f = 2;
                        else if (com.Number == 24)
                            f = 4;
                        else if (com.Number == 7)
                            f = 5;
                        else
                            f = 1;
                            float t = p * 100 / (f*k);
                        Out.Text += "Верно решено " + p/f + " из " + k + " ~(" + Convert.ToInt32(t) + "%)" + '\n' + '\r';
                    }
                }
            }
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Rait_Click(object sender, RoutedEventArgs e)
        {
            using (LIS4 db = new LIS4())
            {
                Variant variant = new Variant { };
                var variants = db.Variants.FromSql("SELECT * FROM Variants WHERE Status != 0");
                foreach (var variante in variants)
                {
                    variant = variante;
                    variant.Sum = 0;
                    variant.Status = 0;
                    db.Variants.Update(variant);
                }
                Task task = new Task { };
                var tasks = db.Tasks.FromSql("SELECT * FROM Tasks WHERE Status != 0");
                foreach (var taskes in tasks)
                {
                    task = taskes;
                    task.Status = 0;
                    task.Result = 0;
                    db.Tasks.Update(task);
                }
                db.SaveChanges();
                this.Frame.Navigate(typeof(MainPage));
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
