namespace Temperatures
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
            string[] inputs = Console.ReadLine().Split(' ');

            if (n == 0)
            {
                Console.WriteLine("0");
                return;
            }

            var result = inputs.Select(int.Parse)
                .OrderBy(Math.Abs)
                .ThenByDescending(x => x)
                .FirstOrDefault();

            Console.WriteLine(result);
        }
    }
}
