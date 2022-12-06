using System;
namespace AdventOfCode
{
    public class Day6
    {
        public Day6()
        {
        }

        public void Execute()
        {
            foreach (string line in File.ReadLines(@"./assets/input-day6.txt"))
            {

                // Part 1
                var position = 0;
                var markerLenght = 4;
                for (int i=0; i<line.Length; i++)
                {
                    var marker = line[i..(i+ markerLenght)];
                    if (marker.Distinct().Count() == markerLenght)
                    {
                        position = i + 4;
                        break;
                    }
                }
                Console.WriteLine("Part 1 is: " + position);

                // Part 2
                position = 0;
                var messageLenght = 14;
                for (int i = 0; i < line.Length; i++)
                {
                    var marker = line[i..(i + messageLenght)];
                    if (marker.Distinct().Count() == messageLenght)
                    {
                        position = i + 14;
                        break;
                    }
                }
                Console.WriteLine("Part 2 is: " + position);
            }
        }
    }
}

