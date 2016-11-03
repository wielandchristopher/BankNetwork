using System.Windows;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Startseite.xaml
    /// </summary>
    public partial class Startseite : Window
    {
        public Startseite()
        {
            InitializeComponent();
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            //Login login = new Login();
            //login.getCustID();

            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Kundendatenaenderung(object sender, RoutedEventArgs e)
        {
            Kundendatenaenderung Kunde  = new Kundendatenaenderung();
            this.Close();
            Kunde.ShowDialog();
        }

        private void Kontoverwaltung(object sender, RoutedEventArgs e)
        {
            Kontoverwaltung Konto = new Kontoverwaltung();
            this.Close();
            Konto.ShowDialog();
        }
    }
}
