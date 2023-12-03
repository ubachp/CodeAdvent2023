using System.Threading;
using CodeAdvent2023.Shared;

namespace CodeAdvent2023.Challenges;

public class Day01 : AdventDayBase, IAdventDay
{
    public Day01(string cookie) : base(cookie)
    {
    }

    public Task SolveA()
    {
        throw new NotImplementedException();
    }

    public async Task SolveB()
    {
        string[] ValidDigits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        

        var input = await Helper.GetInput(@"https://adventofcode.com/2023/day/1/input", Cookie);
        var inputArray = input.Split("\n");
        //string[] inputArray = [
        //    "1abc2",
        //    "pqr3stu8vwx",
        //    "a1b2c3d4e5f",
        //    "treb7uchet",
        //    "bla"
        //];
        //string[] inputArray = [
        //    "two1nine",
        //    "eightwothree",
        //    "abcone2threexyz",
        //    "xtwone3four",
        //    "4nineeightseven2",
        //    "zoneight234",
        //    "7pqrstsixteen",
        //];

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

            Console.WriteLine($"{line} -> {number}");

            total += number;
        }

        Console.WriteLine($"Produces : {total}");

    }
}
