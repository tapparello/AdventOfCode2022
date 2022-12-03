using System;
namespace AdventOfCode
{
	public class Day1
	{
		public Day1()
		{
		}

		public void Execute()
		{
            List<int> calories = new List<int>();
            var totalCaloriesForCurrentElf = 0;
            var maxCalories = 0;

            //Read the file and display it line by line.  
            foreach (string line in File.ReadLines(@"./assets/input-day1.txt"))
            {

                if (line.Equals(""))
                {
                    if (totalCaloriesForCurrentElf > maxCalories)
                    {
                        maxCalories = totalCaloriesForCurrentElf;
                    }

                    calories.Add(totalCaloriesForCurrentElf);
                    //Console.WriteLine(totalCaloriesForCurrentElf);
                    totalCaloriesForCurrentElf = 0;
                }
                else
                {
                    try
                    {
                        //Console.WriteLine(line);
                        var caloriesInLine = Int32.Parse(line);
                        totalCaloriesForCurrentElf += caloriesInLine;

                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }

            Console.WriteLine("Max Calories is: " + maxCalories);

            calories.Sort();
            calories.Reverse();

            var totalTopThree = calories[0] + calories[1] + calories[2];

            Console.WriteLine("Total Top 3 Elfes: " + totalTopThree);
        }
	}
}

