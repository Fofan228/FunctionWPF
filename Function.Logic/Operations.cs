using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.Logic
{
    public static class Operations
    {
        public static int GetPriority(string sign)
        {
            switch (sign)
            {
                case "+":
                case "-":
                    {
                        return 1;
                    }

                case "*":
                case "/":
                case "%":
                    {
                        return 2;
                    }

                case "^":
                case "!":
                    {
                        return 3;

                    }

                case "(":
                    {
                        return 0;
                    }
                default:
                    {
                        throw new ArgumentException("Нет такого знака!");
                    }
            }
        }
        public static double CountOperation(double num, double num2, string operation)
        {
            switch (operation)
            {
                case "*":
                    {
                        return num * num2;
                    }
                case "/":
                    {
                        return num2 / num;
                    }
                case "+":
                    {
                        return num + num2;
                    }
                case "-":
                    {
                        return num2 - num;
                    }
                case "^":
                    {
                        return Math.Pow(num2, num);
                    }
                case "!":
                    {
                        return GetFactorial((int)num);
                    }
                case "%":
                    {
                        return num2 % num;
                    }
                default:
                    {
                        throw new ArithmeticException("Ошибка вычисления!");
                    }
            }
        }
        static double GetFactorial(int x)
        {
            if (x <= 0)
            {
                return 1;
            }
            else
            {
                return x * GetFactorial(x - 1);
            }
        }
    }
}
