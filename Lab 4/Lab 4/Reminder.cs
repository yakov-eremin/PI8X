﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace Lab_4
{
    public class Reminder
    {
        private List<Friend> friends;

        public Reminder()
        {
            friends = new List<Friend>();
        }
        public void Add(Friend friend)
        {
            this.friends.Add(friend);
        }

        public void Add(List<Friend> friends)
        {
            this.friends.AddRange(friends);
        }

        public void Delete(Friend friend)
        {
            this.friends.Remove(friend);
        }

        public List<Friend> GetFriends()
        {
            return friends;
        }

        private bool CompareDate(string birthdayDate, DateTime currentDate)
        {
            if ((DateTime.ParseExact(birthdayDate, "dd.MM.yyyy", new CultureInfo("de-DE")) - currentDate).Days == 0)
            {
                return true;
            }
            return false;
        }

        public string GetStatus(Friend friend, DateTime currentDate)
        {
            string result = "У Вашего друга по имени " + friend.GetName();
            if(CompareDate(friend.GetDate(), currentDate)) {
                result += " сегодня день рождения";
            }
            else
            {
                result += " день рождения НЕ скоро - " + friend.GetDate().ToString();
            }
            return result;
        }

        [Fact]
        void reminderGetStatusTest1()
        {
            Reminder reminder = new Reminder();
            Friend f = new Friend("Ilya", "01.12.1999");
            reminder.Add(f);
            Assert.Equal("У Вашего друга по имени Ilya сегодня день рождения", reminder.GetStatus(f, new DateTime(1999, 12, 01)));
        }

        [Fact]
        void reminderGetStatusTest2()
        {
            Reminder reminder = new Reminder();
            Friend f = new Friend("Ilya", "01.12.1999");
            reminder.Add(f);
            Assert.Equal("У Вашего друга по имени Ilya день рождения НЕ скоро - 01.12.1999", reminder.GetStatus(f, new DateTime(1999, 11, 01)));
        }

        [Fact]
        void reminderCompareDateTest()
        {
            Reminder reminder = new Reminder();
            Friend f = new Friend("Ilya", "01.12.1999");
            reminder.Add(f);
            Assert.True(reminder.CompareDate("01.12.1999", new DateTime(1999, 12, 01)));
        }
    }
}
