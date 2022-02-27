using System;
using System.Collections.Generic;

namespace MyCalcLib
{
    public class MyCalc
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
        public int Del(int x, int y)
        {
            return x / y;
        }
        public int Min(int x, int y)
        {
            return x - y;
        }
        public int Pr(int x, int y)
        {
            return x * y;
        }
        public Boolean check_password(string password)
        {
            if (password.Length > 4)
                return true;
            else
                return false;
        }
        public int max_list(List<int> list_digit)
        {
            int max = list_digit[0];
            for (int i = 0; i < list_digit.Count; i++)
            {
                if (list_digit[i] > max)
                    max = list_digit[i];
            }
            return max;
        }
        public int Min(int a, int b, int c)
        {
            int min = a;
            if (min > b) min = b;
            if (min > c) min = c;
            return min;
        }

        public int hour_in_min(int a)
        {
            return a * 60;
        }
    }
}
