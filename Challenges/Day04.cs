using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public async Task SolveA()
    {
        throw new NotImplementedException();

    }

    public Task SolveB()
    {
        throw new NotImplementedException();
    }
}
