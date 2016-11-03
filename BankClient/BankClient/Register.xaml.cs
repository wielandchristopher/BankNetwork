using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void registrieren(object sender, RoutedEventArgs e)
        {
            BankManagement Bank = new BankManagement();

            //Hier noch auf fehler Prüfen!!
            string _vorname = Vorname.Text;
            string _nachname = Nachname.Text;
            string _birth = Geburtsdatum.Text;
            string _adresse = Adresse.Text;
            string _wohnort = Wohnort.Text;
            string _telefonnummer = Telefonnummer.Text;

            Bank.createCustomer(_vorname, _nachname, _birth, _adresse, _wohnort, _telefonnummer);

            Register_sucess regsuc = new Register_sucess();
            this.Close();
            regsuc.ShowDialog();
        }
        private void zurück(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }
    }
}
