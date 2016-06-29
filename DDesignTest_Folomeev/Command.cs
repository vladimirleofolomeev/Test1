﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDesignTest_Folomeev
{
    /// <summary>
    /// Класс, реализующий внешнюю команду
    /// </summary>
    public class Command: ICommand
    {
        private Action _action;
        private bool _isExecutable;

        public event EventHandler CanExecuteChanged;

        public bool IsExecutable
        {
            get { return _isExecutable; }
            set
            {
                _isExecutable = value;
                if (CanExecuteChanged == null)
                {
                    return;
                }
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public Command(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return IsExecutable;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
