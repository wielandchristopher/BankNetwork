using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Transfer.xaml
    /// </summary>

    public partial class Transfer : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        public Transfer()
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
            string Kontonummer = global.getAccnumber();

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
        }

        private void transfer(object sender, RoutedEventArgs e)
        {
            if (IsNumeric(zielknt.Text) == false)
            {
                MessageBox.Show("Die Kontonummer muss aus Zahlen bestehen");
            }
            else if (IsNumeric(Betrag.Text) == false)
            {
                MessageBox.Show("Der Betrag muss aus Zahlen bestehen");
            }
            else if (IsNumeric(Verwendung.Text) == true)
            {
                MessageBox.Show("Geben Sie für den Verwendungszweck bitte einen Text ein");
            }
            else
            {
                string Kntnumber = global.getAccnumber();
                string bic = Bank.getBankBIC().ToString();
                string zielkonto = zielknt.Text;
                string zielkonto_BIC = zielknt_BIC.Text;
                string verwe = Verwendung.Text;
                double betrag = double.Parse(Betrag.Text, System.Globalization.CultureInfo.InvariantCulture);

                Transaction transaction = new Transaction(Kntnumber, bic, zielkonto, zielkonto_BIC, betrag, ECurrency.Euro, verwe);    // zur zeit nur euro

                if(betrag > 0)
                {
                    // credit
                    if (global.getAcctype() == 0)
                    {
                        Bank.withdrawCreditAcc(Kntnumber, betrag);
                    }
                    else
                    {
                        Bank.withdrawCreditAcc(Kntnumber, betrag);
                    }
                }

                Bank.send(transaction);     
                Bank.receive();

                MessageBox.Show("Der Betrag wurde erfolgreich überwiesen");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
        }
    }
}
