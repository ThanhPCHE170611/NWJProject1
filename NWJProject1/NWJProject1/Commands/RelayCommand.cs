﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NWJProject1.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<Object> _Execute {  get; set; }
        private Predicate<Object> _CanExecute { get; set; }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
           _Execute(parameter);
        }
    }
}
