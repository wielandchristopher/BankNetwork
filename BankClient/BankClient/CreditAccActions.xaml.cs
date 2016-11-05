using System.Windows;

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
    }
}
