using System.Windows;
using Eigene_Bank_DLL_Assembly;

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

            BankManagement Bank = new BankManagement();
            Bank.receive();
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
