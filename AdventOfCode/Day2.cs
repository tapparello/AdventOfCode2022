using System;
namespace AdventOfCode
{
    public class Day2
    {
        int WIN = 6;
        int DRAW = 3;
        int LOST = 0;

        public Day2()
        {
        }

        public void Execute()
        {
            var totalScorPart1 = 0;
            var totalScorPart2 = 0;

            foreach (string line in File.ReadLines(@"./assets/input-day2.txt"))
            {

                totalScorPart1 += ScoreGamePart1(line);

                totalScorPart2 += ScoreGamePart2(line);

            }

            Console.WriteLine("Total score part 1 is: " + totalScorPart1);
            Console.WriteLine("Total score part 2 is: " + totalScorPart2);
        }

        public int ScoreGamePart1(string game)
        {
            var playedHand = ChoiceToScore(game.Split(' ')[1]);
            var gameResult = 0;

            switch (game)
            {
                case "A Y":
                case "B Z":
                case "C X":
                    gameResult = WIN;
                    break;
                case "A X":
                case "B Y":   
                case "C Z":
                    gameResult = DRAW;
                    break;
                case "A Z":
                case "B X":
                case "C Y":
                    gameResult = LOST;
                    break;
                default:
                    break;
            }

            return (playedHand + gameResult);

        }

        public int ScoreGamePart2(string game)
        {
            var playedHand = 0;
            var gameResult = ChoiceToResult(game.Split(' ')[1]);

            switch (game)
            {
                case "A X":
                case "C Y":
                case "B Z":
                    playedHand = ChoiceToScore("Scissor");
                    break;
                case "B X":
                case "A Y":
                case "C Z":
                    playedHand = ChoiceToScore("Rock");
                    break;
                case "C X":
                case "B Y":
                case "A Z":
                    playedHand = ChoiceToScore("Paper");
                    break;
                default:
                    break;
            }

            return playedHand + gameResult;
        }

        public int ChoiceToScore (string choice)
        {
            return choice switch
            {
                "X" or "A" or "Rock" => 1,
                "Y" or "B" or "Paper" => 2,
                "Z" or "C" or "Scissor" => 3,
                _ => 0,
            };
        }

        public int ChoiceToResult (string choice)
        {
            return choice switch
            {
                "X" => LOST,
                "Y" => DRAW,
                "Z" => WIN,
                _ => 0,
            };
        }

	}
}

