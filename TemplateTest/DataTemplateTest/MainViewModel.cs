using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateTest
{
    class MainViewModel 
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Student> students = default!;
        public MainViewModel()
        {
            Students = Student.Students;
        }

        public List<Student> Students 
        { 
            get => students; 
            set
            { 
                students = value; 
                OnPropertyChanged();
            } 
        }
    }
}
