using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandExam
{
    internal class RelayCommand : ICommand
    {
        #region Variables
        Func<object, bool>? canExecute;
        Action<object> executeAction;
        #endregion

        #region Construction/Initialization
        public RelayCommand(Action<object> executeAction) : this(executeAction, null)
        {
        }

        public RelayCommand(Action<object> executeAction, Func<object, bool>? canExecute)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException("Execute Action was null for ICommanding Operation.");
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Member
        // CanExecute 메소드는 명령을 사용 가능하게 하거나 사용 불가능하게 할 때 WPF에 의해 호출
        // 에제와 같은 사용자 정의 명령의 경우 CanExecute 메소드가 알아서 호출되지 않으므로
        // CanExecuteChanged 이벤트를 CommandManager의 RequerySuggested 이벤트에 연결하면 된다.
        public bool CanExecute(object? param)
        {
            if (param is null)
                return false;
            // 사원이름을 입력하지 않으면 Add 버튼은 비활성화 된다.
            if (param.ToString()!.Length == 0) return false;
            bool result = this.canExecute == null ? true :
            this.canExecute.Invoke(param);
            return result;
        }

        public void Execute(object? param)
        {
            //System.Windows.MessageBox.Show(param.ToString());
            if (param is not null)
                this.executeAction.Invoke(param);
        }

        // CanExecuteChanged이벤트를 CommandManager의 RequerySuggested 이벤트에 연결하면
        // CanExecute 메소드가 호출되어 CanExecute의 상태가 변경되고 
        // 이 때 CanExecuteChanged 이벤트가 발생하고
        // WPF는 CanExecute를 호출하고 Command에 연결된 컨트롤의 상태를 변경한다.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

    }
}
