using System.Windows;
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

        public Kontoverwaltung()
        {
            InitializeComponent();

            int _id = global.getCustID();
            if (Bank.getBankAccountNumber(_id, 1) != 0) {
                for (int i = 1; i != 6; i++)
                {
                    int Kontonummer = Bank.getBankAccountNumber(_id, i);
                    
                    Button b = new Button();
                    //if (Bank.getAccType(Kontonummer) == "Kreditkonto")
                    //{
                        b.Content = "Kreditkonto: " + Kontonummer;
                    //}
                    //else if(Bank.getAccType(Kontonummer) == "Sparkonto")
                    //{
                    //    b.Content = "Sparkonto: " + Kontonummer;
                    //}
                    b.Click += new RoutedEventHandler(CreditAccountsettings);

                    ListBoxItem item = new ListBoxItem();
                    listBox.Items.Add(b);
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
            
            
            //Neues Fenster für Überweisungen etc.
            //MessageBox.Show("Credit Clicked");
            CreditAccActions Konto = new CreditAccActions();
            this.Close();
            Konto.ShowDialog();
        }

        void DepositAccountsettings(object sender, RoutedEventArgs e)
        {


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

            newCreditAcc_success Konto = new newCreditAcc_success();
            this.Close();
            Konto.ShowDialog();
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

            newDepositAcc_success Konto = new newDepositAcc_success();
            this.Close();
            Konto.ShowDialog();
        }
    }
}
