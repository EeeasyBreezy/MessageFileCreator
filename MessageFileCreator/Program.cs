using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace MessageFileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to message file creator for ok.com!");
            Console.Write("Parsing accounts from ok profiles.txt..........");
            StreamReader reader = new StreamReader("ok accounts.txt");
            List<Account> accounts = new List<Account>();
            List<Message> messages = new List<Message>();
            List<string> ids = new List<string>();
            Regex expression = new Regex(";");
            while(reader.EndOfStream == false)
            {
                string accountCsv = reader.ReadLine();
                string[] splittedCsv = expression.Split(accountCsv);
                accounts.Add(new Account(splittedCsv[0], splittedCsv[1]));
            }
            reader.Close();
            Console.WriteLine("OK");
            Console.Write("Getting reciever ids from ids.txt..........");
            reader = new StreamReader("ids.txt");
            while(reader.EndOfStream == false)
            {
                ids.Add(reader.ReadLine());
            }
            reader.Close();
            Console.WriteLine("OK");
            Console.WriteLine("Number of messages required: ");
            int messageNum = Convert.ToInt32(Console.ReadLine());
            Random r = new Random();
            Console.Write("Creating messages..........");
            for (int i = 0; i < messageNum; i++)
            {
                int account = r.Next(0, accounts.Count - 1);
                int reciever = r.Next(0, ids.Count - 1);
                string message = string.Format("Добрый день. Это тестовое сообщение рассылки под номером {0}",
                    i);
                messages.Add(new Message(accounts[account].Login, ids[reciever], message));
            }
            Console.WriteLine("OK");
            Console.Write("Writing messages to file messages.txt..........");
            StreamWriter writer =  new StreamWriter("messages.txt");
            for(int i = 0; i < messages.Count; i++)
            {
                writer.WriteLine(messages[i].ToString());
            }
            writer.Close();
            Console.WriteLine("OK");
            Console.WriteLine("Get your messages from messages.txt file");
            Console.WriteLine("Program executed successfully");
        }
    }
}
