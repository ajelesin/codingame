namespace ISBNCheckDigit
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());

            var invalidIsbnList = new List<string>();
            for (int i = 0; i < total; i++)
            {
                string isbn = Console.ReadLine();

                var checkSum = 0;
                var valid = true;

                if (isbn.Length == 10)
                {
                    for (var j = 0; j < 9; j++)
                    {
                        if (!char.IsDigit(isbn[j]))
                        {
                            valid = false;
                            break;
                        }

                        checkSum += (10 - j) * (isbn[j] - '0');
                    }

                    checkSum = 11 - (checkSum % 11);
                    valid = checkSum == 10 && isbn[9] == 'x' || (isbn[9] - '0') == checkSum;
                }
                else if (isbn.Length == 13)
                {
                    var w = 1;
                    for (var j = 0; j < 12; j++)
                    {
                        if (!char.IsDigit(isbn[j]))
                        {
                            valid = false;
                            break;
                        }

                        checkSum += w * (isbn[j] - '0');
                        w = w == 1 ? 3 : 1;
                    }

                    checkSum = 10 - (checkSum % 10);
                    valid = (isbn[9] - '0') == checkSum;
                }
                else
                {
                    valid = false;
                }

                if (!valid)
                {
                    invalidIsbnList.Add(isbn);
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(invalidIsbnList.Count + " invalid:");
            invalidIsbnList.ForEach(Console.WriteLine);
        }
    }
}
