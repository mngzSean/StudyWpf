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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // UI 컨트롤에서 바인딩으로 사용할 소스 속성들
        public bool Seoul {  get; set; }
        public bool Jejoo { get; set; }
        public bool Incheon {  get; set; }

        MyViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            // 바인딩의 소스객체, UI컨트롤에서 별도의 소스 지정없이 사용가능
            // Window의 하위객체에서 소스 속성으로 사용가능
            //this.DataContext = this;

            //create a model object
            _viewModel = new MyViewModel()
            {
                Date = new DateTime(2023, 12, 7),
                Title = "WPF User Group"
            };
            this.DataContext = _viewModel;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("SEOUL: {0},JEJOO: {1}, INCHEON: {2}", Seoul, Jejoo, Incheon));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("{0}\n{1}", _viewModel.Title, _viewModel.Date.ToString()));
        }
    }
}
