using CodeAdvent2023.Shared;

namespace CodeAdvent2023.Challenges;
public class Day04 : AdventDayBase, IAdventDay
{
    private string[] inputArray;
    public Day04(string cookie) : base(cookie)
    {
        var input = Helper.GetInput(@"https://adventofcode.com/2023/day/4/input", Cookie).Result;
        inputArray = input.Split("\n");
    }

    public Task SolveA()
    {
        //inputArray = [
        //    "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
        //    "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
        //    "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
        //    "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        //    "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        //    "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        //];
        var total = 0;

        foreach (var line in inputArray)
        {

            if (string.IsNullOrEmpty(line)) continue;
            var game = line.Substring(0, 8);
            var separationIndex = line.IndexOf("|");
            var winningNumber = line.Substring(8, separationIndex-8).Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            var gameNumbers = line.Substring(separationIndex+2).Trim().Split().Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            var gameTotal = 0;
            foreach (var item in gameNumbers)
            {
                if (winningNumber.Contains(item))
                {
                    gameTotal = gameTotal == 0 ? 1 : gameTotal * 2;
                }
            }
            total += gameTotal;
        }

        Console.WriteLine($"Step A produces : {total}");
        return Task.CompletedTask;

    }

    public Task SolveB()
    {

        return Task.CompletedTask;
    }
}
