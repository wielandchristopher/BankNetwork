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
    /// Interaktionslogik für Kundendatenaenderung_success.xaml
    /// </summary>
    public partial class Kundendatenaenderung_success : Window
    {
        public Kundendatenaenderung_success()
        {
            InitializeComponent();
        }

        private void zurück(object sender, RoutedEventArgs e)
        {
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }
    }
}
