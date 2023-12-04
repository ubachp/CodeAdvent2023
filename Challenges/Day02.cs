using CodeAdvent2023.Shared;

namespace CodeAdvent2023.Challenges;
public class Day02 : AdventDayBase, IAdventDay
{
    Dictionary<string, int> availableCubes = new Dictionary<string, int>()
    {
        { "red" , 12 },
        { "green" , 13 },
        { "blue" , 14 }
    };
    private string[] inputArray;

    public Day02(string cookie) : base(cookie)
    {
        var input =  Helper.GetInput(@"https://adventofcode.com/2023/day/2/input", Cookie).Result;
        inputArray = input.Split("\n");
    }

    public Task SolveA()
    {
        inputArray = [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        ];

        var total = 0;

        foreach (var line in inputArray)
        {
            if (string.IsNullOrEmpty(line)) continue;

            var indexOfCubes = line.IndexOf(":") + 2;
            var firstSpace = line.IndexOf(" ");
            var gameNumber = line.Substring(5, indexOfCubes - 3 - firstSpace);

            var handfuls = line.Substring(indexOfCubes).Split(';');
            var gameValid = true;

            var maxPerCubes = new Dictionary<string, int>()
            {
                { "red" , 0 },
                { "green" , 0 },
                { "blue" , 0 }
            };

            foreach (var handful in handfuls)
            {
                var cubes = handful.Split(", ");

                foreach (var cube in cubes)
                {
                    var result = cube.Trim().Split(" ");
                    var amount = int.Parse(result[0]);
                    var color = result[1];

                    if (maxPerCubes[color] < amount)
                    {
                        maxPerCubes[color] = amount;
                    }

                    if (amount > availableCubes[color])
                    {
                        gameValid = false;
                        break;
                    }

                    if (!gameValid)
                    {
                        break;
                    }
                }
            }

            if (gameValid)
            {
                total += int.Parse(gameNumber);
            }


        }

        Console.WriteLine($"Step A produces : {total}");
        return Task.CompletedTask;
    }

    public Task SolveB()
    {
        inputArray = [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        ];

        var total = 0;

        foreach (var line in inputArray)
        {
            if (string.IsNullOrEmpty(line)) continue;

            var indexOfCubes = line.IndexOf(":") + 2;
            var firstSpace = line.IndexOf(" ");
            var gameNumber = line.Substring(5, indexOfCubes - 3 - firstSpace);

            var handfuls = line.Substring(indexOfCubes).Split(';');
            var gameValid = true;

            var maxPerCubes = new Dictionary<string, int>()
            {
                { "red" , 0 },
                { "green" , 0 },
                { "blue" , 0 }
            };

            foreach (var handful in handfuls)
            {
                var cubes = handful.Split(", ");

                foreach (var cube in cubes)
                {
                    var result = cube.Trim().Split(" ");
                    var amount = int.Parse(result[0]);
                    var color = result[1];

                    if (maxPerCubes[color] < amount)
                    {
                        maxPerCubes[color] = amount;
                    }
                }
            }

            if (gameValid)
            {
                total += maxPerCubes["red"] * maxPerCubes["blue"] * maxPerCubes["green"];
            }


        }

        Console.WriteLine($"Step B produces : {total}");
        return Task.CompletedTask;
    }
}
