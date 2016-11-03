using System.Windows;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void register(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            this.Close();
            reg.ShowDialog();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            Login logon = new Login();
            this.Close();
            logon.ShowDialog();
        }
        private void Beenden(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
