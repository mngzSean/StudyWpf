using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace HelloWorld1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox.Text + "님 환영합니다.", "Hello World");
        }

        private void TextBolck_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hi There!", "Hello world", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
