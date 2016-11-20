using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für CreditAccActions.xaml
    /// </summary>
    public partial class CreditAccActions : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public CreditAccActions()
        {
            InitializeComponent();
            Kontostandx.Text = (Bank.getCreditkontostand(global.getAccnumber()).ToString());
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
            global.setCountAcc(0);
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void transfer(object sender, RoutedEventArgs e)
        {
            Transfer trans = new Transfer();
            this.Close();
            trans.ShowDialog();
        }

        private void Withdraw(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            this.Close();
            with.ShowDialog();
        }

        private void Deposit(object sender, RoutedEventArgs e)
        {
            Deposit depo = new Deposit();
            this.Close();
            depo.ShowDialog();
        }

        private void Statement(object sender, RoutedEventArgs e)
        {
            Bankstatement state = new Bankstatement();
            this.Close();
            state.ShowDialog();
        }

        private void loeschen(object sender, RoutedEventArgs e)
        {
            string Kontonummer = global.getAccnumber();
            int user = global.getCustID();
            if (Bank.getCreditkontostand(Kontonummer) == 0)
            {
                global.setCountAcc(global.getCountAcc() - 1);
                Bank.deleteCreditAccount(Kontonummer, user);
            }
            else
            {
                MessageBox.Show("Bitte gleiche zuerst den Kontostand aus(0)");
            }
            Kontoverwaltung main = new Kontoverwaltung();
            this.Close();
            main.ShowDialog();
        }

        private void add_user(object sender, RoutedEventArgs e)
        {
            addUser addu = new addUser();
            this.Close();
            addu.ShowDialog();
        }

        private void delete_user(object sender, RoutedEventArgs e)
        {
            deleteUser delu = new deleteUser();
            this.Close();
            delu.ShowDialog();
        }
    }
}
