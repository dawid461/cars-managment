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
    /// Logika interakcji dla klasy NewMakeWindow.xaml
    /// </summary>
    public partial class NewMakeWindow : Window
    {
        /// <summary>
        /// Odwołanie do bazy danych
        /// </summary>
        private CarsEntities carsEntities = new CarsEntities();

        public NewMakeWindow()
        {
            InitializeComponent();
            CountryCmb.Items.Add("Włochy");
            CountryCmb.Items.Add("Japonia");
            CountryCmb.Items.Add("Korea");
            CountryCmb.Items.Add("Niemcy");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Make make = new Make();
            make.Name = NameTxt.Text;
            make.FoundationYear= Int32.Parse(FoundationYearTxt.Text);
            make.Country = CountryCmb.Text;
            carsEntities.Make.Add(make);
            carsEntities.SaveChanges();
            Close();
        }
    }
}
