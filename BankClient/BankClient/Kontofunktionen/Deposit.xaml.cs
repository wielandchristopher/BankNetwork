using System.Windows;
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
            global.setAccnumber(0);
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
            //{
                  global.setAccnumber(0);
                  CreditAccActions cKonto = new CreditAccActions();
                  this.Close();
                  cKonto.ShowDialog();
            //}
            //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
            //{
            //    global.setAccnumber(0);
            //    DepositAccActions dKonto = new DepositAccActions();
            //    this.Close();
            //    dKonto.ShowDialog();
            //}
        }

        private void einzahlen(object sender, RoutedEventArgs e)
        {
            string betr = Betrag.Text;
            string verwe = Verwendung.Text;
            double betrag = double.Parse(betr, System.Globalization.CultureInfo.InvariantCulture);

            //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
            //{
                 int Kntnumber = global.getAccnumber();
                 Bank.depositCreditAcc(Kntnumber, verwe, betrag);
                 MessageBox.Show("Der Betrag wurde erfolgreich eingezahlt");
                 CreditAccActions cKonto = new CreditAccActions();
                 this.Close();
                 cKonto.ShowDialog();
            //}
            //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
            //{
            //    int Kntnumber = global.getDepositAccnumber();
            //    Bank.depositSavingsAcc(Kntnumber, verwe, betrag);
            //    MessageBox.Show("Der Betrag wurde erfolgreich eingezahlt");
            //    global.setDepositAccnumber(0);
            //    DepositAccActions dKonto = new DepositAccActions();
            //    this.Close();
            //    dKonto.ShowDialog();
            //}
        }
    }
}
