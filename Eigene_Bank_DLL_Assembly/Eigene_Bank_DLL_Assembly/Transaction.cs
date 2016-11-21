using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;

namespace Eigene_Bank_DLL_Assembly
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public RemoteCustomer Sender { get; set; }
        public RemoteCustomer Receiver { get; set; }
        public Int32 Timestamp { get; set; }        // Unix format timestamp
        public int Errorcode { get; set; }         // 0 = no Error
        public string Purpose { get; set; }
        public double Amount { get; set; }          // if positive: transaction, negative: debiting
        public ECurrency Currency { get; set; }
        public bool IsResponding { get; set; }      // if Transaction is a Response

        public Transaction(string senderIban, string senderBic, string receiverIban, string receiverBic, double amount, ECurrency currency, string purpose = "", bool isResponding = false, int errorcode = 0)
        {
            this.TransactionId = Guid.NewGuid();
            Sender = new RemoteCustomer(senderIban, senderBic);
            this.Amount = amount;
            Receiver = new RemoteCustomer(receiverIban, receiverBic);
            Timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            this.Currency = currency;
            this.IsResponding = isResponding;
            this.Errorcode = errorcode;
            this.Purpose = purpose;
        }

        public string GetStatus()
        {
            switch (this.Errorcode)
            {
                case 0:
                    return "Success";
                case -1:
                    return "Debiting not authorized";       // to debit = abbuchen :)
                case -2:
                    return "IBAN not found";
                case -3:
                    return "Internal DLL error";
                case -4:
                    return "Backflip";
                case -5:
                    return "Json-Format invalid / Data could not be converted";
                case -6:
                    return "Transaction rejected";
                case -7:
                    return "no Money on Account";
                default:
                    return "Error not spezified";
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
        }
    }

    public class RemoteCustomer
    {
        public string Iban { get; set; }
        public string Bic { get; set; }

        public RemoteCustomer(string iban, string bic)
        {
            this.Iban = iban;
            this.Bic = bic;
        }
    }

    /*
     * umrechnung:
     * EURO 1
     * DOLLAR 1,1070
     * POUND 0,8889
    */
    public enum ECurrency { Euro, Dollar, Pound }
}


