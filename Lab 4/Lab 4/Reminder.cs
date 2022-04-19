using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab_4
{
    class Reminder
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

        public bool CompareDate(string birthdayDate, DateTime currentDate)
        {
            if ((DateTime.ParseExact(birthdayDate, "dd.MM.yyyy", new CultureInfo("de-DE")) - currentDate).Days == 0)
            {
                return true;
            }
            return false;
        }
    }
}
