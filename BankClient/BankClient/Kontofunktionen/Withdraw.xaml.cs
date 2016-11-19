using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        public Withdraw()
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
            CreditAccActions cKonto = new CreditAccActions();
            this.Close();
            cKonto.ShowDialog();
        }

        private void abbuchen(object sender, RoutedEventArgs e)
        {
            if (IsNumeric(Betrag.Text) == true)
            {
                double betrag = double.Parse(Betrag.Text, System.Globalization.CultureInfo.InvariantCulture);
                long Kntnumber = global.getAccnumber();
                Bank.withdrawCreditAcc(Kntnumber, betrag);
                MessageBox.Show("Der Betrag wurde erfolgreich abgebucht");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Die Eingabe ist falsch");
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            
        }

    }
}
