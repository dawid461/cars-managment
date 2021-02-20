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
    /// Logika interakcji dla klasy NewModelWindow.xaml
    /// </summary>
    public partial class NewModelWindow : Window
    {
        /// <summary>
        /// Odwołanie do bazy danych
        /// </summary>
        private CarsEntities carsEntities = new CarsEntities();

        public NewModelWindow()
        {
            InitializeComponent();
            MakeCmb.ItemsSource = carsEntities.Make.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model model = new Model();
                model.Make = (Make)MakeCmb.SelectedItem;
                model.HorsePower = Int32.Parse(HorsePowerTxt.Text);
                model.EngineCapacity = Int32.Parse(EngineCapacityTxt.Text);
                model.Name = NameTxt.Text;
                carsEntities.Model.Add(model);
                carsEntities.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu danych - sprawdź poprawność wypełnienia formularza");
            }
        }
    }
}
