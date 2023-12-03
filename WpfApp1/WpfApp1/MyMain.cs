using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    internal class MyMain : Application
    {
        [STAThread]
        public static void Main()
        {
            MyMain app = new MyMain();
            //app.ShutdownMode = ShutdownMode.OnMainWindowClose;

            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Main Window
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;
            mainWindow.Show();

            // SubWindow
            for(int i = 0; i < 2; i++) 
            {
                Window win = new Window();
                win.Title = "Extra Window No." + (i + 1);
                win.ShowInTaskbar = false;
                win.Owner = mainWindow;
                win.Show();
            }
        }

        void WinMouseDown(Object sender, MouseEventArgs args)
        {
            Window win = new Window();
            win.Title = "Modal DialogBox";
            win.Width = 400;
            win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";
            b.Click += Button_Click;

            win.Content = b;
            win.ShowDialog();       // Modal형태
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Click!", sender.ToString());
        }
    }
}
