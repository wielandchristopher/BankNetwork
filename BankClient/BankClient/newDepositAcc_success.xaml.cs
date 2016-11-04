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
using System.Windows.Shapes;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für newDepositAcc_success.xaml
    /// </summary>
    public partial class newDepositAcc_success : Window
    {
        public newDepositAcc_success()
        {
            InitializeComponent();
        }

        private void zurück(object sender, RoutedEventArgs e)
        {
            Kontoverwaltung Konto = new Kontoverwaltung();
            this.Close();
            Konto.ShowDialog();
        }
    }
}
