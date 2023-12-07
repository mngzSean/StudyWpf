using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void RunAnything(Label lbl);
        RunAnything Run;

        public MainWindow()
        {
            InitializeComponent();

            //Run = RunAnything_;
            Run = RunAnthingAsync;
        }

        private void RunAnything_(Label lbl)
        {
            for(int i = 0; i < 30; i++)
            {
                Thread.Sleep(100);
                lbl.Content = i.ToString();
            }
        }

        private async void RunAnthingAsync(Label lbl)
        {
            for (int i = 0; i < 30; i++)
            {
                await Task.Delay(100);
                lbl.Content = i.ToString();
            }
        }

        private void btnTalk_Click(object sender, RoutedEventArgs e)
        {
            Run(lblTalk);
        }

        private void btnPhone_Click(object sender, RoutedEventArgs e)
        {
            Run(lblPhone);
        }

        private void btnWalk_Click(object sender, RoutedEventArgs e)
        {
            Run(lblWalk);
        }

        // Task를 반환해야 await 키워드를 사용할 수 있다.
        private async Task RunAllAsync(Label lbl)
        {
            for (int i = 0; i < 30; i++)
            {
                await Task.Delay(100);
                lbAll.Items.Add(lbl.Name + i.ToString());
            }
        }

        //private void btnAll_Click(object sender, RoutedEventArgs e)
        //{
        //    RunAllAsync(lblWalk);
        //    RunAllAsync(lblPhone);
        //    RunAllAsync(lblTalk);
        //}
        private async void btnAll_Click(object sender, RoutedEventArgs e)
        {
            await RunAllAsync(lblWalk);
            await RunAllAsync(lblPhone);
            await RunAllAsync(lblTalk);
        }

    }
}
