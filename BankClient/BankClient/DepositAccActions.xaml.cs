using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für DepositAccActions.xaml
    /// </summary>
    public partial class DepositAccActions : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public DepositAccActions()
        {
            InitializeComponent();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);
            global.setCountAcc(0);
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            Kontoverwaltung main = new Kontoverwaltung();
            this.Close();
            main.ShowDialog();
        }

        private void Statement(object sender, RoutedEventArgs e)
        {
            Bankstatement state = new Bankstatement();
            this.Close();
            state.ShowDialog();
        }

        private void Deposit(object sender, RoutedEventArgs e)
        {
            Deposit depo = new Deposit();
            this.Close();
            depo.ShowDialog();
        }

        private void loeschen(object sender, RoutedEventArgs e)
        {
            int Kontonummer = global.getAccnumber();
            int user = global.getCustID();
            if () {
                Bank.deleteSavingsAccount(Kontonummer, user);
            }
            else
            {

            }
            Kontoverwaltung main = new Kontoverwaltung();
            this.Close();
            main.ShowDialog();
        }
    }
}
