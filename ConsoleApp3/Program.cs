using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            RestGetter rg = new RestGetter();
            rg.SayHello();

            Console.WriteLine(rg.RekenWatUit(2, 5));

        }
    }
}
