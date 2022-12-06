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
                var markerLength = 4;
                for (int i=0; i<line.Length; i++)
                {
                    var marker = line[i..(i+ markerLength)];
                    if (marker.Distinct().Count() == markerLength)
                    {
                        position = i + 4;
                        break;
                    }
                }
                Console.WriteLine("Part 1 is: " + position);

                // Part 2
                position = 0;
                var messageLength = 14;
                for (int i = 0; i < line.Length; i++)
                {
                    var marker = line[i..(i + messageLength)];
                    if (marker.Distinct().Count() == messageLength)
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

