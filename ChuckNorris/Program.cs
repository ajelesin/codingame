namespace ChuckNorris
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();

            var answer = Encode(MESSAGE);

            Console.WriteLine(answer);
        }

        public static string Encode(string input)
        {
            string encode = input.Select(x => (int)x)
                .Select(x => Convert.ToString(x, 2).PadLeft(7, '0'))
                .Aggregate((x, y) => x + y);

            encode = Regex.Replace(encode, @"(0+)", "00 $1 ");
            encode = Regex.Replace(encode, @"(1+)", "0 $1 ")
                        .Replace("1", "0")
                        .TrimEnd();

            return encode;
        }

        public static string Decode(string unary)
        {
            var blocks = unary.Split(' ');
            var sb = new StringBuilder();
            var finalsb = new StringBuilder();

            for (var i = 0; i < blocks.Length; i += 2)
            {
                if (blocks[i] == "0")
                {
                    sb.Append(new string('1', blocks[i + 1].Length));
                }
                else
                {
                    sb.Append(new string('0', blocks[i + 1].Length));
                }
            }

            string s = sb.ToString();
            for (var i = 0; i < s.Length; i += 7)
            {
                var substr = s.Substring(i, 7);
                var ch = (char)Convert.ToByte(substr, 2);
                finalsb.Append(ch);
            }

            return finalsb.ToString();
        }
    }
}
