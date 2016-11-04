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
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Deposit.xaml
    /// </summary>
    

    public partial class Deposit : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public Deposit()
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
    }
}
