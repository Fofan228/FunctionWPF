using System;
using System.Collections.Generic;

namespace Function.Logic
{
    public class Callculator
    {
        public double CallculateRPN(Stack<object> stack, double x)
        {
            int size = stack.Count;
            Stack<double> nums = new Stack<double>();
            for (int i = 0; i < size; i++)
            {
                if (stack.Peek() is double)
                {
                    nums.Push((double)stack.Pop());
                }
                else if (stack.Peek() is string operation)
                {
                    if (operation == "x")
                    {
                        nums.Push(x);
                    }
                    else if(operation == "!")
                    {
                        nums.Push(Operations.CountOperation(nums.Pop(), default, operation));
                    }
                    else
                    {
                        nums.Push(Operations.CountOperation(nums.Pop(), nums.Pop(), operation));
                    }
                    stack.Pop();
                }
                else
                {
                    throw new Exception("Нет значения!");
                }
            }
            return nums.Pop();
        }
    }
}
