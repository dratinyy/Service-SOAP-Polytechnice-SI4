using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsLibrary.MathsOperationsClient client = MathsOperationsClient();
            Console.WriteLine(client.Add(100, 101));
            Console.WriteLine(client.Multiply(100, 101));
            Console.ReadLine();
        }
    }
}
