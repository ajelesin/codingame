namespace MIMEType
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.


            var MimeReference = new Dictionary<string, string>();

            while (N --> 0)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string EXT = inputs[0].ToUpperInvariant(); // file extension
                string MT = inputs[1]; // MIME type.

                MimeReference[EXT] = MT;
            }


            while (Q --> 0)
            {
                string FNAME = Console.ReadLine(); // One file name per line.

                var ext = Path.GetExtension(FNAME).TrimStart('.').ToUpperInvariant();
                MimeReference.TryGetValue(ext, out var mime);

                Console.WriteLine(mime ?? "UNKNOWN");
            }
        }
    }
}
