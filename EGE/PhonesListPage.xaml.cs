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
    public sealed partial class PhonesListPage : Page
    {
        Task task;

        public PhonesListPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (LIS4 db = new LIS4())
            {
                phonesList.ItemsSource = db.Tasks.ToList();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                int id = (int)e.Parameter;
                using (LIS4 db = new LIS4())
                {
                    task = db.Tasks.FirstOrDefault(c => c.Id == id);
                }
            }

            if (task != null)
            {
                subjectBox.Text = task.Subject.ToString();
                numberBox.Text = task.Number.ToString();
                statusBox.Text = task.Status.ToString();
                textBox.Text = task.Text;
                solutionBox.Text = task.Solution;
                answerBox.Text = task.Answer;
                resultBox.Text = task.Result.ToString();
                variantIdBox.Text = task.VariantId.ToString();
                imageBox.Text = task.ImageQuest.ToString();
                imansBox.Text = task.ImageAnswer.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (LIS4 db = new LIS4())
            {
                if (task != null)
                {
                    task.Subject = int.Parse(subjectBox.Text);
                    task.Number = int.Parse(numberBox.Text);
                    task.Status = int.Parse(statusBox.Text);
                    task.Text = textBox.Text;
                    task.Answer = answerBox.Text;
                    task.Solution = solutionBox.Text;
                    task.VariantId = int.Parse(variantIdBox.Text);
                    task.Result = int.Parse(resultBox.Text);
                    task.ImageQuest = Int16.Parse(imageBox.Text);
                    task.ImageAnswer = Int16.Parse(imansBox.Text);
                    numberBox.Text = (task.Number + 1).ToString();
                    db.Tasks.Update(task);
                }
                else
                {
                    db.Tasks.Add(new Task { Subject = int.Parse(subjectBox.Text), Number = int.Parse(numberBox.Text), Status = int.Parse(statusBox.Text), Text = textBox.Text, Solution = solutionBox.Text, Answer = answerBox.Text, Result = int.Parse(resultBox.Text), VariantId = int.Parse(variantIdBox.Text) });
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

