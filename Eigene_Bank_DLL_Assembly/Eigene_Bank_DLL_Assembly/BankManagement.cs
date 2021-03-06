﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;

namespace Eigene_Bank_DLL_Assembly
{
    public class BankManagement : IBankManagement
    {
        const string path = "Bank.dll";

        // Schnittstellen Funktionen für Customer Management
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr NeuerKunde(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr readUser(int id);
        
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchUser(String vorname, String nachname, String geb);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenvornamenänderung(IntPtr Kunde, String Vorname);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundennachnamenänderung(IntPtr Kunde, String _Nachname);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenadressänderung(IntPtr Kunde, String _Adresse);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundenwohnortsänderung(IntPtr Kunde, String _Wohnort);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundentelefonänderung(IntPtr Kunde, String _Telefon);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundendatenabfrage(IntPtr Kunde);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kundeentfernen(IntPtr Kunde);

        // Schnittstellen Funktionen für Account Management
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesKreditkonto(IntPtr Kunde);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void doEinzahlen(IntPtr zielkonto, String verwendungszweck, double betrag);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesSparkonto(IntPtr Kunde);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Sparkontoentfernen(IntPtr Konto, IntPtr Verfüger);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kreditkontoentfernen(IntPtr Konto, IntPtr Verfüger);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void doSparen(IntPtr zielkonto, String verwendungszweck, double betrag);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void doAbheben(IntPtr zielkonto, double betrag);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeueUeberweisung(IntPtr quellkonto, IntPtr zielkonto, double betrag, String verwendungszweck);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getKreditKontonummer(IntPtr konto);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getSparKontonummer(IntPtr konto);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr readSparKonto(String ktnr);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr readKreditKonto(String ktnr);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern String getKontonummer(IntPtr kunde, String whichKonto);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getAccountType(String kontonummer);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int addSparKontoverfüger(IntPtr sk, IntPtr cust);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int addKreditKontoverfüger(IntPtr kk, IntPtr cust);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void doUmrechnung(IntPtr waehrungsmmodul, String waehrung);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void doKursverwaltung(IntPtr waehrungsmodul);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NeuesWaehrungsmodul(IntPtr konto);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double getSparkontostand(IntPtr konto);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double getKreditkontostand(IntPtr konto);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int deleteKreditkontoVerfüger(IntPtr konto, IntPtr cust);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int deleteSparkontoVerfüger(IntPtr konto, IntPtr cust);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void doSparbuchabheben(IntPtr konto, double amount);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern double waehrungsumrechnung(int _currency, double _value);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getBIC();

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getUserKonten(int id);



        /* ******************new ********************/
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]

        public static extern int UserKontoExists(int userid, String ktnr);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]

        public static extern int removeSparKontoVerfüger(int userid, String ktnr);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]

        public static extern int rmvKontofromUser(int userid, String ktnr);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]

        public static extern int addKontotoUser(int userid, String ktnr);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int addSparkontoVerfüger(int userid, String ktnr);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int skverfügerExists(String ktnr, int userid);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int removeKreditKontoVerfüger(int userid, String ktnr);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int addKreditkontoVerfüger(int userid, String ktnr);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int kkverfügerExists(String ktnr, int userid);

        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SparkontoVerfügerHinzufügen(IntPtr Konto, IntPtr cust);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void KreditkontoVerfügerHinzufügen(IntPtr Konto, IntPtr cust);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SparkontoVerfügerLoeschen(IntPtr Konto, IntPtr cust);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void KreditkontoVerfügerLoeschen(IntPtr Konto, IntPtr cust);
        [DllImport(path, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getUserId(IntPtr cust);

        /**********************************************************************************************************************************
         *  Interface Methoden bezüglich des Customers
         *  ============================================
         *  
         *  int createCustomer(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon);
         *  void changeCustomer(int _id, String _Vorname, String _Nachname, String _adresse, String _Wohnort, String _Telefon)
         *  int getCustomer(String _firstName, String _lastName, String _birthDate);
         *  void deleteCustomer(int _id);
         *  
         * *********************************************************************************************************************************/

        public int createCustomer(String _Vorname, String _Nachname, String _Geburtsdatum, String _adresse, String _Wohnort, String _Telefon)
        {
            IntPtr neuerKunde = NeuerKunde(_Vorname, _Nachname, _Geburtsdatum, _adresse, _Wohnort, _Telefon);
            int id = searchUser(_Vorname, _Nachname, _Geburtsdatum);
            return id;
        }

        public void changeCustomer(int _id, String _Vorname, String _Nachname, String _adresse, String _Wohnort, String _Telefon)
        {
            IntPtr kunde = readUser(_id);
            Kundenvornamenänderung(kunde, _Vorname);
            Kundennachnamenänderung(kunde, _Nachname);
            Kundenadressänderung(kunde, _adresse);
            Kundenwohnortsänderung(kunde, _Wohnort);
            Kundentelefonänderung(kunde, _Telefon);
        }

        // returns -1 if Customer not found
        public int getCustomer(String _firstName, String _lastName, String _birthDate)
        {
            int id = searchUser(_firstName, _lastName, _birthDate);
            return id;
        }

        public void deleteCustomer(int _id)
        {
            IntPtr kunde = readUser(_id);
            Kundeentfernen(kunde);
        }

        /**********************************************************************************************************************************
        *  Interface Methoden bezüglich des Accounts
        *  ============================================
        *  
        *   int createSavingsAccount(int _id);
        *   int createCreditAccount(int _id);
        *   void deleteSavingsAccount(int _sNumber, int _id);
        *   void deleteCreditAccount(int _cNumber, int _id);
        *   void depositCreditAcc(int _cNumber, String _usage, double _amount);
        *   void depositSavingsAcc(int _sNumber, String _usage, double _amount);
        *   void withdrawCreditAcc(int _cNumber, double _amount);
        *   void transfer(int _cNumber, int _toAccNumber, String _usage, double _amount);
        *   void addSavingsAccountDisposer(int _sNumber, int _id);
        *   void addCreditAccountDisposer(int _cNumber, int _id);
        *   int getBankAccountNumber(int _id, int _whichAccount);
        *   void createBankStatement(int _accNumber);
        *   void convertMoney(int _cNumber, string _currency);
        *   void showChangeOfCourse(int _cNumber);
        *        
        * *********************************************************************************************************************************/

        // Methode returned Kontonummer
        public string createSavingsAccount(int _id)
        {
            IntPtr customer = readUser(_id);
            IntPtr savingsAccount = NeuesSparkonto(customer);
            String accountNumber = Marshal.PtrToStringAnsi(getSparKontonummer(savingsAccount));

            return accountNumber;
        }

        // Methode returned Kontonummer
        public string createCreditAccount(int _id)
        {
            IntPtr customer = readUser(_id);
            IntPtr creditAccount = NeuesKreditkonto(customer);
            string accountNumber = Marshal.PtrToStringAnsi(getKreditKontonummer(creditAccount));

            return accountNumber;
        }

        public void deleteSavingsAccount(String _sNumber, int _id)
        {
            IntPtr savingsAccount = readSparKonto(_sNumber);
            IntPtr customer = readUser(_id);
            Sparkontoentfernen(savingsAccount, customer);
        }

        public void deleteCreditAccount(String _cNumber, int _id)
        {
            IntPtr creditAccount = readKreditKonto(_cNumber);
            IntPtr customer = readUser(_id);
            Kreditkontoentfernen(creditAccount, customer);
        }

        public void depositCreditAcc(String _cNumber, String _usage, double _amount)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            doEinzahlen(creditAcc, _usage, _amount);
        }

        public void depositSavingsAcc(String _sNumber, String _usage, double _amount)
        {
            IntPtr savingAcc = readSparKonto(_sNumber);
            doSparen(savingAcc, _usage, _amount);
        }

        public void withdrawCreditAcc(String _cNumber, double _amount)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            doAbheben(creditAcc, _amount);
        }

        // Anschauen
        public void transfer(String _cNumber, String _toAccNumber, String _usage, double _amount)
        {
         
            //return 1 = Kreditkonto, return 0 = Sparkonto
            if((getAccType(_cNumber) == 1) && (getAccType(_toAccNumber) == 1))
            {
                IntPtr quellAcc = readKreditKonto(_cNumber);
                IntPtr zielAcc = readKreditKonto(_toAccNumber);
                doAbheben(quellAcc, _amount);
                doEinzahlen(zielAcc, _usage, _amount);
            }
            else if ((getAccType(_cNumber) == 1) && (getAccType(_toAccNumber) == 0))
            {
                IntPtr quellAcc = readKreditKonto(_cNumber);
                IntPtr zielAcc = readSparKonto(_toAccNumber);
                doAbheben(quellAcc, _amount);                
                doSparen(zielAcc, _usage, _amount);
            }
            else
            {
                Console.WriteLine("No transfer possible, because of inserting a savings account!");
            }
        }

        public void addSavingsAccountUser(String _sNumber, int _id)
        {
            IntPtr savingAcc = readSparKonto(_sNumber);
            IntPtr customer = readUser(_id);
            addSparKontoverfüger(savingAcc, customer);
        }

        public void addCreditAccountUser(String _cNumber, int _id)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            IntPtr customer = readUser(_id);
            addKreditKontoverfüger(creditAcc, customer);
        }

        public String getBankAccountNumbers(int _id)
        {
            string s = Marshal.PtrToStringAnsi(getUserKonten(_id));
            
            return s;
        }

        public int getAccType(String Accnumber)
        {
            return getAccountType(Accnumber);
        }

        public void createBankStatement(String _accNumber)
        {
            string fileName = _accNumber + "_Buchungen.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            Console.WriteLine("************************************************************************************");
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("************************************************************************************");
        }

        public void convertMoney(String _cNumber, string _currency)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);

            if(_currency == "USD" || _currency == "CHF" || _currency == "GBP" || _currency == "JPY")
            {
                IntPtr waehrungsmodul = NeuesWaehrungsmodul(creditAcc);
                doUmrechnung(waehrungsmodul, _currency);

                string fileName = _cNumber + "_Umrechnung.txt";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                Console.WriteLine("************************************************************************************");
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        String line = sr.ReadToEnd();
                        Console.WriteLine(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("************************************************************************************");
            }
            else
            {
                Console.WriteLine("Wrong currency input!");
            }
        }

        public void showChangeOfCourse(String _cNumber)
        {
            IntPtr creditAcc = readKreditKonto(_cNumber);
            IntPtr waehrungsmodul = NeuesWaehrungsmodul(creditAcc);

            string fileName = _cNumber + "_Kursverwaltung.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            Console.WriteLine("************************************************************************************");
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("************************************************************************************");
        }

        public double getDepositkontostand(String snumber){

            IntPtr depositAcc = readSparKonto(snumber);
            double amount = getSparkontostand(depositAcc);       
            return amount;
        }

        public double getCreditkontostand(String cnumber)
        {
            IntPtr creditAcc = readKreditKonto(cnumber);
            return getKreditkontostand(creditAcc);
        }
        //public String getDepositAccOwner(String snumber, string whichuser)
        //{
        //    IntPtr depositAcc = readSparKonto(snumber);
        //    return getSparkontoverfüger(depositAcc, whichuser);

        //}
        //public int getCreditAccOwner(String cnumber, int whichuser)
        //{
        //    IntPtr creditAcc = readKreditKonto(cnumber);
        //    return getKreditkontoverfüger(creditAcc, whichuser);

        //}

        public int deleteCreditAccUser(String Kontonummer, int additionalUser)
        {
            IntPtr creditAcc = readKreditKonto(Kontonummer);
            IntPtr cust = readUser(additionalUser);

            deleteKreditkontoVerfüger(creditAcc, cust);

            return 0;
        }
        public int deleteSavingsAccUser(String Kontonummer, int additionalUser)
        {
            IntPtr savingsAcc = readSparKonto(Kontonummer);
            IntPtr cust = readUser(additionalUser);

            deleteSparkontoVerfüger(savingsAcc, cust);

            return 0;
        }

        public void withdrawSavingsAcc(String _snumber, double _amount)
        {
            IntPtr savingsAcc = readSparKonto(_snumber);
            doSparbuchabheben(savingsAcc, _amount);
        }

        public double currencyConversion(int _currency, double _value)
        {
            double newCurrency = waehrungsumrechnung(_currency, _value);

            return newCurrency;
        }

        public int getBankBIC()
        {
            return getBIC();
        }

        public bool BankUserKontoExists(int userid, String ktnr)
        {
            //string s = getBankAccountNumbers(userid);
            //JObject newObj = JObject.Parse(s);


            if(UserKontoExists(userid, ktnr)==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // RabbitMQ
        public void send(Transaction transaction)
        {
            Console.WriteLine("test");
            var factory = new ConnectionFactory();
            factory.Uri = "amqp://user80:User80ITS2016!@rabbit.binna.eu/";  //Insert your own user and password

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var transactionString = JsonConvert.SerializeObject(transaction);   //Awesome function

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                if(transaction.IsResponding == false)
                {
                    channel.BasicPublish(exchange: "bank.production", //Choose between bank.development and bank.production depending of the queue (e.g. 70 is production, 71 is development)
                    routingKey: transaction.Receiver.Bic, //This relates to the queue name of the receiver bank
                    basicProperties: properties, //Set the properties to persistent, otherwise the messages will get lost if the server restarts
                    body: GetBytes(transactionString));
                }
                else
                {
                    channel.BasicPublish(exchange: "bank.production", //Choose between bank.development and bank.production depending of the queue (e.g. 70 is production, 71 is development)
                    routingKey: transaction.Sender.Bic, //This relates to the queue name of the receiver bank
                    basicProperties: properties, //Set the properties to persistent, otherwise the messages will get lost if the server restarts
                    body: GetBytes(transactionString));
                }

                // Abbuchen


                //channel.BasicPublish(exchange: "bank.production",  //Choose between bank.development and bank.production depending of the queue (e.g. 70 is production, 71 is development)
                //                    routingKey: transaction.Receiver.Bic,   //This relates to the queue name of the receiver bank
                //                    basicProperties: properties,    //Set the properties to persistent, otherwise the messages will get lost if the server restarts
                //                    body: GetBytes(transactionString));

                // Console.WriteLine("[x] Message Sent");
            }

            // Console.WriteLine(" Press [enter] to exit send.");
            // Console.ReadLine();
        }

        public void receive()
        {
            var factory = new ConnectionFactory();
            factory.Uri = "amqp://user80:User80ITS2016!@rabbit.binna.eu/";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "80",
                                 durable: true, //Always use durable: true, because the queue on the server is configured this way. Otherwise you'll not be able to connect
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = GetString(ea.Body);
                        var transaction = JsonConvert.DeserializeObject<Transaction>(body);
                        
                        // bei keinen errorcode abheben ansonsten einzahlen
                        // Anfrage von anderer Bank
                        if(transaction.Errorcode == 0 && transaction.IsResponding == false)
                        {
                            double amount = transaction.Amount;
                            string zielKontonummer = transaction.Receiver.Iban;
                            string purpose = transaction.Purpose;

                            if (transaction.Currency != ECurrency.Euro)
                            {
                                if(transaction.Currency == ECurrency.Dollar)
                                {
                                    amount = transaction.Amount * 1.1070;
                                }
                                else if(transaction.Currency == ECurrency.Pound)
                                {
                                    amount = transaction.Amount * 0.8889;
                                }
                            }
                            else
                            {
                                amount = transaction.Amount;
                            }

                            // Kontonummer validieren - ob vorhanden
                            if ((getAccType(zielKontonummer) == 1) || (getAccType(zielKontonummer) == 0))
                            {
                                IntPtr account = readKreditKonto(zielKontonummer);

                                if(amount > 0)
                                {
                                    doEinzahlen(account, purpose, amount);

                                    // Response
                                    Transaction transactionError2 = new Transaction(transaction.Sender.Iban, transaction.Sender.Bic, transaction.Receiver.Iban, transaction.Receiver.Bic, transaction.Amount, transaction.Currency, transaction.Purpose, true, 0);
                                    send(transactionError2);
                                }
                                else
                                {
                                    // Berechtigung checken ?
                                    amount = amount * -1;

                                    Transaction transactionError1 = new Transaction(transaction.Sender.Iban, transaction.Sender.Bic, transaction.Receiver.Iban, transaction.Receiver.Bic, transaction.Amount, transaction.Currency, transaction.Purpose, true, -6);
                                    send(transactionError1);
                                } 
                            }
                            else
                            {
                                // Konto nicht vorhanden - zurücksenden mit Fehlercode
                                Transaction transactionError = new Transaction(transaction.Sender.Iban, transaction.Sender.Bic, transaction.Receiver.Iban, transaction.Receiver.Bic, transaction.Amount, transaction.Currency, transaction.Purpose, true, -2);
                                send(transactionError);
                            } 
                        }
                        // unnötig?
                        else if(transaction.Errorcode != 0 && transaction.IsResponding == false)
                        {
                            // string zielKontonummer = transaction.Sender.Iban;
                            // string purpose = "Fehler bei Transaktion";
                            // double amount = transaction.Amount;

                            // Einzahlen
                            // IntPtr account = readKreditKonto(zielKontonummer);
                            // doEinzahlen(account, purpose, amount);
                        }
                        // Responses
                        // unnötig
                        else if(transaction.Errorcode == 0 && transaction.IsResponding == true)
                        {
                            Console.WriteLine("Transaktion erfolgreich");

                            // Bei negativen Amount - wenn kein Fehler -> einzahlen
                            if(transaction.Amount < 0)
                            {
                                string zielKontonummer = transaction.Sender.Iban;
                                string purpose = transaction.Purpose;
                                double amount = transaction.Amount * -1;

                                IntPtr account = readKreditKonto(zielKontonummer);
                                doEinzahlen(account, purpose, amount);
                            }
                        }
                        else if(transaction.Errorcode != 0 && transaction.IsResponding == true)
                        {
                            // Fehler zurückbekommen -> Kunde bekommt sein geld wieder (Sender ist unser Kunde)
                            string zielKontonummer = transaction.Sender.Iban;
                            string purpose = "Fehler bei Transaktion";
                            double amount = transaction.Amount;

                            // Einzahlen
                            IntPtr account = readKreditKonto(zielKontonummer);
                            doEinzahlen(account, purpose, amount);
                        }

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false); //Important. When the message get's not acknowledged, it gets sent again

                    //    Console.WriteLine("[x] Received:");
                        PrintTransaction(transaction);
                    };

                    channel.BasicConsume(queue: "80",
                                         noAck: false,  //If noAck: false the command channel.BasicAck (see above) has to be implemented. Don't set it true, or the message will not get resubmitted, if the bank was offline
                                         consumer: consumer);

                    // Console.WriteLine(" Press [enter] to exit receive.");
                    // Console.ReadLine();

                    Thread.Sleep(2000);
                }
            }
        }

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        static void PrintTransaction(Transaction transaction)
        {
            Console.WriteLine("Receiver Iban: " + transaction.Receiver.Iban);
            Console.WriteLine("Receiver Bic : " + transaction.Receiver.Bic);
            Console.WriteLine("Sender Iban  : " + transaction.Sender.Iban);
            Console.WriteLine("Sender Bic   : " + transaction.Sender.Bic);
            Console.WriteLine("Amount       : " + transaction.Amount);
            Console.WriteLine("Currency     : " + transaction.Currency.ToString());
            //Console.WriteLine("Purpose      : " + transaction.Purpose);

            //JObject o2;
            //// read JSON directly from a file
            //using (StreamReader file = File.OpenText("banktransactions.json"))
            //using(JsonTextReader reader = new JsonTextReader(file))
            //{
            //    o2 = (JObject)JToken.ReadFrom(reader);
            //    }

            
            //JArray arr = (JArray)o2.GetValue("transactions");
            
            //JObject obj = new JObject();
            
            //obj.Add("Receiver Iban: " + transaction.Receiver.Iban);
            //obj.Add("Receiver Bic : " + transaction.Receiver.Bic);
            //obj.Add("Sender Iban  : " + transaction.Sender.Iban);
            //obj.Add("Sender Bic   : " + transaction.Sender.Bic);
            //obj.Add("Amount       : " + transaction.Amount);
            //obj.Add("Currency     : " + transaction.Currency.ToString());
            //obj.Add("Purpose      : " + transaction.Purpose);
            //arr.Add(obj);

            //JObject saveobj = new JObject();
            //saveobj.Add("transactions", arr);

            //StreamWriter wr = new StreamWriter("transactions.json");
            //wr.Write(saveobj.ToString());
            //wr.Close();

        }
    }    
}
