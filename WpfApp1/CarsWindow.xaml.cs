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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
       /// <summary>
       /// Odwołanie do bazy danych
       /// </summary>
        private CarsEntities carsEntities = new CarsEntities();

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        public CarsWindow()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        /// <summary>
        /// Aktualizacja tabeli samochodów.
        /// </summary>
        private void UpdateDataGrid()
        {
            DataGrid.ItemsSource = carsEntities.Car.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car) DataGrid.SelectedItem;
            carsEntities.Car.Remove(car);
            carsEntities.SaveChanges();
            UpdateDataGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new NewCarWindow().ShowDialog();
        }
    }
}
