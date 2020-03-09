using System;
using Library;
using static System.Console;

namespace Data.SchemaMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"The answer is {new Thing().Get(19, 23)}");
        }
    }
}
