using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient client = MathsOperationsClient();
            Console.WriteLine(client.Add(100, 101));
            Console.WriteLine(client.Multiply(100, 101));
            Console.ReadLine();
        }
    }
}
