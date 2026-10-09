using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EasyWPF
{
    internal class Person : IDisposable
    {
        /// <summary>
        /// Айдишник пользователя
        /// </summary>
        public static int id { get; private set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст пользователя
        /// </summary>
        public int Age { get; set; }

        public Person(string name,  int age)
        {
            Name = name;
            Age = age;
            ++id;
        }

        /// <summary>
        /// Метод освобождения ресурсов (аналог деструктора)
        /// </summary>
        public void Dispose() 
        {
            --id;
        }

        /// <summary>
        /// Для отображения информации в ListBox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"#{id}. {Name} {Age} лет";
        }
    }
}
