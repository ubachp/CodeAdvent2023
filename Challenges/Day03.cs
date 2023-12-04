using CodeAdvent2023.Shared;

namespace CodeAdvent2023.Challenges;
public class Day03 : AdventDayBase, IAdventDay
{
    private string[] inputArray;

    public Day03(string cookie) : base(cookie)
    {
        var input = Helper.GetInput(@"https://adventofcode.com/2023/day/3/input", Cookie).Result;
        inputArray = input.Split("\n");
    }

    public Task SolveA()
    {
        inputArray = [
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        ];

        var grid = new Grid<char>(inputArray.Select(x => x.ToCharArray()).ToArray());

        var total = grid.Select(_ => {
            if (!char.IsDigit(grid.Get(_.x, _.y)) || char.IsDigit(grid.Get(_.x - 1, _.y, '1')))
                return 0;
            List<(int x, int y, int value)> numbers = new() { (_.x, _.y, grid.Get(_.x, _.y) - '0') };
            for (int i = 1; i < grid.ColumnSize - _.x; i++)
            {
                var right = grid.Get(_.x + i, _.y, ' ');
                if (!char.IsDigit(right)) break;
                numbers.Add((_.x + i, _.y, right - '0'));
            }
            var count = numbers.SelectMany(_ => grid.GetAdjcentWithIndex(_.x, _.y, false))
                .Distinct()
                .Count(_ => _.Value != '.' && !char.IsDigit(_.Value));
            //this.ToPrint.AppendLine(count + ": " + numbers.Select(_ => _.value).Aggregate((acc, num) => acc * 10 + num));
            return numbers.Select(_ => _.value).Aggregate((acc, num) => acc * 10 + num) * count;
        }).Sum();

        Console.WriteLine($"Produces : {total}");

        return Task.CompletedTask;

        //var matrix = inputArray.Select(x => x.ToCharArray()).ToArray();

        //var listOfNumber = new List<(int y, int startx, int len, int value)>();
        //var listOfGears = new List<(int y, int x)>();

        //for (var i = 0; i < matrix.Length; i++)
        //{
        //    var len = 0;
        //    var start = -1;
        //    var number = "";
        //    for (var j = 0; j < matrix[i].Length + 1; j++)
        //    {
        //        if (j == matrix[i].Length)
        //        {
        //            if (len > 0)
        //            {
        //                listOfNumber.Add((i, start, len, int.Parse(number)));
        //            }

        //            break;
        //        }

        //        if (matrix[i][j] == '*')
        //        {
        //            listOfGears.Add((i, j));
        //        }

        //        if (!char.IsDigit(matrix[i][j]))
        //        {
        //            if (len > 0)
        //            {
        //                listOfNumber.Add((i, start, len, int.Parse(number)));
        //                number = string.Empty;
        //            }

        //            len = 0;
        //            start = -1;
        //            continue;
        //        }

        //        if (char.IsDigit(matrix[i][j]))
        //        {
        //            if (len == 0) start = j;
        //            number += matrix[i][j];
        //            len++;
        //        }
        //        Console.Write(matrix[i][j]);
        //    }
        //    Console.WriteLine();
        //}

        //var total = 0;





        //var validNumbers = new List<int>();

        //foreach (var number in listOfNumber)
        //{
        //    //var number = listOfNumber.First();
        //    var txtNumber = "";
        //    var validNumber = false;
        //    for (var x = number.startx - 1; x <= number.startx + number.len; x++)
        //    {

        //        for (var y = number.y - 1; y <= number.y + 1; y++)
        //        {
        //            if (y == -1 || x == -1 || y >= matrix.Length || x >= matrix[y].Length)
        //            {
        //                continue;
        //            }

        //            Console.WriteLine(matrix[y][x]);

        //            if (y == number.y && char.IsDigit(matrix[y][x]))
        //            {
        //                txtNumber += matrix[y][x];
        //            }

        //            if ((!char.IsDigit(matrix[y][x]) && matrix[y][x] != '.'))
        //            {
        //                validNumber = true;
        //            }


        //        }
        //    }
        //    if (!string.IsNullOrWhiteSpace(txtNumber) && validNumber)
        //    {
        //        validNumber = false;
        //        total += int.Parse(txtNumber);
        //        txtNumber = string.Empty;
        //        validNumbers.Add(number.value);
        //    }
        //}
        //Console.WriteLine($"Produces : {total} {validNumbers.Sum()}");

    }

    public Task SolveB()
    {


        inputArray = [
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        ];

        var matrix = inputArray.Select(x => x.ToCharArray()).ToArray();

        var listOfNumber = new List<(int y, int startx, int len, int value)>();
        var listOfGears = new List<(int y, int x)>();

        for (var i = 0; i < matrix.Length; i++)
        {
            var len = 0;
            var start = -1;
            var number = "";
            for (var j = 0; j < matrix[i].Length + 1; j++)
            {
                if (j == matrix[i].Length)
                {
                    if (len > 0)
                    {
                        listOfNumber.Add((i, start, len, int.Parse(number)));
                    }

                    break;
                }

                if (matrix[i][j] == '*')
                {
                    listOfGears.Add((i, j));
                }

                if (!char.IsDigit(matrix[i][j]))
                {
                    if (len > 0)
                    {
                        listOfNumber.Add((i, start, len, int.Parse(number)));
                        number = string.Empty;
                    }

                    len = 0;
                    start = -1;
                    continue;
                }

                if (char.IsDigit(matrix[i][j]))
                {
                    if (len == 0) start = j;
                    number += matrix[i][j];
                    len++;
                }
                Console.Write(matrix[i][j]);
            }
            Console.WriteLine();
        }

        var total = 0;

        foreach (var gear in listOfGears)
        {
            var parts = new List<(int y, int startx, int len, int value)>();
            var tl = listOfNumber.Where(part =>
             part.y == gear.y - 1 && gear.x - 1 == (part.startx + part.len) - 1);
            var t = listOfNumber.Where(part =>
             part.y == gear.y - 1 && gear.x >= part.startx && gear.x <= (part.startx + part.len) - 1);
            var tr = listOfNumber.Where(part =>
             part.y == gear.y - 1 && gear.x + 1 == part.startx);

            var l = listOfNumber.Where(part =>
             part.y == gear.y && gear.x - 1 == (part.startx + part.len) - 1);
            var r = listOfNumber.Where(part =>
             part.y == gear.y && gear.x + 1 == part.startx);

            var bl = listOfNumber.Where(part =>
             part.y == gear.y + 1 && gear.x - 1 == (part.startx + part.len) - 1);
            var b = listOfNumber.Where(part =>
             part.y == gear.y + 1 && gear.x >= part.startx && gear.x <= (part.startx + part.len) - 1);
            var br = listOfNumber.Where(part =>
             part.y == gear.y + 1 && gear.x + 1 == part.startx);

            parts.AddRange(tl);
            parts.AddRange(t);
            parts.AddRange(tr);
            parts.AddRange(l);
            parts.AddRange(r);
            parts.AddRange(bl);
            parts.AddRange(b);
            parts.AddRange(br);

            parts = parts.Distinct().ToList();

            if (parts.Count == 2)
            {
                total += parts[0].value * parts[1].value;
            }
        }
        Console.WriteLine($"Produces : {total}");

        return Task.CompletedTask;
    }
}
