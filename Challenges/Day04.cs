using CodeAdvent2023.Shared;

namespace CodeAdvent2023.Challenges;
public class Day04 : AdventDayBase, IAdventDay
{
    private string[] inputArray;
    public Day04(string cookie) : base(cookie)
    {
        var input = Helper.GetInput(@"https://adventofcode.com/2023/day/3/input", Cookie).Result;
        inputArray = input.Split("\n");
    }

    public Task SolveA()
    {

        return Task.CompletedTask;

    }

    public Task SolveB()
    {

        return Task.CompletedTask;
    }
}
