using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defibrillators
{
    class Program
    {
        static void Main(string[] args)
        {
            var LON = double.Parse(Console.ReadLine().Replace(',', '.'));
            var LAT = double.Parse(Console.ReadLine().Replace(',', '.'));

            int N = int.Parse(Console.ReadLine());

            var nameOfTheNearestDefibrillator = string.Empty;
            var distOfTheNearestDefibrillator = double.MaxValue;

            for (int i = 0; i < N; i++)
            {
                string DEFIB = Console.ReadLine();

                var tokens = DEFIB.Split(';');


                var xDeg = double.Parse(tokens[4].Replace(',', '.'));
                var yDeg = double.Parse(tokens[5].Replace(',', '.'));

                var name = tokens[1];

                var dist = CaldDist(DegToRad(LON), DegToRad(LAT), DegToRad(xDeg), DegToRad(yDeg));
                if (dist < distOfTheNearestDefibrillator)
                {
                    distOfTheNearestDefibrillator = dist;
                    nameOfTheNearestDefibrillator = name;
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(nameOfTheNearestDefibrillator);
        }

        static double CaldDist(double longARad, double latARad, double longBRad, double latBRad)
        {
            var x = (longBRad - longARad) * Math.Cos((latARad + latBRad) / 2.0);
            var y = latBRad - latARad;
            var d = Math.Sqrt(x * x + y * y) * 6371.0;
            return d;
        }

        static double DegToRad(double degree)
        {
            var r = degree * Math.PI / 180.0;
            return r;
        }
    }
}
