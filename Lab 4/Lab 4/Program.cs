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

    }
}
