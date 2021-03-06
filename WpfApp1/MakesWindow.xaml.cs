﻿using System;
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
    /// Logika interakcji dla klasy MakesWindow.xaml
    /// </summary>
    public partial class MakesWindow : Window
    {
        /// <summary>
        /// Odwołanie do bazy danych
        /// </summary>
        private CarsEntities carsEntities = new CarsEntities();

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        public MakesWindow()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        /// <summary>
        /// Aktualizacja tabeli marek.
        /// </summary>
        private void UpdateDataGrid()
        {
            DataGrid.ItemsSource = carsEntities.Make.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Make make = (Make)DataGrid.SelectedItem;
            make.Model.ToList().ForEach(m =>
            {
                m.Car.ToList().ForEach(c => {
                    c.Accessory.ToList().ForEach(a => carsEntities.Accessory.Remove(a));
                    carsEntities.Car.Remove(c);
                });
                carsEntities.Model.Remove(m);
            });
           
            carsEntities.Make.Remove(make);
            carsEntities.SaveChanges();
            UpdateDataGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new NewMakeWindow().ShowDialog();
            UpdateDataGrid();
        }
    }
}
