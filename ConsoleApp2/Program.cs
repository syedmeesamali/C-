using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating instance of our own defined class Humans
            Humans ali = new Humans();
            ali.firstName = "Meesam Ali";
            ali.intro();
        }
    }
}
