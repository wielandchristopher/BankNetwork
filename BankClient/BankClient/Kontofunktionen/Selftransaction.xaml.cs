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
using Eigene_Bank_DLL_Assembly;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Selftransaction.xaml
    /// </summary>
    public partial class Selftransaction : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        bool existAccount(int _idx)
        {

            for (int i = 1; i < global.getmaxCountAcc() + 1; i++)
            {
                if ((Bank.getBankAccountNumber(global.getCustID(), i) != 0) && (Bank.getAccType(_idx) == 1))
                {                    
                    return true;
                }
            }
            return false;
        }

        public Selftransaction()
        {
            InitializeComponent();
            int CustID = global.getCustID();
            int Kontonummer = global.getAccnumber();
            int x = 0;

            for (int i = 1; i != global.getmaxCountUser()+1; i++)
            {
                if ((Bank.getBankAccountNumber(CustID, i) != 0) && (Bank.getAccType(Bank.getBankAccountNumber(CustID, i)) == 1))
                {
                    x++;
                    global.setCountAcc(x);
                }
            }

            if (x > 0)
            {
                for (int i = 1; i != x+1; i++)
                {

                    int number = Bank.getBankAccountNumber(CustID, i);
                    ListBoxItem item = new ListBoxItem();
                    item.Content = "Kreditkonto: \t\t\t" + number;
                    item.Tag = number;
                    //item.Selected += new RoutedEventHandler(deleteuser);
                    listBox.Items.Add(item);
                }
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);
            global.setAccnumber(0);
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
                global.setAccnumber(0);
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
        }

        private void uebertrag(object sender, RoutedEventArgs e)
        {

        }
    }
}
