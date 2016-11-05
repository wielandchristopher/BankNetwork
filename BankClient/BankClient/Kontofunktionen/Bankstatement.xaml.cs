using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Bankstatement.xaml
    /// </summary>

    public partial class Bankstatement : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public Bankstatement()
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
            global.setAccnumber(0);

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

        private void auszug(object sender, RoutedEventArgs e)
        {
            //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
            //{
            int Kntnumber = global.getAccnumber();
            Bank.createBankStatement(Kntnumber);
            MessageBox.Show("Der Kontoauszug wurde erstellt");
            CreditAccActions cKonto = new CreditAccActions();
            this.Close();
            cKonto.ShowDialog();
            //}
            //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
            //{
            //    int Kntnumber = global.getDepositAccnumber();
            //    Bank.createBankStatement(Kntnumber);
            //    MessageBox.Show("Der Kontoauszug wurde erstellt");
            //    global.setDepositAccnumber(0);
            //    DepositAccActions dKonto = new DepositAccActions();
            //    this.Close();
            //    dKonto.ShowDialog();
            //}

        }
    }
}
