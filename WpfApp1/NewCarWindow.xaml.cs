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
            FuelTypeCmb.Items.Add("Diesel");
            FuelTypeCmb.Items.Add("LPG");
            FuelTypeCmb.Items.Add("Benzyna");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = new Car();
                car.Model = (Model) ModelCmb.SelectedItem;
                car.FuelType = (string) FuelTypeCmb.SelectedItem;
                car.ProductionYear = Int32.Parse(ProductionYearTxt.Text);
                car.Color = ColorTxt.Text;
                AccessoriesLst.Items.Cast<string>().ToList().ForEach(accessoryName =>
                {
                    Accessory accessory = new Accessory();
                    accessory.Name = accessoryName;
                    car.Accessory.Add(accessory);
                });
                carsEntities.Car.Add(car);
                carsEntities.SaveChanges();
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu danych - sprawdź poprawność wypełnienia formularza");
            }
        }

        private void AddAccessoryButton_Click(object sender, RoutedEventArgs e)
        {
            AccessoriesLst.Items.Add(AccessoryTxt.Text);
            AccessoryTxt.Text = "";
        }
    }
}
