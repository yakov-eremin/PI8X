using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    class Reminder
    {
        private List<Friend> friend;

        public Reminder()
        {
            friend = new List<Friend>();
        }
        public void Add(Friend friend)
        {
            this.friend.Add(friend);
        }

        public void Add(List<Friend> friends)
        {
            this.friend.AddRange(friends);
        }
    }
}
