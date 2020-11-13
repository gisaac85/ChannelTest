using System;
using SharedLogic;

namespace ConsoleAppDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Console APP:\n\n");
            ConsoleLogic.GetAllOrder();
            ConsoleLogic.GetTopProducts(5);
            ConsoleLogic.UpdateStock();
        }
    }
}
