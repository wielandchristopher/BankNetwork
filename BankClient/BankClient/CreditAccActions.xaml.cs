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

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für CreditAccActions.xaml
    /// </summary>
    public partial class CreditAccActions : Window
    {
        GlobalVariables global = new GlobalVariables();

        public CreditAccActions()
        {
            InitializeComponent();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            Kontoverwaltung main = new Kontoverwaltung();
            this.Close();
            main.ShowDialog();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);

            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void transfer(object sender, RoutedEventArgs e)
        {

        }

        private void Withdraw(object sender, RoutedEventArgs e)
        {

        }

        private void Deposit(object sender, RoutedEventArgs e)
        {

        }

        private void Statement(object sender, RoutedEventArgs e)
        {

        }
    }
}
