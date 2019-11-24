 using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt;
            Console.WriteLine("1. Add 2. Mult 3. Divide");
            opt = int.Parse(Console.ReadLine());
            int a = 25;
            int b = 35;
            switch(opt)
            {
                case 2:
                    Console.WriteLine("Multiplication is {0} x {1}: {2}",a,b, a * b);
                    break;
                case 1:
                    Console.WriteLine("Addition is {0} + {1}: {2}", a, b, a + b);
                    break;
                case 3:
                    Console.WriteLine("Division is {0} / {1}: {2}", a, b, a / b);
                    break;
            }
            Console.ReadLine();
        }
    }
}
