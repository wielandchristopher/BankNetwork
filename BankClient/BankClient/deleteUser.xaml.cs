using System.Windows;
using Eigene_Bank_DLL_Assembly;
using System.Windows.Controls;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für deleteUser.xaml
    /// </summary>
    public partial class deleteUser : Window
    {
        GlobalVariables global = new GlobalVariables();
        BankManagement Bank = new BankManagement();

        public deleteUser()
        {
            InitializeComponent();

            int _id = global.getCustID();
            string Kontonummer = global.getAccnumber();
            int x = 0;

            if (Bank.getAccType(Kontonummer) == 0)
            {
                for (int i = 2; i != global.getmaxCountUser(); i++)
                {
                    //if (Bank.getDepositAccOwner(Kontonummer, i) != 0)
                    //{
                    //    x++;
                    //    global.setCountaddUser(x);
                    //}
                }
            }
            else if (Bank.getAccType(Kontonummer) == 1)
            {
                //for (int j = 2; j != global.getmaxCountUser(); j++)
                //{
                //    if (Bank.getCreditAccOwner(Kontonummer, j) != 0)
                //    {
                //        x++;
                //        global.setCountaddUser(x);
                //    }
                //}
            }

            if (x > 0)
            {
                for (int i = 2; i != x + 2; i++)
                {
                    string Kontonummerx = global.getAccnumber();

                    if (Bank.getAccType(Kontonummerx) == 1)
                    {
                        int CustID = 100;// Bank.getCreditAccOwner(Kontonummerx, i);
                        ListBoxItem item = new ListBoxItem();
                        item.Content = "User mit ID: \t\t\t\t\t\t\t\t\t           " + CustID;
                        item.Tag = CustID;
                        item.FontSize = 24;
                        item.Selected += new RoutedEventHandler(deleteuser);
                        listBox.Items.Add(item);
                    }
                    else if (Bank.getAccType(Kontonummerx) == 0)
                    {
                        int CustID = 100;// Bank.getDepositAccOwner(Kontonummerx, i);
                        ListBoxItem item = new ListBoxItem();
                        item.Content = "User mit ID: \t\t\t\t\t\t\t\t\t           " + CustID;
                        item.Tag = CustID;
                        item.FontSize = 24;
                        item.Selected += new RoutedEventHandler(deleteuser);
                        listBox.Items.Add(item);
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
            string Kontonummer = global.getAccnumber();

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

        private void deleteuser(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Soll der Verfüger wirklich entfernt werden?",
                  "Sicherheitsabfrage", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                string Kontonummer = global.getAccnumber();

                if (Bank.getAccType(Kontonummer) == 1)
                {
                    ListBoxItem item = (ListBoxItem)sender;
                    int additionalUser = (int)item.Tag;

                    if (item == null)
                    {
                        MessageBox.Show("Es wurde kein zusätzlicher Verfüger gewählt.");
                    }
                    else
                    {
                        Bank.deleteCreditAccUser(Kontonummer, additionalUser);
                        global.setCountaddUser(global.getCountaddUser() - 1);
                        CreditAccActions cKonto = new CreditAccActions();
                        this.Close();
                        cKonto.ShowDialog();
                    }
                }
                else if (Bank.getAccType(Kontonummer) == 0)
                {
                    ListBoxItem item = (ListBoxItem)sender;
                    int additionalUser = (int)item.Tag;
                    if (item == null)
                    {
                        MessageBox.Show("Es wurde kein zusätzlicher Verfüger gewählt.");
                    }
                    else
                    {
                        Bank.deleteSavingsAccUser(Kontonummer, additionalUser);
                        global.setCountaddUser(global.getCountaddUser() - 1);
                        DepositAccActions dKonto = new DepositAccActions();
                        this.Close();
                        dKonto.ShowDialog();
                    }
                }
            }
        }                            
    }
}
