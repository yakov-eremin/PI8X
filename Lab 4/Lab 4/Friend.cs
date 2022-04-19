using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    public class Friend
    {
        private string name;
        private string date;

        public Friend()
        {

        }

        public Friend(string name, string date)
        {
            this.name = name;
            this.date = date;
        }

        public string GetDate()
        {
            return date;
        }

        public string GetName()
        {
            return name;
        }

        public void Display()
        {
            Console.WriteLine(name);
        }
    }
}
