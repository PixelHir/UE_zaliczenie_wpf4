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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.ComponentModel;

namespace UEWPF3_ListView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainWindow;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(MainWindow mainWin)
        {
            InitializeComponent();
            mainWindow = mainWin;
            var item = mainWindow.lstPersons.SelectedItem as Person;
            if (item != null)
            {
                gridPersonForm.DataContext = item;
            }
        }

        private void btnOdczytaj_Click(object sender, RoutedEventArgs e)
        {
            txtOdczytaj.Text = gridPersonForm.DataContext.ToString();
            ICollectionView view =
            CollectionViewSource.GetDefaultView(mainWindow.lstPersons.ItemsSource);
            view.Refresh();
        }
    }
}
