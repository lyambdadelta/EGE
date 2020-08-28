using Microsoft.EntityFrameworkCore;
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
    public sealed partial class MathPract : Page
    {
        Task com = new Task { };
        Task plot = new Task { };
        Variant variant = new Variant { };

        public MathPract()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {

                plot = (Task)e.Parameter;
                textBlock.Text = "Задание " + plot.Number;
                using (LIS4 db = new LIS4())
                {
                    var comps = db.Tasks.FromSql("SELECT * FROM Tasks WHERE Subject = {0} AND Number = {1} AND Status = 0 AND VariantId = {2} LIMIT 1", plot.Subject, plot.Number, plot.VariantId).ToList();
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
                        variant.Status = plot.Number;
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

        private void Mathpract_Click(object sender, TappedRoutedEventArgs e)
        {
            int k = 1, p;
            if (plot.Subject == 0 || plot.Subject == 1 && (plot.Number == 1 || plot.Number == 3 || plot.Number == 7 || plot.Number > 13 && plot.Number < 25 && plot.Number != 22))
            {
                try
                {
                    float s = float.Parse(answerInput.Text);
                }
                catch (System.FormatException)
                {
                    k = 2;
                }
                for(p = 0; p < answerInput.Text.Length; p++)
                {
                    if (answerInput.Text[p] == '.')
                        k = 3;
                }
                if (plot.Subject == 1 && ((plot.Number == 1 || plot.Number == 15) && answerInput.Text.Length != 2 || plot.Number == 24 && answerInput.Text.Length != 4 || plot.Number == 7 && answerInput.Text.Length != 5))
                    k = 2;
                if (k == 2)
                    Quest.Text = com.Text + '\n' + '\r' + "Введите корректный ответ";
                if (k == 3)
                    Quest.Text = com.Text + '\n' + '\r' + "Введите корректный ответ, заменив запятую на точку.";
            }
            textBlock.Text = "Задание " + plot.Number;
            if (com.Status != 0 && k == 1)
            {
                if (plot.VariantId != 0)
                    plot.Number++;
                if ((plot.Subject == 0 && plot.Number == 13) || (plot.Subject == 1 && plot.Number == 25))
                {
                    this.Frame.Navigate(typeof(MainPage));
                    variant.Status = -1;
                    using (LIS4 db = new LIS4())
                    {
                        db.Variants.Update(variant);
                        db.SaveChanges();
                        return;
                    }
                }
                else
                    this.Frame.Navigate(typeof(MathPract), plot);
            }
            if (k == 1)
            {
                if (com.Subject == 0)
                {
                    if (answerInput.Text == com.Answer)
                        com.Status = com.Result = 1;
                    else
                    {
                        com.Result = 0;
                        com.Status = -1;
                    }
                    variant.Sum += com.Result;
                }
                else if (com.Subject == 1)
                {
                    if (com.Number == 1 || com.Number == 15 || com.Number == 7 || com.Number == 24)
                    {
                        int coun = 1;
                        if (com.Number == 1 || com.Number == 15)
                            coun = 2;
                        if (com.Number == 24)
                            coun = 4;
                        if (com.Number == 7)
                            coun = 5;
                        for (int i = 0; i < coun; i++)
                            if (com.Answer[i] == answerInput.Text[i])
                                com.Result++;
                        if (com.Result > 0)
                            com.Status = 1;
                        else com.Status = -1;
                    }
                    else if (com.Answer == answerInput.Text)
                        com.Result = com.Status = 1;
                    else
                        com.Status = -1;
                }
                Quest.Text = com.Text + '\n' + '\r';
                Answer.Text = "Ваш ответ : " + answerInput.Text + '\n' + '\r' + "Верный ответ: " + com.Answer + '\n' + '\r' + com.Solution;
                if (com.ImageAnswer != 0)
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmap.UriSource = new Uri("ms-appx:///assets/images/" + com.Id + ".2" + ".jpg");
                    imageAnswer.Source = bitmap;
                }
                k = 0;
                using (LIS4 db = new LIS4())
                {
                    db.Tasks.Update(com);
                    db.Variants.Update(variant);
                    db.SaveChanges();
                }

            }
        }
    }
}