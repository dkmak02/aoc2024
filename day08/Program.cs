static List<List<char>> GetInput()
{
    var result = new List<List<char>>();
    var input = File.ReadAllText("C:\\Users\\dkmak\\Desktop\\aoc2024\\day08\\input.txt");

    foreach (var line in input.Split("\n", StringSplitOptions.RemoveEmptyEntries))
    {
        var trimmedLine = line.Trim();
        if (!string.IsNullOrEmpty(trimmedLine))
        {
            result.Add(new List<char>(trimmedLine));
        }
    }

    return result;
}
static bool IsWithinBounds(int x, int y, int height, int width)
{
    return x >= 0 && x < width && y >= 0 && y < height;
}

static HashSet<(int, int)> FindAntinodes(List<List<char>> grid, int i, int j, bool part2)
{
    var targetValue = grid[i][j];
    var height = grid.Count;
    var width = grid[0].Count;
    var antinodes = new HashSet<(int, int)>();

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            if (x == i && y == j) continue;

            if (grid[x][y] == targetValue)
            {
                if (part2)
                {
                    AddMirroredAntinodes(grid, antinodes, i, j, x, y);
                }
                else
                {
                    AddReflectedAntinode(grid, antinodes, i, j, x, y);
                }
            }
        }
    }

    return antinodes;
}
static void AddMirroredAntinodes(List<List<char>> grid, HashSet<(int, int)> antinodes, int i, int j, int x, int y)
{
    var xDiff = x - i;
    var yDiff = y - j;
    var height = grid.Count;
    var width = grid[0].Count;

    while (IsWithinBounds(x, y, height, width))
    {
        antinodes.Add((x, y));
        x += xDiff;
        y += yDiff;
    }
}
static void AddReflectedAntinode(List<List<char>> grid, HashSet<(int, int)> antinodes, int i, int j, int x, int y)
{
    var newX = 2 * x - i;
    var newY = 2 * y - j;
    var height = grid.Count;
    var width = grid[0].Count;

    if (IsWithinBounds(newX, newY, height, width))
    {
        antinodes.Add((newX, newY));
    }
}
static void Solve(List<List<char>> grid, bool part2)
{
    var visited = new HashSet<(int, int)>();

    for (int i = 0; i < grid.Count; i++)
    {
        for (int j = 0; j < grid[i].Count; j++)
        {
            if (grid[i][j] != '.')
            {
                var antinodes = FindAntinodes(grid, i, j, part2);
                foreach (var antinode in antinodes)
                {
                    visited.Add(antinode);
                }
            }
        }
    }

    Console.WriteLine(visited.Count);
}

static void Main()
{
    var input = GetInput();
    Console.WriteLine("Part 1:");
    Solve(input, part2: false);
    Console.WriteLine("Part 2:");
    Solve(input, part2: true); 
}
Main();