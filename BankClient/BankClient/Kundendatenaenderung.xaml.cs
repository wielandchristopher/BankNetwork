using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Kundendatenaenderung.xaml
    /// </summary>
    public partial class Kundendatenaenderung : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        public Kundendatenaenderung()
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
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }

        private void aendern(object sender, RoutedEventArgs e)
        {
            int user = global.getCustID();

            string _vorname = Vorname.Text;
            string _nachname = Nachname.Text;
            string _adresse = Adresse.Text + " " + Hausnummer.Text;
            string _wohnort = Postleitzahl.Text + " " + Wohnort.Text;
            string _telefonnummer = Telefonnummer.Text;

            if (IsNumeric(_vorname) == true)
            {
                MessageBox.Show("Gib für den Vornamen bitte einen Text ein");
            }
            else if (IsNumeric(_nachname) == true)
            {
                MessageBox.Show("Gib für den Nachnamen bitte einen Text ein");
            }
            else if (IsNumeric(Adresse.Text) == true)
            {
                MessageBox.Show("Eine Adresse kann nicht aus Zahlen bestehen");
            }
            else if (IsNumeric(Hausnummer.Text) == false)
            {
                MessageBox.Show("Eine Hausnummer kann nur eine Zahl sein");
            }
            else if (IsNumeric(Postleitzahl.Text) == false)
            {
                MessageBox.Show("Eine Postleitzahl kann nur eine Zahl sein");
            }
            else if (IsNumeric(Wohnort.Text) == true)
            {
                MessageBox.Show("Ein Wohnort kann keine Zahl sein");
            }
            else if (IsNumeric(_telefonnummer) == false)
            {
                MessageBox.Show("Eine Telefonnummer kann nur eine Zahl sein");
            }
            else
            {
                MessageBox.Show("Die Daten wurden erfolgreich geändert");
                Bank.changeCustomer(user, _vorname, _nachname, _adresse, _wohnort, _telefonnummer);
            }
            
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }
    }
}
