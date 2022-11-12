using System;
using System.Collections.Generic;
//Регулярні платежі містять список об’єктів Платіж (id, Призначення, дата,
//сума, статус оплачено/неоплачено). Розробити метод для створення копії
//обраного платежу на поточну дату.
//Вказати шаблон, який доцільно використати для розвязування задачі.
// Шаблон: Прототип
namespace AndrashkoModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Payment pay1 = new Payment(1, "It's a gift", DateTime.Now, 400, true);
            Payment pay2 = new Payment(2, "Thanks for the ride", DateTime.Now, 400, true);


            RegularPaymentList paymentList = new RegularPaymentList();

            paymentList.AddToList(pay1)
                .AddToList(pay2);

            Console.WriteLine(paymentList);
            
            paymentList.Clone(2, new DateTime(2023, 12, 11));

            Console.WriteLine("==============================\n" +
                "Clone a payment\n" +
                "==============================\n");
            Console.WriteLine(paymentList);
        }
    }
   public interface IPrototype
    {
        public IPrototype Clone();
    }
    class Payment : IPrototype
    {

        public int id, sum;
        public string appointment;
        public DateTime date;
        public bool status;
        public Payment(int id, string appointment, DateTime date, int sum, bool status)
        {
            this.id = id;
            this.appointment = appointment;
            this.date = date;
            this.sum = sum;
            this.status = status;
        }

        public IPrototype Clone()
        {
            return new Payment(id, appointment, date, sum, status);
        }
        public override string ToString()
        {
            return $"Id: {id}\n" +
                $"Appointment: {appointment}\n" +
                $"Date: {date}\n" +
                $"Sum: {sum}\n" +
                $"Status: {status}\n";
        }

    }
    class RegularPaymentList
    {
        public List<Payment> PaymentList = new List<Payment>();
        public RegularPaymentList(List<Payment> PaymentList)
        {
            this.PaymentList = PaymentList;
        }
        public RegularPaymentList()
        {

        }

        public RegularPaymentList AddToList(Payment Payment)
        {
            PaymentList.Add(Payment);
            return this;
        }

        public RegularPaymentList Clone(int id, DateTime newDate)
        {
            PaymentList.Add(PaymentList[id-1].Clone() as Payment);
            PaymentList[PaymentList.Count - 1].date = newDate;
            PaymentList[PaymentList.Count - 1].id = getUniqueId();
            return this;
        }
        public int getUniqueId()
        {
            int max = 0;
            foreach(Payment el in PaymentList)
            {
                if(el.id > max)
                {
                    max = el.id;
                }
            }
            return max + 1;
        }

        public override string ToString()
        {
            string result = "";
            foreach(Payment pay in PaymentList)
            {
                result += pay.ToString() + "--------------------------------------\n";
            }
            return result;
        }

    }
}
