using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myCalculator
{
    public class Calculator
    {
        public string code;
        public List<string> Id;
        public Stack<string> st;
        public bool isLegal;
        public int [][]arr= new int[][]{ new int[]{ 1,1,2,2,2,2,1,1},new int[]{1,1,2,2,2,2,1,1 },
                new int[]{1,1,1,1,2,2,1,1 },new int[]{1,1,1,1,2,2,1,1 },
                new int[]{1,1,1,1,4,4,1,1 },new int[]{ 2,2,2,2,2,2,3,4},
                new int[]{1,1,1,1,4,4,1,1 },new int[]{2,2,2,2,2,2,4,4 } };
        public  Calculator(string str)
        {
            st = new Stack<string>();//分析、计算用栈
            Id = new List<string>();//计算用字符表
            code = str;
            isLegal = true;
            //+,-,*,/,i,(,),#
        }
        public int getId(string a)
        {
            if (a == "+") return 0;
            if (a == "-") return 1;
            if (a == "*") return 2;
            if (a == "/") return 3;
            if (a == "id") return 4;
            if (a == "(") return 5;
            if (a == ")") return 6;
            if (a == "#") return 7;
            else return 9;
        }
        public void Transform()//转换
        {
            int ic = 0; int jn;
            while (ic < code.Length)
            {
                char[] na = new char[100];
                jn = 0;
                if (code[ic] == '#')
                {
                    ic++; continue;
                }
                else if (code[ic] == ' ')
                {
                    ic++; continue;
                }
                else if (code[ic] >= '0' && code[ic] <= '9')//数字
                {
                    na[jn] = code[ic];
                    ic++; jn++;
                    for (; ic < code.Length; ic++, jn++)
                    {
                        if (!((code[ic] >= '0' && code[ic] <= '9')||code[ic]=='.'))
                        {
                            jn--; ic--;
                            break;
                        }
                        na[jn] = code[ic];
                    }
                    string str = new string(na);
                    Id.Add(str);
                }
                else if (code[ic] == '+')
                {
                    Id.Add("+");
                }
                else if (code[ic] == '-')
                {
                    Id.Add("-");
                }
                else if (code[ic] == '*')
                {
                    Id.Add("*");
                }
                else if (code[ic] == '/')
                {
                    Id.Add("/");
                }
                else if (code[ic] == '(')
                {
                    Id.Add("(");
                }
                else if (code[ic] == ')')
                {
                    Id.Add(")");
                }
                else
                {
                    isLegal = false;
                    break;
                }
                ic++;
            }
        }
        public double Compute()
        {
            st.Clear();
            st.Push("#");
            int i = 0, j = 0;//i为遍历的顺序，j为数字存储的顺序
            while (i < Id.Count)//中缀表达式转后缀表达式
            {
                if (Id[i][0] >= '0' && Id[i][0] <= '9')
                {
                    Id[j] = Id[i]; j++; i++;
                }
                else if (Id[i] == "(")
                {
                    st.Push("("); i++;
                }
                else if (Id[i] == "+")
                {
                    if (arr[getId(st.Peek())][0] == 2)
                    {
                        st.Push("+"); i++;
                    }
                    else
                    {
                        while (true)
                        {
                            Id[j] = st.Pop(); j++;
                            if (arr[getId(st.Peek())][0] == 2) break;
                        }
                    }
                }
                else if (Id[i] == "-")
                {
                    if (arr[getId(st.Peek())][1] == 2)
                    {
                        st.Push("-"); i++;
                    }
                    else
                    {
                        while (true)
                        {
                            Id[j] = st.Pop(); j++;
                            if (arr[getId(st.Peek())][1] == 2) break;
                        }
                    }
                }
                else if (Id[i] == "*")
                {
                    if (arr[getId(st.Peek())][2] == 2)
                    {
                        st.Push("*"); i++;
                    }
                    else
                    {
                        while (true)
                        {
                            Id[j] = st.Pop(); j++;
                            if (arr[getId(st.Peek())][2] == 2) break;
                        }
                    }
                }
                else if (Id[i] == "/")
                {
                    if (arr[getId(st.Peek())][3] == 2)
                    {
                        st.Push("/"); i++;
                    }
                    else
                    {
                        while (true)
                        {
                            Id[j] = st.Pop(); j++;
                            if (arr[getId(st.Peek())][3] == 2) break;
                        }
                    }
                }
                else if (Id[i] == ")")
                {
                    while (true)
                    {
                        Id[j] = st.Pop(); j++;
                        if (Id[j - 1] == "(")
                        {
                            j--; break;
                        }
                        if (Id[j - 1] == "#")
                        {
                            st.Push("#");
                            j--;
                            break;
                        }
                    }
                    i++;
                }
            }
            while (st.Count >= 2)
            {
                Id[j] = st.Pop(); j++;
            }
            Stack<double> result = new Stack<double>();
            i = 0;
            //以上正确
            while (i < j)//计算
            {
                try
                {
                    if (Id[i][0] >= '0' && Id[i][0] <= '9')
                    {
                        result.Push(Convert.ToDouble(Id[i]));
                        i++;
                    }
                    else if (Id[i] == "-")
                    {
                        double t1 = result.Pop();
                        result.Push(result.Pop() - t1);
                        i++;
                    }
                    else if (Id[i] == "+")
                    {
                        double t1 = result.Pop();
                        result.Push(result.Pop() + t1);
                        i++;
                    }
                    else if (Id[i] == "*")
                    {
                        double t1 = result.Pop();
                        result.Push(result.Pop() * t1);
                        i++;
                    }
                    else if (Id[i] == "/")
                    {
                        double t1 = result.Pop();
                        try
                        {
                            result.Push(result.Pop() / t1);
                        }
                        catch (Exception)
                        {
                            isLegal = false;
                            code = "Error";
                            break;
                        }
                        i++;
                    }
                }
                catch (System.InvalidOperationException)
                {
                    isLegal=false;
                    break;
                }
            }
            if (i >= j)
            {
                return result.Peek();
            }
            else 
                return 0;

        }
        public double run()
        {
            st.Push("#");
            Transform();
            if (isLegal == true)
            {
                st.Clear();
                st.Push("#");
                return Compute();
            }
            else 
                return 0.0;
        }
    }
}
