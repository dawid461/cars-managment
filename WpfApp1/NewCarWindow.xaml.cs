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
    /// Logika interakcji dla klasy NewCarWindow.xaml
    /// </summary>
    public partial class NewCarWindow : Window
    {
        /// <summary>
        /// Odwołanie do bazy danych
        /// </summary>
        private CarsEntities carsEntities = new CarsEntities();

        public NewCarWindow()
        {
            InitializeComponent();
            ModelCmb.ItemsSource = carsEntities.Model.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
