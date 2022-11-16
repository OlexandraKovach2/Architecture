using System;
using System.Collections.Generic;
using System.IO;

namespace ProxyLab3
{
    //Варіант 8. Дано клас Текстове повідомлення
    //(текст повідомлення, час відправки, номер отримувача)
    //та клас надсилання повідомлення(метод надсилання реалізувати як вивід в консоль).
    //Реалізувати збереження повідомлення перед надсиланням повідомлення
    //в деякий тестовий файл.Також необхідно реалізувати функцію
    //чорного списку: якщо номер отримувача в списку заборонених,
    //то згенерувати помилку.
    class Program
    {
        static void Main(string[] args)
        {
            Message mes1 = new Message("I love u ♥", 452);
            SendMessage sender = new SendMessage(mes1);
            Console.WriteLine(sender.send());
            sender.addToBlackList(452);
            Console.WriteLine(sender.send());
        }
    }
    public interface IMessage
    {
        public string sendMessage();
    }

    public class Message : IMessage
    {
        public string text { get; set; }
        public int getterNumber { get; set; }
        public DateTime messageDate = new DateTime();
        public string filename = "messageData";
        public Message(string text, int getterNumber)
        {
            this.text = text;
            this.getterNumber = getterNumber;
        }
        public Message(string text, int getterNumber, string filename)
        {
            this.text = text;
            this.getterNumber = getterNumber;
            this.filename = filename;
        }
        public Message()
        {

        }
        public string sendMessage()
        {
            this.messageDate = DateTime.Now;
            loadToFile();
            return text;
        }

        public void setFilename(string filename)
        {
            this.filename = filename;
        }

        public void loadToFile()
        {
            File.AppendAllText(@$".\{filename}.txt", $"Date: {DateTime.Now} ------> To: user#{getterNumber}\n");
            File.AppendAllText(@$".\{filename}.txt", $"{text}\n");
        }
    }

    public class SendMessage
    {
        public Message message = new Message();

        public List<int> blackList = new List<int>();
        public SendMessage(Message message)
        {
            this.message = message;
        }
        public void replaceBlackList(List<int> blackList)
        {
            this.blackList = blackList;
        }
        public void addToBlackList(int number)
        {
            blackList.Add(number);
        }

        public string send()
        {
            foreach(int numb in blackList)
            {
                if(numb == message.getterNumber)
                {
                    throw new Exception("Number are in black list");
                }
            }
            return message.sendMessage();
        }
    }

}
