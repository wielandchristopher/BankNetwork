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
    /// Interaktionslogik für Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public Withdraw()
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
            global.setCreditAccnumber(0);
            CreditAccActions cKonto = new CreditAccActions();
            this.Close();
            cKonto.ShowDialog();
        }

        private void abbuchen(object sender, RoutedEventArgs e)
        {
            double betrag = double.Parse(Betrag.Text, System.Globalization.CultureInfo.InvariantCulture);
            int Kntnumber = global.getCreditAccnumber();
            Bank.withdrawCreditAcc(Kntnumber, betrag);
            MessageBox.Show("Der Betrag wurde erfolgreich abgebucht");
            CreditAccActions cKonto = new CreditAccActions();
            this.Close();
            cKonto.ShowDialog();
        }
    }
}
