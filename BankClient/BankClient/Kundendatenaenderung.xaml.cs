﻿using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Kundendatenaenderung.xaml
    /// </summary>
    public partial class Kundendatenaenderung : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public Kundendatenaenderung()
        {
            InitializeComponent();
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);

            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }

        private void aendern(object sender, RoutedEventArgs e)
        {
            int user = global.getCustID();

            string _vorname = Vorname.Text;
            string _nachname = Nachname.Text;
            string _adresse = Adresse.Text;
            string _wohnort = Wohnort.Text;
            string _telefonnummer = Telefonnummer.Text;

            Bank.changeCustomer(user, _vorname, _nachname, _adresse, _wohnort, _telefonnummer);

            MessageBox.Show("Die Daten wurden erfolgreich geändert");
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }
    }
}
