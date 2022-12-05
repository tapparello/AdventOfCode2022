namespace AdventOfCode
{
	public class Day5
	{
		public Day5()
		{
		}

        public void Execute()
        {

            bool completedInput = false;
            List<Stack<string>> inputStacks = new();
            List<Stack<string>> stacks = new();
            List<Stack<string>> stacksPart2 = new();
            Stack<string> tempStack = new();

            for (int i = 0; i<10; i++)
            {
                inputStacks.Add(new Stack<string>());
                stacks.Add(new Stack<string>());
                stacksPart2.Add(new Stack<string>());
            }

            foreach (string line in File.ReadLines(@"./assets/input-day5.txt"))
            {

                if (!completedInput)
                {
                    if (line.Equals(""))
                    {
                        completedInput = true;

                        // Reverse the stack from the input as they are added to the stacks from top to bottom
                        for (int i = 1; i < 10; i++)
                        {
                            while (inputStacks[i].Count != 0)
                            {
                                var item = inputStacks[i].Pop();
                                stacks[i].Push(item);
                                stacksPart2[i].Push(item);
                            }
                        }
                    }
                    else
                    {
                        if (!line.Equals(" 1   2   3   4   5   6   7   8   9 "))
                        {
                            var level = GetCratesFromInput(line);

                            for (int i = 0; i < level.Count; i++)
                            {

                                if (!level[i].Equals(" "))
                                {
                                    inputStacks[i + 1].Push(level[i]);
                                }
                            }
                        }
                    }

                }
                else
                {
                    string[] words = line.Split(' ');
                    int count = Int32.Parse(words[1]);
                    int source = Int32.Parse(words[3]);
                    int destination = Int32.Parse(words[5]);

                    // Part 1
                    for (int i = 0; i < count; i++)
                    {
                        var toMove = stacks[source].Pop();
                        stacks[destination].Push(toMove);
                    }

                    // Part 2
                    tempStack.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        var toMove = stacksPart2[source].Pop();
                        tempStack.Push(toMove);
                    }

                    while (tempStack.Count > 0)
                    {
                        stacksPart2[destination].Push(tempStack.Pop());
                    }

                }
                
            }

            string finalTopStacks = "";
            // Part 1
            for (int i = 1; i < 10; i++)
            {
                finalTopStacks += stacks[i].Peek();
            }

            Console.WriteLine("Part 1 is: " + finalTopStacks);

            string finalTopStacksPart2 = "";
            // Part 2
            for (int i = 1; i < 10; i++)
            {
                finalTopStacksPart2 += stacksPart2[i].Peek();
            }

            Console.WriteLine("Part 2 is: " + finalTopStacksPart2);

        }

        private List<string> GetCratesFromInput(string line)
        {
            int crateSize = 4; // Format is [$] but we need to account for the space (' ') that separates stacks
            int stringLength = line.Length;
            List<string> level = new();
            for (int i = 0; i < stringLength; i += crateSize)
            {
                if (i + crateSize > stringLength) crateSize = stringLength - i; // Last crate doesn't have the space
                level.Add(line.Substring(i+1, 1)); // Discard the square brackets
            }
            return level;
        }
    }
}

