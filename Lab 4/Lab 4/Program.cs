using System;
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
    }
}
