using System.Windows;
using Eigene_Bank_DLL_Assembly;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Kontoverwaltung.xaml
    /// </summary>
    public partial class Kontoverwaltung : Window
    {
        BankManagement Bank = new BankManagement();
        GlobalVariables global = new GlobalVariables();

        bool existAccount(int _idx)
        {

            string ktnr = global.getAccnumber();

            return Bank.BankUserKontoExists(_idx, ktnr);

            //for (int i = 1; i< global.getmaxCountAcc()+1; i++)
            //{
            //    if (Bank.getBankAccountNumbers(global.getCustID(), i) != 0)
            //    {
            //        return true;
            //    }
            //}        
            //return false;
        }

     

        public Kontoverwaltung()
        {
            InitializeComponent();

            int _id = global.getCustID();
            int x = 0;
                
            //for (int i = 0; i != global.getmaxCountAcc(); i++)
            //{
            //    if (Bank.getBankAccountNumber(_id, i + 1) != 0)
            //    {
            //        x++;
            //        global.setCountAcc(x);
            //    }
            //}    

            if (existAccount(_id)) {



                string Kontonummern = Bank.getBankAccountNumbers(_id);
                
                if (Kontonummern.Length > 2)
                {
                    JArray newArr = JArray.Parse(Kontonummern);

                    foreach (JObject jitem in newArr.Children())
                    {
                        string Kontonummer = jitem.GetValue("Kontonr").ToString();

                        if (Bank.getAccType(Kontonummer) == 1)
                        {
                            ListBoxItem item = new ListBoxItem();
                            item.Tag = Kontonummer;
                            item.FontSize = 24;
                            item.Content = "Kreditkonto: \t\t\t\t\t\t\t\t            " + Kontonummer;
                            item.Selected += new RoutedEventHandler(CreditAccountsettings);
                            listBox.Items.Add(item);
                        }
                        else if (Bank.getAccType(Kontonummer) == 0)
                        {
                            ListBoxItem item = new ListBoxItem();
                            item.Tag = Kontonummer;
                            item.FontSize = 24;
                            item.Content = "Sparkonto: \t\t\t\t\t\t\t\t            " + Kontonummer;
                            item.Selected += new RoutedEventHandler(DepositAccountsettings);
                            listBox.Items.Add(item);
                        }
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
            global.setCountAcc(0);
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }

        void CreditAccountsettings(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            global.setAccnumber((string)item.Tag);
            CreditAccActions Konto = new CreditAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        void DepositAccountsettings(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            global.setAccnumber((string)item.Tag);
            DepositAccActions Konto = new DepositAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        private void NewCreditAcc_Click(object sender, RoutedEventArgs e)
        {
            if (global.getCountAcc() >= global.getmaxCountAcc())
            {
                MessageBox.Show("Der Kunde besitzt schon 5 Konten (Maximum)");
                Kontoverwaltung konto = new Kontoverwaltung();
                this.Close();
                konto.ShowDialog();
            }
            else
            {
                int _id = global.getCustID();

                //Hier wird die KreditKontonummer in den globalen Veriablen gesetzt
                global.setAccnumber(Bank.createCreditAccount(_id));
                global.setCountAcc(global.getCountAcc()+1);

                //Hinzufügen des neuen KreditKontos in die Listbox
                Button button = new Button();
                button.Click += new RoutedEventHandler(CreditAccountsettings);

                ListBoxItem itm = new ListBoxItem();
                listBox.Items.Add(button);

                MessageBox.Show("Das Kreditkonto wurde erfolgreich angelegt");
                Kontoverwaltung konto = new Kontoverwaltung();
                this.Close();
                konto.ShowDialog();
            }
        
        }

        private void NewDepositAcc_Click(object sender, RoutedEventArgs e)
        {
            if (global.getCountAcc() == global.getmaxCountAcc())
            {
                MessageBox.Show("Der Kunde besitzt schon 5 Konten (Maximum)");
                Kontoverwaltung konto = new Kontoverwaltung();
                this.Close();
                konto.ShowDialog();
            }
           else if (global.getCountAcc() < global.getmaxCountAcc())
            {
                int _id = global.getCustID();

                //Hier wird die KreditKontonummer in den globalen Veriablen gesetzt
                global.setAccnumber(Bank.createSavingsAccount(_id));
                global.setCountAcc(global.getCountAcc() + 1);

                //Hinzufügen des neuen KreditKontos in die Listbox
                Button button = new Button();
                button.Click += new RoutedEventHandler(DepositAccountsettings);

                ListBoxItem itm = new ListBoxItem();
                listBox.Items.Add(button);

                MessageBox.Show("Das Sparkonto wurde erfolgreich angelegt");
                Kontoverwaltung konto = new Kontoverwaltung();
                this.Close();
                konto.ShowDialog();
            }         
        }
    }
}
