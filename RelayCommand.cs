using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EasyWPF
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        /// <summary>
        /// Событие, которое уведомляет UI об изменеини возможности выполнения команды
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        /// <summary>
        /// Определяет, можно ли выполнить команду в данный момент
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (CanExecute != null)
                return _canExecute(parameter);

            return false;
        }

        /// <summary>
        /// Содержит саму логику, которая должна выполниться
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
