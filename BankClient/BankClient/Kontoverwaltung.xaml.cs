﻿using System.Windows;
using Eigene_Bank_DLL_Assembly;
using System.Windows.Controls;

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
            for (int i = 0; i < global.getmaxCountAcc(); i++)
            {
                if (Bank.getBankAccountNumber(_idx, (global.getmaxCountAcc()) - i) != 0)
                {
                    global.setCountAcc(global.getmaxCountAcc() - i);
                    return true;
                }             
            }
            return false;
        }

        public Kontoverwaltung()
        {
            InitializeComponent();

            int _id = global.getCustID();
            if (existAccount(_id) == true) {
                for (int i = 1; i != global.getCountAcc()+1; i++)
                {
                    int Kontonummer = Bank.getBankAccountNumber(_id, i);

                    //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
                    //{
                        Button b = new Button();
                        b.Tag = Kontonummer;
                        b.Content = "Kreditkonto: " + Kontonummer;
                        b.Click += new RoutedEventHandler(CreditAccountsettings);
                        ListBoxItem item = new ListBoxItem();
                        listBox.Items.Add(b);
                    //}
                    //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
                    //{
                    //      Button b = new Button();
                    //      b.Name = "btn" + i;
                    //      b.Content = "Sparkonto: " + Kontonummer;
                    //      b.Click += new RoutedEventHandler(DepositAccountsettings);
                    //      ListBoxItem item = new ListBoxItem();
                    //      listBox.Items.Add(b);
                    //}

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
            Button btn = (Button)sender;
            global.setAccnumber((int)btn.Tag);
            CreditAccActions Konto = new CreditAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        void DepositAccountsettings(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            global.setAccnumber((int)btn.Tag);
            DepositAccActions Konto = new DepositAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        private void NewCreditAcc_Click(object sender, RoutedEventArgs e)
        {
            if (global.getCountAcc() <global.getmaxCountAcc()) {
                int _id = global.getCustID();

                //Hier wird die KreditKontonummer in den globalen Veriablen gesetzt
                global.setAccnumber(Bank.createCreditAccount(_id));

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
            else {
                MessageBox.Show("Der Kunde besitzt schon 5 Konten (Maximum)");
                Kontoverwaltung konto = new Kontoverwaltung();
                this.Close();
                konto.ShowDialog();
            }
        }

        private void NewDepositAcc_Click(object sender, RoutedEventArgs e)
        {
            if (global.getCountAcc() < global.getmaxCountAcc()) {
                int _id = global.getCustID();

                //Hier wird die KreditKontonummer in den globalen Veriablen gesetzt
                global.setAccnumber(Bank.createSavingsAccount(_id));

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
            else {
                MessageBox.Show("Der Kunde besitzt schon 5 Konten (Maximum)");
                Kontoverwaltung konto = new Kontoverwaltung();
                this.Close();
                konto.ShowDialog();
            }
        }
    }
}
