using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Kundendatenaenderung.xaml
    /// </summary>
    public partial class Kundendatenaenderung : Window
    {
        public Kundendatenaenderung()
        {
            InitializeComponent();
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
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
            BankManagement Bank = new BankManagement();
            GlobalVariables global = new GlobalVariables();

            int user = global.getCustID();

            string _vorname = Vorname.Text;
            string _nachname = Nachname.Text;
            string _adresse = Adresse.Text;
            string _wohnort = Wohnort.Text;
            string _telefonnummer = Telefonnummer.Text;

            Bank.changeCustomer(user, _vorname, _nachname, _adresse, _wohnort, _telefonnummer);

            Kundendatenaenderung_success Kundendatensuc = new Kundendatenaenderung_success();
            this.Close();
            Kundendatensuc.ShowDialog();
        }
    }
}
