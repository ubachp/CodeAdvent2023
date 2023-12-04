using System.Threading;
using CodeAdvent2023.Shared;

namespace CodeAdvent2023.Challenges;

public class Day01 : AdventDayBase, IAdventDay
{
    private string[] inputArray;

    public Day01(string cookie) : base(cookie)
    {
        var input = Helper.GetInput(@"https://adventofcode.com/2023/day/1/input", Cookie).Result;
        inputArray = input.Split("\n");
    }

    public async Task SolveA()
    {
        inputArray = [
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
            "bla"
        ];

        var total = 0;

        foreach (var line in inputArray)
        {
            var firstDigitsIndices = new Dictionary<int, int>();
            var firstDigitIndex = Array.FindIndex(line.ToCharArray(), char.IsDigit);
            var firstDigit = "";
            var sortedFirst = firstDigitsIndices.OrderBy(x => x.Key);

            if (sortedFirst.Any() && (sortedFirst.First().Key < firstDigitIndex || firstDigitIndex == -1))
            {
                firstDigit = sortedFirst.First().Value.ToString();
            }
            else
            {
                if (firstDigitIndex > -1)
                {
                    firstDigit = line[firstDigitIndex].ToString();
                }

            }

            var lastDigitsIndices = new Dictionary<int, int>();
            var lastDigitIndex = Array.FindLastIndex(line.ToCharArray(), char.IsDigit);
            var lastDigit = "";
            var sortedLast = lastDigitsIndices.OrderByDescending(x => x.Key);

            if (lastDigitsIndices.Any() && (sortedLast.First().Key > lastDigitIndex || lastDigitIndex == -1))
            {
                lastDigit = sortedLast.First().Value.ToString();
            }
            else
            {
                if (lastDigitIndex > -1)
                {
                    lastDigit = line[lastDigitIndex].ToString();
                }

            }

            if (string.IsNullOrEmpty(firstDigit))
            {
                continue;
            }

            var number = int.Parse($"{firstDigit}{lastDigit}");

            total += number;
        }

        Console.WriteLine($"Part A produces : {total}");
    }

    public async Task SolveB()
    {
        string[] ValidDigits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        inputArray = [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        ];

        var total = 0;

        foreach (var line in inputArray)
        {
            var firstDigitsIndices = new Dictionary<int, int>();
            var lastDigitsIndices = new Dictionary<int, int>();

            if (ValidDigits.Any(line.Contains))
            {
                for(var i = 0; i< ValidDigits.Length; i++)
                {
                    var indexOfFirstDigit = line.IndexOf(ValidDigits[i]);
                    var indexOfLastDigit = line.LastIndexOf(ValidDigits[i]);

                    if(indexOfFirstDigit != -1)
                    {
                        firstDigitsIndices.Add(indexOfFirstDigit, i + 1  );
                    }
                    if (indexOfLastDigit != -1)
                    {
                        lastDigitsIndices.Add(indexOfLastDigit,i + 1);
                    }
                }
            }
            var firstDigitIndex = Array.FindIndex(line.ToCharArray(), char.IsDigit);
            var lastDigitIndex = Array.FindLastIndex(line.ToCharArray(), char.IsDigit);

            var firstDigit = "";
            var sortedFirst = firstDigitsIndices.OrderBy(x => x.Key);

            if (sortedFirst.Any() && (sortedFirst.First().Key < firstDigitIndex || firstDigitIndex == -1))
            {
                firstDigit = sortedFirst.First().Value.ToString();
            }
            else
            {
                if(firstDigitIndex > -1)
                {
                    firstDigit = line[firstDigitIndex].ToString();
                }
                
            }

            var lastDigit = "";
            var sortedLast = lastDigitsIndices.OrderByDescending(x => x.Key);

            if (lastDigitsIndices.Any() && (sortedLast.First().Key > lastDigitIndex || lastDigitIndex == -1))
            {
                lastDigit = sortedLast.First().Value.ToString();
            }
            else
            {
                if( lastDigitIndex > -1)
                {
                    lastDigit = line[lastDigitIndex].ToString();
                }
                
            }

            if(string.IsNullOrEmpty(firstDigit))
            {
                continue;
            }
            
            var number = int.Parse($"{firstDigit}{lastDigit}");

            total += number;
        }

        Console.WriteLine($"Part B produces : {total}");

    }
}
