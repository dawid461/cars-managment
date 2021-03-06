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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku "Samochody"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarsButton_Click(object sender, RoutedEventArgs e)
        {
            new CarsWindow().ShowDialog();
        }

        private void MakesButton_Click(object sender, RoutedEventArgs e)
        {
            new MakesWindow().ShowDialog();
        }

        private void ModelsButton_Click(object sender, RoutedEventArgs e)
        {
            new ModelsWindow().ShowDialog();
        }
    }
}
