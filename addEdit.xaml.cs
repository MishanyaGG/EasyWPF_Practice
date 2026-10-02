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
        public addEdit(string name = "", int age = 0)
        {
            InitializeComponent();
            if (name != "" && age != 0)
            {
                Name.Text = name;
                Age.Text = age.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
