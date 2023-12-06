using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HelloWorld
{
    class MainWIndowViewModel
    {
        //private ICommand? _ButtonCommand;
        //public ICommand? ButtonCommand
        //{
        //    get
        //    {
        //        return _ButtonCommand;
        //    }
        //    set
        //    {
        //        _ButtonCommand = value;
        //    }
        //}
        public ICommand ButtonCommand { get; set; }

        public MainWIndowViewModel()
        {
            ButtonCommand = new RelayCommand(param =>
            {
                MessageBox.Show("Hi~ " + param.ToString());
            });
        }
    }
}
