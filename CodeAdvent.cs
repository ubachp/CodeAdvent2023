using CodeAdvent2023.Challenges;

namespace CodeAdvent2023
{
    public class CodeAdvent
    {
        public static string Cookie { get; set; }
        public static async Task Run()
        {
            new Day01(Cookie).SolveA();
            new Day01(Cookie).SolveB();
            new Day02(Cookie).SolveA();
            new Day02(Cookie).SolveB();
            //await new Day03(Cookie).SolveA();
            //await new Day03(Cookie).SolveB();

        }
    }
}
