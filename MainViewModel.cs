using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EasyWPF
{
    internal class MainViewModel
    {
        /// <summary>
        /// ObservableCollection автоматически уведомляет интерфейс об добавлении/удалении элементов
        /// </summary>
        public ObservableCollection<Person> People { get; private set; }

        private Person _selectedPerson;
        
        /// <summary>
        /// Свойство для хранения выбранного в списке элемента
        /// </summary>
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;

                // Принудительно заставляем кнопки перепроверить их состояние (CanExecute)
                // Это нужно, чтобы кнопки "Редактировать" и "Удалить" активировались при выборе элемента
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommmand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
            People.Add(new Person("GG", 12));

            // Инициализируем команды, передавая имена методов
            // null для AddCommand означает, что кнопка "Добавить" всегда активна
            AddCommand = new RelayCommand(OnAdd, null);
            EditCommmand = new RelayCommand(OnEdit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(OnDelete,CanEditOrDelete);
        }

        // Метод для открытия модального окна
        private bool OpenDialog(Person person)
        {
            addEdit dialog = new addEdit(person);
            dialog.Owner = Application.Current.MainWindow; // Делаем главное окно родителем

            bool? result = dialog.ShowDialog(); // Показываем окно модально

            if (result != null)
            {
                return (bool)result; // Возвращаем true, если DialogResult был установлен в true
            }
            return false;
        }

        // --- Методы логики (заменяют код из MainWindow.xaml.cs) ---

        private void OnAdd(object parameter)
        {
            // Создаем нового человека с пустыми данными
            Person newPerson = new Person("", 0);

            // Открываем диалог. Если пользователь нажал "Сохранить", добавляем в коллекцию
            if (OpenDialog(newPerson))
            {
                People.Add(newPerson);
            }
        }

        private void OnEdit(object parameter)
        {
            if (SelectedPerson != null)
            {
                // Передаем выбранного человека в диалог. 
                // Благодаря привязкам, изменения в окне сразу применятся к этому объекту
                OpenDialog(SelectedPerson);
            }
        }

        private void OnDelete(object parameter)
        {
            if (SelectedPerson != null)
            {
                People.Remove(SelectedPerson); // Коллекция сама обновит интерфейс
                SelectedPerson = null;         // Сбрасываем выделение
            }
        }

        // Условие для кнопок: они активны только если выбран элемент в списке
        private bool CanEditOrDelete(object parameter)
        {
            return SelectedPerson != null;
        }

    }
}
