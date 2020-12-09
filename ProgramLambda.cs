using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*namespace SimpleInterest
{
    class Program
    {
        decimal SimpleInterest(decimal P, decimal N, decimal R)
        {
            return ((P * N * R) / 100);
        }
        static void Main(string[] args)
        {
            Func<decimal, decimal, decimal, decimal> si = (P, N, R) => { return (P * N * R) / 100; };
            Console.WriteLine("Simple Interest is : " + si(10000, 3, 5));
            Console.ReadLine();
        }
    }
}*/

/*namespace IsGreater
{
    class Program
    {
        bool isGreater(int a, int b)
        {
            if (a > b)
                return true;
            else
                return false;
        }
        static void Main()
        {
            Func<int, int, bool> gtr = (a, b) =>
            {
                return a > b ? true : false;
            };
            Console.WriteLine(gtr(7,5));
            Console.ReadLine();
        }
    }
}*/

namespace IsEven
{
    class Program
    {
        bool IsEven(int num)
        {
            return num % 2 == 0;    
        }
        static void Main()
        {
            Func<int, bool> isevn = num => (num % 2==0);
            Console.WriteLine("Enter a number to check even or odd");
            Console.WriteLine(isevn(Convert.ToInt32(Console.ReadLine())));
            Console.ReadLine();
        }
    }
}