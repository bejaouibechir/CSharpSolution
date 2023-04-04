using System;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        
        static void Main(string[] args)
       {
             int a = 2, b = 3;
             Swap(a, b);
                
        }
        static void Swap(int a, int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
      

}


