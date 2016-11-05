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
                int zielkonto = int.Parse(zielknt.Text);
                double betrag = double.Parse(Betrag.Text, System.Globalization.CultureInfo.InvariantCulture);
                int Kntnumber = global.getAccnumber();
                string verwe = Verwendung.Text;

                Bank.transfer(Kntnumber, zielkonto, verwe, betrag);
                MessageBox.Show("Der Betrag wurde erfolgreich überwiesen");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
        }
    }
}
