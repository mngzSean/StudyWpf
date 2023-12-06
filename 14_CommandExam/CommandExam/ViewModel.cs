using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandExam
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Emp? _SelectedEmp;
        public Emp? SelectedEmp
        {
            get
            {
                return _SelectedEmp;
            }

            set 
            {
                _SelectedEmp = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? Pname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Pname));
        }

        public RelayCommand AddEmpCommand { get; set; }

        public ObservableCollection<Emp> Emps { get; set; }

        public ViewModel()
        {
            Emps = new ObservableCollection<Emp>()
            {
                new Emp{ Ename = "홍길동", Job = "Salesman" },
                new Emp{ Ename = "김길동", Job = "Clerk" },
                new Emp{ Ename = "정길동", Job = "Manager" },
                new Emp{ Ename = "박길동", Job = "Salesman" },
                new Emp{ Ename = "성길동", Job = "Clerk" },
            };

            AddEmpCommand = new RelayCommand(AddEmp);
        }

        public void AddEmp(object param)
        {
            Emps.Add(new Emp { Ename = param.ToString(), Job="New Job" });
        }
    }
}
