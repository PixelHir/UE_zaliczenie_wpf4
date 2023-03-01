using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using UEWPF3_ListView;

namespace UEWPF4_ListView
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        MainWindow mainWindow;
        public AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(MainWindow mainWin)
        {
            InitializeComponent();
            mainWindow = mainWin;
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            // brak walidacji wpisania danych, zakładam że nie jest potrzebna do zadania
            mainWindow.addPerson(Int32.Parse(this.idField.Text), this.nameField.Text, this.surnameField.Text, Int32.Parse(this.ageField.Text));
            CollectionViewSource.GetDefaultView(mainWindow.lstPersons.ItemsSource).Refresh();
            this.Close();
        }
    }
}
