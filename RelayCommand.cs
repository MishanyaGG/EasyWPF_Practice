using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EasyWPF
{
    internal class RelayCommand : ICommand
    {
        /// <summary>
        /// Действие, которое выполнится при нажатии
        /// </summary>
        private readonly Action<object> _execute; 

        /// <summary>
        /// Условие, разрешающее или запрещающее выполнение
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Метод действия</param>
        /// <param name="canExecute">(опционально) метод проверки условия</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        /// <summary>
        /// Событие, которое уведомляет UI об изменеини возможности выполнения команды
        /// Сообщает интерфейсу, что состояние кнопки (активна/неактивна) могло измениться
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
            // Если условие не задано, команда всегда выполнима
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        /// <summary>
        /// Содержит саму логику, которая должна выполниться
        /// Метод, выполняющий само действие при нажатии на кнопку
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
