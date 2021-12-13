using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt1_VargaKrisztian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CheckBox> feladatok = new List<CheckBox>();
        List<CheckBox> toroltek = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
            feladatokListaja.ItemsSource = feladatok;
            toroltElemekListaja.ItemsSource = toroltek;

        }

        private void UjHozzaadasa_Click(object sender, RoutedEventArgs e)
        {
            if (feladatSzovege.Text != "")
            {
                CheckBox uj = new CheckBox();
                uj.Content = feladatSzovege.Text;
                uj.Checked += new RoutedEventHandler(CheckBox_Checked);
                uj.Unchecked += new RoutedEventHandler(CheckBox_UnChecked);
                feladatok.Add(uj);
                feladatokListaja.Items.Refresh();
                feladatSzovege.Text = "";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            CheckBox aktualis = (CheckBox)sender;
            aktualis.FontStyle = FontStyles.Italic;
            aktualis.Foreground = Brushes.Gray;
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {

            CheckBox aktualis = (CheckBox)sender;
            aktualis.FontStyle = FontStyles.Normal;
            aktualis.Foreground = Brushes.Black;
        }
        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)feladatokListaja.SelectedItem;
            toroltek.Add(kijelolt);
            feladatok.Remove(kijelolt);
            feladatokListaja.Items.Refresh();
            toroltElemekListaja.Items.Refresh();
        }

        private void VeglegesTorles_Click(object sender, RoutedEventArgs e)
        {
            CheckBox torolt = (CheckBox)toroltElemekListaja.SelectedItem;

            toroltek.Remove(torolt);
            toroltElemekListaja.Items.Refresh();

        }

        private void Visszaallitas_Click(object sender, RoutedEventArgs e)
        {
            CheckBox visszaallitottElem = (CheckBox)toroltElemekListaja.SelectedItem;
            toroltek.Remove(visszaallitottElem);
            feladatok.Add(visszaallitottElem);
            feladatokListaja.Items.Refresh();
            toroltElemekListaja.Items.Refresh();
        }

        private void modositoGomb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox modositando = (CheckBox)feladatokListaja.SelectedItem;
            modositando.Content = feladatSzovege.Text;
            feladatSzovege.Text = "";
        }

        

        private void feladatokListaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckBox szovegKiirasa = (CheckBox)feladatokListaja.SelectedItem;
            if (szovegKiirasa == null)
            {
                return;
            }
            feladatSzovege.Text = szovegKiirasa.Content.ToString();
        }
    }
}
