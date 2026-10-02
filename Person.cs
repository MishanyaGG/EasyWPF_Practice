using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EasyWPF
{
    internal class Person : IDisposable
    {
        public static int id { get; private set; }
        public string Name { get; set; }
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

        public override string ToString()
        {
            return $"#{id}. {Name} {Age} лет";
        }
    }
}
