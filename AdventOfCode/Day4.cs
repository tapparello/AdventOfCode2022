using System;
namespace AdventOfCode
{
	public class Day4
	{
		public Day4()
		{
		}

        public void Execute()
        {
            var totalOverlaps = 0;
            var partialOverlaps = 0;

            foreach (string line in File.ReadLines(@"./assets/input-day4.txt"))
            {
                var delimiter = line.IndexOf(",");

                string sectionOne = line[..delimiter];
                string sectionTwo = line[(delimiter + 1)..];

                // Part 1
                totalOverlaps += SectionsOverlap(sectionOne, sectionTwo);

                //Console.WriteLine("{0} - {1}: {2}", sectionOne, sectionTwo, totalOverlaps);

                // Part 2
                partialOverlaps += SectionsWithPartialOverlap(sectionOne, sectionTwo);

            }

            Console.WriteLine("Total overlaps part 1 is: " + totalOverlaps);

            Console.WriteLine("Partial overlaps part 2 is: " + partialOverlaps);

        }

        public int SectionsOverlap(string sectionOne, string sectionTwo)
        {

            // One into Two?
            if ((GetStartOfSection(sectionOne) >= GetStartOfSection(sectionTwo))
                && (GetEndOfSection(sectionOne) <= GetEndOfSection(sectionTwo)))
            {
                return 1;
            }

            // Two into One?
            if ((GetStartOfSection(sectionTwo) >= GetStartOfSection(sectionOne))
                && (GetEndOfSection(sectionTwo) <= GetEndOfSection(sectionOne)))
            {
                return 1;
            }

            return 0;
        }

        public int SectionsWithPartialOverlap(string sectionOne, string sectionTwo)
        {

            // One into Two?
            if ((GetStartOfSection(sectionOne) >= GetStartOfSection(sectionTwo))
                && (GetStartOfSection(sectionOne) <= GetEndOfSection(sectionTwo)))
            {
                return 1;
            }

            // Two into One?
            if ((GetStartOfSection(sectionTwo) >= GetStartOfSection(sectionOne)) &&
                (GetStartOfSection(sectionTwo) <= GetEndOfSection(sectionOne)))
            {
                return 1;
            }

            return 0;
        }

        public int GetStartOfSection(string section)
        {
            return Int32.Parse(section[..section.IndexOf("-")]);
        }

        public int GetEndOfSection(string section)
        {
            return Int32.Parse(section[(section.IndexOf("-") + 1)..]);
        }

    }
}

