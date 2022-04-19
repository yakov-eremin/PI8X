using System;
using System.Collections.Generic;
using Xunit;

namespace Lab_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в напоминалку");
            Reminder reminder = new Reminder();
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("\t1 - Добавить друга");
                Console.WriteLine("\t2 - Вывести список друзей");
                Console.WriteLine("\t3 - Удалить друга");
                Console.WriteLine("\t4 - У кого сегодня день рождения?");
                Console.WriteLine("\t5 - У кого день рождения в течение месяца?");
                Console.WriteLine("\tЛюбой другой символ - выход из программы");

                choice = Convert.ToInt32(Console.ReadLine());

            } while (reminder.DoSomething(choice));
        }

        [Fact]
        public void Test()
        {
            Console.WriteLine("Это пустой тест");
        }

        [Fact]
        void reminderClassCreationTest()
        {
            Reminder reminder = new Reminder();
        }

        [Fact]
        void reminderAddFriendTest()
        {
            Reminder reminder = new Reminder();
            reminder.Add(new Friend());
        }

        [Fact]
        void reminderAddFriendWithNameAndDateTest()
        {
            Reminder reminder = new Reminder();
            reminder.Add(new Friend("Kolya", "11.01.2001"));
        }

        [Fact]
        void reminderAddSomeFriendTest()
        {
            Reminder reminder = new Reminder();
            reminder.Add(new Friend("Kolya", "11.01.2001"));
            reminder.Add(new List<Friend>() { new Friend("Ilya", "01.12.1999"), new Friend("Volodya", "24.02.2000") });
            reminder.Add(new Friend("Anya", "26.12.2002"));
        }

        [Fact]
        void reminderDeleteFriendTest()
        {
            Reminder reminder = new Reminder();
            Friend f = new Friend("Ilya", "01.12.1999");
            reminder.Add(f);
            reminder.Delete(f);
            Assert.Empty(reminder.GetFriends());
        }

        

    }
}
