using System.Windows;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Kontoverwaltung.xaml
    /// </summary>
    public partial class Kontoverwaltung : Window
    {
        public Kontoverwaltung()
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

        private void Zurück(object sender, RoutedEventArgs e)
        {
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }
    }
}
