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
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Transfer.xaml
    /// </summary>

    

    public partial class Transfer : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public Transfer()
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
            //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
            //{
            CreditAccActions cKonto = new CreditAccActions();
            this.Close();
            cKonto.ShowDialog();
            //}
            //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
            //{
            //    DepositAccActions dKonto = new DepositAccActions();
            //    this.Close();
            //    dKonto.ShowDialog();
            //}
        }

        private void transfer(object sender, RoutedEventArgs e)
        {
            int zielkonto = int.Parse(zielknt.Text); ;
            double betrag = double.Parse(Betrag.Text, System.Globalization.CultureInfo.InvariantCulture);
            int Kntnumber = global.getCreditAccnumber();
            string verwe = Verwendung.Text;

            Bank.transfer(Kntnumber, zielkonto, verwe, betrag);
            MessageBox.Show("Der Betrag wurde erfolgreich überwiesen");
            CreditAccActions cKonto = new CreditAccActions();
            this.Close();
            cKonto.ShowDialog();
        }
    }
}
