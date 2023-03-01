using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using UEWPF4_ListView;

namespace UEWPF3_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> ListOfPersons = null;
        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }

        public void addPerson(int id, string name, string surname, int age)
        {
            ListOfPersons.Add(new Person(id, name, surname, age));
        }

        private void InitBinding()
        {
            ListOfPersons = new List<Person>();
            ListOfPersons.Add(new Person(1, "Adam", "Kowalski", 24));
            ListOfPersons.Add(new Person(2, "Jan", "Kowalski", 23));
            ListOfPersons.Add(new Person(3, "Agnieszka", "Kowalczyk", 28));
            ListOfPersons.Add(new Person(4, "Janusz", "Abacki", 25));
            lstPersons.ItemsSource = ListOfPersons;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstPersons.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Person).LastName.IndexOf(txtFilter.Text,
                StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstPersons.ItemsSource).Refresh();
        }

        private void lstPersons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 okno1 = new Window1(this);
            okno1.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = lstPersons.SelectedItem as Person;
            if (item != null)
            {
                MessageBoxResult result = MessageBox.Show("Czy wykasować osobę: " +
                item.ToString(), "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ListOfPersons.Remove(item); // kasujemy z listy (kolekcji)
                                                // ICollectionView wymaga using System.ComponentModel;
                    ICollectionView view =
                    CollectionViewSource.GetDefaultView(lstPersons.ItemsSource);
                    view.Refresh(); // odświeżenie ListView (na podstawie aktualnej zawartości listy)
                }
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWin = new AddWindow(this);
            addWin.Show();
        }
    }
}
