using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

public class BinaryTreeNode
{
    public List<BigInteger> Data { get; set; }
    public BinaryTreeNode Left { get; set; }   
    public BinaryTreeNode Right { get; set; } 
    public BinaryTreeNode Middle { get; set; } 

    public BinaryTreeNode(List<BigInteger> data)
    {
        Data = new List<BigInteger>(data);
    }
}

class Program
{
    static List<List<BigInteger>> GetInput()
    {
        var res = new List<List<BigInteger>>();
        var input = File.ReadAllText("C:\\Users\\dkmak\\Desktop\\aoc2024\\day07\\input.txt");
        foreach (var line in input.Split("\n", StringSplitOptions.RemoveEmptyEntries))
        {
            var data = new List<BigInteger>();
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                if (part.Contains(":"))
                {
                    data.Add(BigInteger.Parse(part.Substring(0, part.Length - 1)));
                }
                else
                {
                    data.Add(BigInteger.Parse(part));
                }
            }
            res.Add(data);
        }
        return res;
    }

    static void Solve1(List<List<BigInteger>> data)
    {
        BigInteger res = 0;
        foreach (var item in data)
        {
            BigInteger requiredSum = item[0];
            List<BigInteger> values = item.GetRange(1, item.Count - 1);

            BinaryTreeNode root = BuildTree(values, requiredSum);
            if (EvaluateTree(root, requiredSum))
            {
                res += requiredSum;
            }
        }
        Console.WriteLine(res);
    }
    static void Solve2(List<List<BigInteger>> data)
    {
        BigInteger res = 0;
        foreach (var item in data)
        {
            BigInteger requiredSum = item[0];
            List<BigInteger> values = item.GetRange(1, item.Count - 1);

            BinaryTreeNode root = BuildTree(values, requiredSum);
            if (EvaluateTree(root, requiredSum))
            {
                res += requiredSum;
            }
        }
        Console.WriteLine(res);
    }

    static BinaryTreeNode BuildTree(List<BigInteger> values, BigInteger requiredSum)
    {
        return new BinaryTreeNode(values);
    }

    static bool EvaluateTree(BinaryTreeNode node, BigInteger requiredSum)
    {
        if (node.Data.Count == 1)
        {
            return node.Data[0] == requiredSum;
        }

        BigInteger first = node.Data[0];
        BigInteger second = node.Data[1];
        List<BigInteger> remaining = node.Data.GetRange(2, node.Data.Count - 2);

        List<BigInteger> leftData = new List<BigInteger> { first * second };
        leftData.AddRange(remaining);
        node.Left = new BinaryTreeNode(leftData);

        List<BigInteger> rightData = new List<BigInteger> { first + second };
        rightData.AddRange(remaining);
        node.Right = new BinaryTreeNode(rightData);

        List<BigInteger> middleData = new List<BigInteger> { Concatenate(first, second) };
        middleData.AddRange(remaining);
        node.Middle = new BinaryTreeNode(middleData);

        return EvaluateTree(node.Left, requiredSum) ||
               EvaluateTree(node.Right, requiredSum) ||
               EvaluateTree(node.Middle, requiredSum);
    }

    static BigInteger Concatenate(BigInteger first, BigInteger second)
    {
        return BigInteger.Parse($"{first}{second}");
    }

    static void Main()
    {
        var input = GetInput();
        Solve1(input);
        Solve2(input);
    }
}
