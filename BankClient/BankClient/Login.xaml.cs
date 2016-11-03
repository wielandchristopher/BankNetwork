using System.Windows;
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void einloggen(object sender, RoutedEventArgs e)
        {
            //öffne Kontoverwaltungsfenster und hole mit eingegebenen Daten getCustomer
            BankManagement Bank = new BankManagement();
            GlobalVariables global = new GlobalVariables();
            //Hier noch auf fehler Prüfen!!
            string _vorname = Vorname.Text;
            string _nachname = Nachname.Text;
            string _birth = Geburtsdatum.Text;

            global.setCustID(Bank.getCustomer(_vorname, _nachname, _birth));

            Startseite main = new Startseite();
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
