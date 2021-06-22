using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.Logic
{
    public class RPN
    {
        Stack<object> mainStack = new Stack<object>();
        Stack<object> secondStack = new Stack<object>();

        public Stack<object> ConvertToRPN(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString().ToLower() == "x")
                {
                    mainStack.Push(text[i].ToString());
                }
                else if (double.TryParse(text[i].ToString(), out double num))
                {
                    string str = "";
                    while (double.TryParse(text[i].ToString(), out _) || text[i] == ',')
                    {
                        str += text[i];
                        i++;
                        if (i == text.Length)
                        {
                            break;
                        }
                    }
                    mainStack.Push(Convert.ToDouble(str));
                    i--;
                }
                else
                {
                    switch (text[i])
                    {
                        case '(':
                            {
                                secondStack.Push(text[i].ToString());
                                break;
                            }
                        case ')':
                            {
                                while (secondStack.Peek().ToString() != "(")
                                {
                                    mainStack.Push(secondStack.Pop());
                                }

                                secondStack.Pop();
                                break;
                            }
                        default:
                            {
                                if (secondStack.Count == 0)
                                    secondStack.Push(text[i].ToString());
                                else
                                {
                                    double p = Operations.GetPriority(text[i].ToString());
                                    double pleft = Operations.GetPriority(secondStack.Peek().ToString());
                                    if (pleft >= p)
                                    {
                                        mainStack.Push((secondStack.Pop()));
                                        secondStack.Push(text[i].ToString());
                                    }
                                    else
                                        secondStack.Push(text[i].ToString());
                                }
                                break;
                            }
                    }
                }
            }

            foreach (var item in secondStack)
            {
                mainStack.Push(item);
            }

            return new Stack<object>(mainStack);
        }
        public override string ToString()
        {
            var stack = new Stack<object>(mainStack);
            string str = "";
            foreach (var item in stack)
            {
                str += item;
            }
            return str;
        }
    }
}
