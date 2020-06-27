using AccountingSystem.Core.Enums;
using System;

namespace TestFeatsures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            foreach (var possibleTransactions in Enum.GetValues(typeof(PossibleTransactions)))
            {
                Console.WriteLine(possibleTransactions);
            }
        }
    }
}
