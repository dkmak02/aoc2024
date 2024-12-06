using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<List<char>> GetInput()
    {
        var res = new List<List<char>>();
        var input = File.ReadAllText("C:\\Users\\dkmak\\Desktop\\aoc2024\\day06\\input.txt");
        foreach (var line in input.Split("\n", StringSplitOptions.RemoveEmptyEntries))
        {
            var data = new List<char>(line.Trim());
            res.Add(data);
        }
        return res;
    }

    static (int, int) FindLocation(List<List<char>> data)
    {
        var lookingFor = new HashSet<char> { '>', '<', '^', 'v' };
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[i].Count; j++)
            {
                if (lookingFor.Contains(data[i][j]))
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1);
    }

    static string FindDirection(char c)
    {
        return c switch
        {
            '^' => "N",
            '>' => "E",
            'v' => "S",
            _ => "W"
        };
    }


    static (int, int) Move((int, int) location, string direction)
    {
        return direction switch
        {
            "N" => (location.Item1 - 1, location.Item2),
            "E" => (location.Item1, location.Item2 + 1),
            "S" => (location.Item1 + 1, location.Item2),
            "W" => (location.Item1, location.Item2 - 1),
            _ => location
        };
    }

    static bool CheckIfOut((int, int) location, int rows, int cols)
    {
        return location.Item1 < 0 || location.Item2 < 0 || location.Item1 >= rows || location.Item2 >= cols;
    }

    static bool Solve1(List<List<char>> data)
    {
        var visited = new HashSet<(int, int)>();
        var location = FindLocation(data);
        var iter = 0;
        var directionList = new List<string> { "N", "E", "S", "W" };
        string direction = FindDirection(data[location.Item1][location.Item2]);

        visited.Add(location);

        while (!CheckIfOut(location, data.Count, data[0].Count) && iter <1000)
        {
            var nextLocation = Move(location, direction);
            if(CheckIfOut(nextLocation, data.Count, data[0].Count))
            {
                break;
            }
            if (
                (data[nextLocation.Item1][nextLocation.Item2] == '#'))
            {
                direction = directionList[(directionList.IndexOf(direction) + 1) % 4];
            }
            else
            {
                location = nextLocation;
                if(visited.Contains(location))
                {
                    iter++;
                }
                visited.Add(location);
            }
        }
        if (iter > 999)
        {
            return true;
        }
        return false;
    }

    static List<List<char>> DeepCopy(List<List<char>> original)
    {
        var copy = new List<List<char>>();
        foreach (var row in original)
        {
            copy.Add(new List<char>(row));
        }
        return copy;
    }
    static void Solve2(List<List<char>> data)
    {
        var len = data.Count;
        var width = data[0].Count;
        var res = 0;

        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (data[i][j] == '.')
                {
                    var newData = DeepCopy(data);
                    newData[i][j] = '#';
                    if (Solve1(newData))
                    {
                        res++;
                    }
                }
            }
        }

        Console.WriteLine(res);
    }

    static void Main()
    {

        var data = GetInput();
        Solve1(data);
        Solve2(data);

    }
}
