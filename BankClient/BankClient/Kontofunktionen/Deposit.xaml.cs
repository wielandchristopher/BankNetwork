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

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        public Deposit()
        {
            InitializeComponent();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);
            global.setAccnumber("0");
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            string Kontonummer = global.getAccnumber();

            if (Bank.getAccType(Kontonummer) == 1)
            {
                  global.setAccnumber("0");
                  CreditAccActions cKonto = new CreditAccActions();
                  this.Close();
                  cKonto.ShowDialog();
            }
            else if(Bank.getAccType(Kontonummer) == 0)
            {
                global.setAccnumber("0");
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
            }
        }

        private void einzahlen(object sender, RoutedEventArgs e)
        {
            string betr = Betrag.Text;
            string verwe = Verwendung.Text;

            if (IsNumeric(betr) == false)
            {
                MessageBox.Show("Der Betrag kann kein Text sein");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            else if (IsNumeric(verwe) == true)
            {
                MessageBox.Show("Gib für den Verwendungszweck bitte einen Text ein");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            else {
                double betrag = double.Parse(betr, System.Globalization.CultureInfo.InvariantCulture);

                string Kontonummer = global.getAccnumber();

                if (Bank.getAccType(Kontonummer) == 1)
                {
                string Kntnumber = global.getAccnumber();
                Bank.depositCreditAcc(Kntnumber, verwe, betrag);
                MessageBox.Show("Der Betrag wurde erfolgreich eingezahlt");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
                }
                else if(Bank.getAccType(Kontonummer) == 0)
                {
                    string Kntnumber = global.getAccnumber();
                    Bank.depositSavingsAcc(Kntnumber, verwe, betrag);
                    MessageBox.Show("Der Betrag wurde erfolgreich eingezahlt");                   
                    DepositAccActions dKonto = new DepositAccActions();
                    this.Close();
                    dKonto.ShowDialog();
                }
            }           
        }
    }
}
