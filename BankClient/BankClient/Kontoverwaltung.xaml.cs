using System.Windows;
using Eigene_Bank_DLL_Assembly;
using System.Windows.Controls;
using System;

namespace BankClient
{
    /// <summary>
    /// Interaktionslogik für Kontoverwaltung.xaml
    /// </summary>
    public partial class Kontoverwaltung : Window
    {
        BankManagement Bank = new BankManagement();
        GlobalVariables global = new GlobalVariables();

        public Kontoverwaltung()
        {
            InitializeComponent();

            int _id = global.getCustID();
            if (Bank.getBankAccountNumber(_id, 1) != 0) {
                for (int i = 1; i != 6; i++)
                {
                    int Kontonummer = Bank.getBankAccountNumber(_id, i);

                    //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
                    //{
                    if (Kontonummer != 0)
                    {
                        Button b = new Button();
                        b.Tag = Kontonummer;
                        b.Content = "Kreditkonto: " + Kontonummer;
                        b.Click += new RoutedEventHandler(CreditAccountsettings);
                        ListBoxItem item = new ListBoxItem();
                        listBox.Items.Add(b);
                    }
                    //}
                    //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
                    //{
                    //    if (Kontonummer != 0) {

                    //      Button b = new Button();
                    //      b.Name = "btn" + i;
                    //      b.Content = "Sparkonto: " + Kontonummer;
                    //      b.Click += new RoutedEventHandler(DepositAccountsettings);
                    //      ListBoxItem item = new ListBoxItem();
                    //      listBox.Items.Add(b);
                    //    }
                    //}

                }
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);

            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {
            Startseite main = new Startseite();
            this.Close();
            main.ShowDialog();
        }

        void CreditAccountsettings(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            global.setCreditAccnumber((int)btn.Tag);
            CreditAccActions Konto = new CreditAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        void DepositAccountsettings(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            global.setDepositAccnumber((int)btn.Tag);
            DepositAccActions Konto = new DepositAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        private void NewCreditAcc_Click(object sender, RoutedEventArgs e)
        {
            int _id = global.getCustID();

            //Hier wird die KreditKontonummer in den globalen Veriablen gesetzt
            global.setCreditAccnumber(Bank.createCreditAccount(_id));

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

        private void NewDepositAcc_Click(object sender, RoutedEventArgs e)
        {
            int _id = global.getCustID();
            
            //Hier wird die KreditKontonummer in den globalen Veriablen gesetzt
            global.setDepositAccnumber(Bank.createSavingsAccount(_id));

            //Hinzufügen des neuen KreditKontos in die Listbox
            Button button = new Button();
            button.Click += new RoutedEventHandler(DepositAccountsettings);

            ListBoxItem itm = new ListBoxItem();
            listBox.Items.Add(button);

            MessageBox.Show("Das Kreditkonto wurde erfolgreich angelegt");
            Kontoverwaltung konto = new Kontoverwaltung();
            this.Close();
            konto.ShowDialog();
        }
    }
}
