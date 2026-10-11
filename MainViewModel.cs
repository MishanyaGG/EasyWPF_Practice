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
        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommmand { get; }

        public ICommand DeleteCommand { get; }

        private bool OpenDialog(Person person)
        {
            var dialog = new addEdit(person);
            dialog.Owner = Application.Current.MainWindow;
            return dialog.ShowDialog() == true;
        }
        
        public void AddPerson()
        {
            var person = new Person("", 0);
            if (OpenDialog(person))
            {
                People.Add(person);
            }
        }

        public void EditPerson()
        {
            if (OpenDialog(SelectedPerson))
            {

            }
        }

        public void DeletePerson()
        {
            if (SelectedPerson != null)
            {
                People.Remove(SelectedPerson);
                SelectedPerson = null;
            }
        }


        public MainViewModel()
        {
            People.Add(new Person("GG", 12));
            AddCommand = new RelayCommand(_ => AddPerson());
            EditCommmand = new RelayCommand(_ => EditPerson(), _ => SelectedPerson != null);
            DeleteCommand = new RelayCommand(_ => DeletePerson(), _ => SelectedPerson != null);
        }


    }
}
