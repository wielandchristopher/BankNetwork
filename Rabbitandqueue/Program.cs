﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;

namespace sst.bank.rabbit
{
    class Program
    {
        //IMPORTANT: The dll's are referenced and also located in the folder Resources

        static void Main(string[] args)
        {
            //Use the queue name of the receiver bank as the receiverBic
            var remoteTransaction = new RemoteTransaction("senderIban", "senderBic", "receiverIban", "71", 10, ECurrency.Euro);

            Send(remoteTransaction);
            Receive();
        }

        static void Send(RemoteTransaction transaction)
        {
            var factory = new ConnectionFactory();
            factory.Uri = "amqp://user70:User70ITS2016!@rabbit.binna.eu/";  //Insert your own user and password

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var transactionString = JsonConvert.SerializeObject(transaction);   //Awesome function

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "bank.development",  //Choose between bank.development and bank.production depending of the queue (e.g. 70 is production, 71 is development)
                                    routingKey: transaction.Receiver.Bic,   //This relates to the queue name of the receiver bank
                                    basicProperties: properties,    //Set the properties to persistent, otherwise the messages will get lost if the server restarts
                                    body: GetBytes(transactionString));

                Console.WriteLine("[x] Message Sent");
            }

            Console.WriteLine(" Press [enter] to exit send.");
            Console.ReadLine();
        }

        static void Receive()
        {
            var factory = new ConnectionFactory();
            factory.Uri = "amqp://user70:User70ITS2016!@rabbit.binna.eu/";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "71",
                                 durable: true, //Always use durable: true, because the queue on the server is configured this way. Otherwise you'll not be able to connect
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = GetString(ea.Body);
                        var transaction = JsonConvert.DeserializeObject<RemoteTransaction>(body);

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false); //Important. When the message get's not acknowledged, it gets sent again

                        Console.WriteLine("[x] Received:");
                        PrintTransaction(transaction);
                    };

                    channel.BasicConsume(queue: "71",
                                         noAck: false,  //If noAck: false the command channel.BasicAck (see above) has to be implemented. Don't set it true, or the message will not get resubmitted, if the bank was offline
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit receive.");
                    Console.ReadLine();
                }
            }
        }

        static void PrintTransaction(RemoteTransaction transaction)
        {
            Console.WriteLine("Receiver Iban: " + transaction.Receiver.Iban);
            Console.WriteLine("Receiver Bic : " + transaction.Receiver.Bic);
            Console.WriteLine("Sender Iban  : " + transaction.Sender.Iban);
            Console.WriteLine("Sender Bic   : " + transaction.Sender.Bic);
            Console.WriteLine("Amount       : " + transaction.Amount);
            Console.WriteLine("Currency     : " + transaction.Currency.ToString());
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
    }
}
