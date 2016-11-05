using System.Windows;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für DepositAccActions.xaml
    /// </summary>
    public partial class DepositAccActions : Window
    {
        GlobalVariables global = new GlobalVariables();

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
    }
}
