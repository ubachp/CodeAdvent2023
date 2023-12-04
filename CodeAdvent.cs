using CodeAdvent2023.Challenges;

namespace CodeAdvent2023
{
    public class CodeAdvent
    {
        public static string Cookie { get; set; }
        public static async Task Run()
        {
            await new Day01(Cookie).SolveA();
            await new Day01(Cookie).SolveB();
            //await new Day02(Cookie).Solve();
            //await new Day03(Cookie).SolveA();
            //await new Day03(Cookie).SolveB();

        }
    }
}
