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
            int Kontonummer = global.getAccnumber();
            if (Bank.getAccType(Kontonummer) == 1)
            {
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            else if(Bank.getAccType(Kontonummer) == 0)
            {
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
            }

            global.setAccnumber(0);
        }

        private void auszug(object sender, RoutedEventArgs e)
        {
            int Kontonummer = global.getAccnumber();

            if (Bank.getAccType(Kontonummer) == 1)
            {
                int Kntnumber = global.getAccnumber();
                Bank.createBankStatement(Kntnumber);
                MessageBox.Show("Der Kontoauszug wurde erstellt");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            else if (Bank.getAccType(Kontonummer) == 0)
            {
                int Kntnumber = global.getAccnumber();
                Bank.createBankStatement(Kntnumber);
                MessageBox.Show("Der Kontoauszug wurde erstellt");
                global.setAccnumber(0);
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
            }

        }
    }
}
