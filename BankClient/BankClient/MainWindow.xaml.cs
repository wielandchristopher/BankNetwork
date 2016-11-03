using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

    }
}
