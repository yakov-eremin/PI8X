using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalcLib.Tests
{
    [TestClass()]
    public class MyCalcTests
    {
        [TestMethod()]
        public void Sum_10_20_Return_30()
        {
            // arrange
            int x = 10;
            int y = 20;
            int expected = 30;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Sum(x, y);

            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void Min_50_45()
        {
            // arrange
            int x = 50;
            int y = 45;
            int expected = 5;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Min(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Pr_3_4()
        {
            // arrange
            int x = 3;
            int y = 4;
            int expected = 12;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Pr(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Del_20_5()
        {
            // arrange
            int x = 20;
            int y = 5;
            int expected = 4;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Del(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Del_20_0()
        {
            // arrange
            int x = 20;
            int y = 0;
            int expected = 0;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Del(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Del_0_20()
        {
            // arrange
            int x = 0;
            int y = 20;
            int expected = 0;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Del(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void test_check_password()
        {
            // arrange
            string password = "Hello-81";
            Boolean expected = true;

            // act
            MyCalc help = new MyCalc();
            Boolean actual = help.check_password(password);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void test_max_list()
        {
            // arrange
            List<int> list_digit = new List<int>();
            list_digit.Add(5);
            list_digit.Add(-4);
            list_digit.Add(19);
            list_digit.Add(-89);

            int y = 0;
            int expected = 19;

            // act
            MyCalc help = new MyCalc();
            int actual = help.max_list(list_digit);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestMin()
        {
            // arrange
            int expected = 3;

            // act
            MyCalc help = new MyCalc();
            int actual = help.Min(3, 4, 5);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestHourInMin()
        {
            // arrange
            int expected = 180;

            // act
            MyCalc help = new MyCalc();
            int actual = help.hour_in_min(3);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}