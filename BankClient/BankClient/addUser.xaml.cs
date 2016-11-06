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
    /// Interaktionslogik für addUser.xaml
    /// </summary>
    public partial class addUser : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        private bool IsNumeric(string value)
        {
            double Val = 0;
            return double.TryParse(value, out Val);
        }

        public addUser()
        {
            InitializeComponent();

                int _id = global.getAccnumber();
                int x = 0;

                if (Bank.getAccType(_id) == 0)
                {
                    for (int i = 1; i != global.getmaxCountUser() + 1; i++)
                    {
                        if (Bank.getDepositAccOwner(_id, i) != 0)
                        {
                            x++;
                            global.setCountUser(x);
                        }
                    }
                }
                else if (Bank.getAccType(_id) == 1)
                {
                    for (int j = 1; j != global.getmaxCountUser() + 1; j++)
                    {
                        if (Bank.getCreditAccOwner(_id, j) != 0)
                        {
                            x++;
                            global.setCountUser(x);
                        }
                    }
                }            
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);
            global.setCountAcc(0);
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            int Kontonummer = global.getAccnumber();

            if (Bank.getAccType(Kontonummer) == 1)
            {
                CreditAccActions cKonto = new CreditAccActions();
                this.Close();
                cKonto.ShowDialog();
            }
            else if (Bank.getAccType(Kontonummer) == 0)
            {
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
            }
        }

        private void adduser(object sender, RoutedEventArgs e)
        {
            if (global.getCountUser() == global.getmaxCountUser()) {

                int Kontonummer = global.getAccnumber();

                MessageBox.Show("Ein Konto kann nur maximal 5 Verfüger besitzen");

                if (Bank.getAccType(Kontonummer) == 1)
                {                   
                    CreditAccActions cKonto = new CreditAccActions();
                    this.Close();
                    cKonto.ShowDialog();
                }
                else if (Bank.getAccType(Kontonummer) == 0)
                {
                    DepositAccActions dKonto = new DepositAccActions();
                    this.Close();
                    dKonto.ShowDialog();
                }
            }
            else {
                if (Bank.getCustomer(Vorname.Text, Nachname.Text, Geburtsdatum.Text) == -1)
                {
                    MessageBox.Show("Der angegebene Verfüger existiert nicht");
                }
                else
                {
                    int CustID = Bank.getCustomer(Vorname.Text, Nachname.Text, Geburtsdatum.Text);
                    int Kontonummer = global.getAccnumber();

                    if (Bank.getAccType(Kontonummer) == 1)
                    {
                        Bank.addCreditAccountUser(Kontonummer, CustID);
                        MessageBox.Show("Der Verfüger wurde erfolgreich hinzugefügt");
                        CreditAccActions cKonto = new CreditAccActions();
                        this.Close();
                        cKonto.ShowDialog();
                    }
                    else if (Bank.getAccType(Kontonummer) == 0)
                    {
                        Bank.addSavingsAccountUser(Kontonummer, CustID);
                        MessageBox.Show("Der Verfüger wurde erfolgreich hinzugefügt");
                        DepositAccActions dKonto = new DepositAccActions();
                        this.Close();
                        dKonto.ShowDialog();
                    }
                    global.setCountUser(global.getCountUser() + 1);
                }
            }
        }
    }
}
