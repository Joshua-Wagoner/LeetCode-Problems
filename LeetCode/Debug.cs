using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Debug
    {
        private static readonly string SPACE = " ";

        public static void Print(string s) { 
            Console.WriteLine(s);
        }

        public static void PrintVar(int var){
            Console.WriteLine(var);
        }

        public static void PrintArray(string[] array)
        {
            foreach(string s in array)
                Console.Write(s + SPACE);
        }
    }
}
