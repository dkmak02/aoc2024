using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<List<int>> GetInput()
    {
        var lines = File.ReadAllLines("C:\\Users\\dkmak\\Desktop\\aoc2024\\day10\\input.txt");
        var files = new List<List<int>>();
        foreach (var line in lines)
        {
            var file = new List<int>();
            foreach (var c in line)
            {
                file.Add(c - '0');
            }
            files.Add(file);
        }
        return files;
    }

    static void Solve(List<List<int>> input, bool part2)
    {
        int rows = input.Count;
        int cols = input[0].Count;
        var directions = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

        int totalTrailheadScore = 0;

        for (int startRow = 0; startRow < rows; startRow++)
        {
            for (int startCol = 0; startCol < cols; startCol++)
            {
                if (input[startRow][startCol] == 0) 
                {
                    var visited = new bool[rows, cols];
                    var priorityQueue = new Queue<(int Value, int Row, int Col)>();
                    priorityQueue.Enqueue((0, startRow, startCol));
                    int reachableNines = 0;

                    while (priorityQueue.Count > 0)
                    {
                        var current = priorityQueue.Dequeue();

                        int value = current.Value;
                        int row = current.Row;
                        int col = current.Col;

                        if(visited[row, col] && !part2) continue;
                        visited[row, col] = true;

                        if (value == 9)
                        {
                            reachableNines++;
                            continue;
                        }

                        foreach (var (dr, dc) in directions)
                        {
                            int newRow = row + dr;
                            int newCol = col + dc;

                            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited[newRow, newCol] && input[newRow][newCol] == value + 1)
                            {
                                priorityQueue.Enqueue((input[newRow][newCol], newRow, newCol));
                            }
                        }
                    }

                    totalTrailheadScore += reachableNines;
                }
            }
        }

        Console.WriteLine(totalTrailheadScore);
    }

    static void Main()
    {
        var input = GetInput();
        Solve(input, false);
        Solve(input, true);
    }
}