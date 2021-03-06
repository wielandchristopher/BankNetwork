﻿using System;
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
using Newtonsoft.Json.Linq;

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

        public Selftransaction()
        {
            InitializeComponent();
            int CustID = global.getCustID();
            string Kontonummer = global.getAccnumber();
            int x = 0;


            string Kontonummern = Bank.getBankAccountNumbers(CustID);

            if (Kontonummern.Length > 2)
            {
                JArray newArr = JArray.Parse(Kontonummern);
                global.setCountAcc(newArr.Count);
            }
            //for (int i = 1; i != global.getmaxCountUser()+1; i++)
            //{
            //    if ((Bank.getBankAccountNumber(CustID, i) != 0) && (Bank.getAccType(Bank.getBankAccountNumber(CustID, i)) == 1))
            //    {
            //        x++;
            //        global.setCountAcc(x);
            //    }
            //}
            x = global.getCountAcc();
                if (x > 0)
            {

                Kontonummern = Bank.getBankAccountNumbers(CustID);

                if (Kontonummern.Length > 2)
                {
                    JArray newArr = JArray.Parse(Kontonummern);

                    foreach (JObject jitem in newArr.Children())
                    {
                        string number = jitem.GetValue("Kontonr").ToString();
                        ListBoxItem item = new ListBoxItem();
                        item.Content = "Kreditkonto: \t\t\t\t\t\t\t\t            " + number;
                        item.Tag = number;
                        item.FontSize = 24;
                        item.Selected += new RoutedEventHandler(uebertrag);
                        listBox.Items.Add(item);
                    }

                }
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            global.setCustID(0);
            global.setAccnumber("0");
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Zurück(object sender, RoutedEventArgs e)
        {                
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
        }

        private void uebertrag(object sender, RoutedEventArgs e)
        {
            string Betr = Betrag.Text;
            ListBoxItem item = (ListBoxItem)sender;
            string zielkonto = (string)item.Tag;

            if(Betr == "")
            {
                MessageBox.Show("Bitte geben Sie einen Betrag ein");
            }
            else if (IsNumeric(Betr) == false)
            {
                MessageBox.Show("Der Betrag kann kein Text sein");
                DepositAccActions dKonto = new DepositAccActions();
                this.Close();
                dKonto.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Soll der Betrag auf das gewählte Konto überwiesen werden?",
                  "Sicherheitsabfrage", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    double betrag = double.Parse(Betr, System.Globalization.CultureInfo.InvariantCulture);

                    if ((Bank.getDepositkontostand(global.getAccnumber()) - betrag) < 0)
                    {
                        MessageBox.Show("der eingegebene Betrag übersteigt das derzeitige Saldo. Bitte wählen Sie einen kleineren Betrag");
                        DepositAccActions dKonto = new DepositAccActions();
                        this.Close();
                        dKonto.ShowDialog();
                    }
                    else
                    {
                        Bank.depositCreditAcc(zielkonto, " Eigenübertrag ", betrag);
                        Bank.withdrawSavingsAcc(global.getAccnumber(), betrag);
                        DepositAccActions dKonto = new DepositAccActions();
                        this.Close();
                        dKonto.ShowDialog();
                    }
                }
                else
                {
                    DepositAccActions dKonto = new DepositAccActions();
                    this.Close();
                    dKonto.ShowDialog();
                }
            }
        }
    }
}
