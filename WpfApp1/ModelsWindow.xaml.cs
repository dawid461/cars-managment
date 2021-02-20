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
    /// Logika interakcji dla klasy ModelsWindow.xaml
    /// </summary>
    public partial class ModelsWindow : Window
    {
        /// <summary>
        /// Odwołanie do bazy danych
        /// </summary>
        private CarsEntities carsEntities = new CarsEntities();

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        public ModelsWindow()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        /// <summary>
        /// Aktualizacja tabeli modeli.
        /// </summary>
        private void UpdateDataGrid()
        {
            DataGrid.ItemsSource = carsEntities.Model.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Model model = (Model) DataGrid.SelectedItem;
            model.Car.ToList().ForEach(c => {
                c.Accessory.ToList().ForEach(a => carsEntities.Accessory.Remove(a));
                carsEntities.Car.Remove(c);
            });
            carsEntities.Model.Remove(model);
            carsEntities.SaveChanges();
            UpdateDataGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new NewModelWindow().ShowDialog();
            UpdateDataGrid();
        }

    }
}
