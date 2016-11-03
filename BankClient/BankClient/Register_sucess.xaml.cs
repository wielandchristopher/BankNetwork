using System.Windows;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Register_sucess.xaml
    /// </summary>
    public partial class Register_sucess : Window
    {
        public Register_sucess()
        {
            InitializeComponent();
        }
        private void zurück(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }
    }
}
