using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        BankManagement Bank = new BankManagement();

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        public Register()
        {
            InitializeComponent();
        }
        private void registrieren(object sender, RoutedEventArgs e)
        {
            //Hier noch auf fehler Prüfen!!
            string _vorname = Vorname.Text;
            string _nachname = Nachname.Text;
            string _birth = Geburtsdatum.Text;
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
            else if (IsNumeric(_birth) == false)
            {
                MessageBox.Show("Gib bitte einen richtigen Geburtstag ein");
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
                Bank.createCustomer(_vorname, _nachname, _birth, _adresse, _wohnort, _telefonnummer);
                MessageBox.Show("Sie wurden erfolgreich registriert");
                
            }
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }
        private void zurück(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }
    }
}
