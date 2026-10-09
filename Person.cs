using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace EasyWPF
{
    internal class Person : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Айдишник пользователя (приватный)
        /// </summary>
        public static int id { get; private set; }

        /// <summary>
        /// Айдишник пользователя (публичный)
        /// </summary>
        public int Id { get; } = ++id;


        /// <summary>
        /// Имя пользователя (приватное)
        /// </summary>
        private string _name;
        
        /// <summary>
        /// Имя пользователя (публичное)
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Возарст пользователя (приватный)
        /// </summary>
        private int _age;

        /// <summary>
        /// Возраст пользователя (публичный)
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public Person(string name,  int age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Метод освобождения ресурсов (аналог деструктора)
        /// </summary>
        public void Dispose() => --id;
        

        /// <summary>
        /// Для отображения информации в ListBox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"#{id}. {Name} {Age} лет";
        }


        /// <summary>
        /// Событие, изменяющее значение объекта
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод из INotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName">Название параметра, которое будем менять (берет по правилу CallerMemberName - забирает название свойства вызываемого</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
