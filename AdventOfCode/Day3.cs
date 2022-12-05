using System;
namespace AdventOfCode
{
    public class Day3
    {

        public Day3()
        {
        }

        public void Execute()
        {
            var totalPriorityPart1 = 0;
            var totalPriorityPart2 = 0;

            List<char> types = new();

            List<string> group = new();
            List<char> badges = new();

            foreach (string line in File.ReadLines(@"./assets/input-day3.txt"))
            {
                var subStringLenght = line.Length / 2;

                string rucksackOne = line.Substring(0, subStringLenght);
                string rucksackTwo = line.Substring(subStringLenght);

                var common = rucksackOne.Intersect(rucksackTwo);

                //Console.WriteLine("{0} - {1}: {2}", rucksackOne, rucksackTwo, common.ToString());
               
                foreach (char type in common)
                {
                    types.Add(type);
                }

                // Part 2
                group.Add(line);

                if (group.Count == 3)
                {
                    var badge = group[0].Intersect(group[1]).Intersect(group[2]);
                    foreach (char b in badge)
                    {
                        badges.Add(b);
                    }
                    group.Clear();
                }
            }

            foreach (var type in types)
            {
                //Console.WriteLine("{0} - {1}", type, GetPriorityForType(type));
                totalPriorityPart1 += GetPriorityForType(type);
            }

            Console.WriteLine("Total priority part 1 is: " + totalPriorityPart1);

            foreach (var badge in badges)
            {
                //Console.WriteLine("{0} - {1}", badge, GetPriorityForType(badge));
                totalPriorityPart2 += GetPriorityForType(badge);
            }

            Console.WriteLine("Total priority part 2 is: " + totalPriorityPart2);

        }

       public int GetPriorityForType(char type)
        {
            int asciiCode = (int)type;
            if (asciiCode > 91)
            {
                return asciiCode - 96; // a ascii code is 97 - 96 = priority 1
            }
            else
            {
                return asciiCode - 38; // A ascii code is 65 - 38 = priority 27
            }
        }
	}
}

