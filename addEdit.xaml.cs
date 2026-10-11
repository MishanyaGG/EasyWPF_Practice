using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyWPF
{
    /// <summary>
    /// Логика взаимодействия для addEdit.xaml
    /// </summary>
    public partial class addEdit : Window
    {
        public addEdit(Person person = null)
        {
            InitializeComponent();
            DataContext = person ?? new Person("", 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text))
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите корректное имя");
            }
        }
    }
}
