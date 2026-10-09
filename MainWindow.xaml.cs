using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Событие при КНОПКЕ добавления пользователя
        /// Подписка на событие win_closing_Add()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_click(object sender, RoutedEventArgs e)
        {
            addEdit winEdit = new addEdit();
            winEdit.Closing += win_closing_Add;
            
            winEdit.ShowDialog();
        }

        /// <summary>
        /// Реализация добавления пользователя в список
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void win_closing_Add(object sender, System.ComponentModel.CancelEventArgs e)
        {
            addEdit addEdit = sender as addEdit;
            if (!(string.IsNullOrEmpty(addEdit.Name.Text) && string.IsNullOrEmpty(addEdit.Age.Text)))
                ListPerson.Items.Add(new Person(addEdit.Name.Text, int.Parse(addEdit.Age.Text)));
        }

        /// <summary>
        /// Событие при КНОПКЕ удаления пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_click(object sender, RoutedEventArgs e)
        {
            if (ListPerson.SelectedItem != null)
            {
                Person person = ListPerson.SelectedItem as Person;
                ListPerson.Items.Remove(ListPerson.SelectedItem);
                person.Dispose();
            }
        }

        /// <summary>
        /// Событие при КНОПКЕ редактирования пользователя
        /// Подписка на событие win_closing_Edit()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (ListPerson.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пользователя");
            }

            Person person = ListPerson.SelectedItem as Person;
            addEdit winEdit = new addEdit(person.Name, person.Age);
            winEdit.Closing += win_closing_Edit;

            winEdit.ShowDialog();
        }


        /// <summary>
        /// Реализация отображения изменных данных пользователя в список
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void win_closing_Edit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            addEdit addEdit = sender as addEdit;
            Person person = ListPerson.SelectedItem as Person;

            person.Name = addEdit.Name.Text;
            person.Age = int.Parse(addEdit.Age.Text);
            ListPerson.Items.Refresh();
        }
    }
}