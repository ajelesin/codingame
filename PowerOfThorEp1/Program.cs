namespace PowerOfThorEp1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int lightX = int.Parse(inputs[0]); // the X position of the light of power
            int lightY = int.Parse(inputs[1]); // the Y position of the light of power
            int initialTX = int.Parse(inputs[2]); // Thor's starting X position
            int initialTY = int.Parse(inputs[3]); // Thor's starting Y position

            // game loop
            while (true)
            {
                int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                if (initialTX > lightX && initialTY > lightY)
                {
                    initialTX -= 1;
                    initialTY -= 1;
                    Console.WriteLine("NW");
                }
                else if (initialTX < lightX && initialTY < lightY)
                {
                    initialTX += 1;
                    initialTY += 1;
                    Console.WriteLine("SE");
                }
                else if (initialTX < lightX && initialTY > lightY)
                {
                    initialTX += 1;
                    initialTY -= 1;
                    Console.WriteLine("NE");
                }
                else if (initialTX > lightX && initialTY < lightY)
                {
                    initialTX -= 1;
                    initialTY += 1;
                    Console.WriteLine("SW");
                }
                else if (initialTX == lightX)
                {
                    if (initialTY < lightY)
                    {
                        initialTY += 1;
                        Console.WriteLine("S");
                    }
                    else if (initialTY > lightY)
                    {
                        initialTY -= 1;
                        Console.WriteLine("N");
                    }
                }
                else if (initialTY == lightY)
                {
                    if (initialTX < lightX)
                    {
                        initialTX += 1;
                        Console.WriteLine("E");
                    }
                    else if (initialTX > lightX)
                    {
                        initialTX -= 1;
                        Console.WriteLine("W");
                    }
                }
            }
        }
    }
}
