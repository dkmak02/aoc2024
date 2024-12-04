// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

List<List<string>> GetInput()
{
    var possible = new List<string> { "M", "A", "S", "X" };
    var res = new List<List<string>>();
    var input = File.ReadAllText("input.txt");
    foreach (var line in input.Split("\n"))
    {
        var data = new List<string>();
        foreach (var item in line.ToCharArray())
        {
             data.Add(item.ToString());
        }
        res.Add(data);
    }
    return res;
}
bool CheckHorizontalDown(List<List<string>> data, int i, int j, int height)
{
    if(i==3 && j == 9)
    {
        Console.WriteLine("Here");
    }
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while(i < height)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else {
            return false;
         }
        i+=1;
    }
    return false;
}
bool CheckHorizontalUp(List<List<string>> data, int i, int j, int height)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (i >= 0)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        i -= 1;
    }
    return false;

}
bool CheckVerticalRight(List<List<string>> data, int i, int j, int len)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (j < len)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        j+= 1;
    }
    return false;

}
bool CheckVerticalLeft(List<List<string>> data, int i, int j, int len)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (j >= 0)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        j -= 1;
    }
    return false;
}
bool CheckDiagonalDownRight(List<List<string>> data, int i, int j, int height, int len)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (i < height && j < len)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        i += 1;
        j += 1;
    }
    return false;
}
bool CheckDiagonalDownLeft(List<List<string>> data, int i, int j, int height, int len)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (i < height && j >= 0)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        i += 1;
        j -= 1;
    }
    return false;
}
bool CheckDiagonalUpRight(List<List<string>> data, int i, int j, int height, int len)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (i >= 0 && j < len)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        i -= 1;
        j += 1;
    }
    return false;
}
bool CheckDiagonalUpLeft(List<List<string>> data, int i, int j, int height, int len)
{
    var needs = new List<string> { "M", "A", "S" };
    var currentNeeds = 0;
    while (i >= 0 && j >= 0)
    {
        if (data[i][j] == needs[currentNeeds])
        {
            if (needs[currentNeeds] == "S")
            {
                return true;
            }
            currentNeeds += 1;
        }
        else
        {
            return false;
        }
        i -= 1;
        j -= 1;
    }
    return false;
}

void Solve1(List<List<string>> data)
{
    var len = data[0].Count-1;
    var height = data.Count;
    var res = 0;
    for(int i = 0; i < height; i++)
    {
        for(int j = 0; j < len; j++)
        {
            if (data[i][j].Equals("X"))
            {
                if (CheckHorizontalDown(data, i + 1, j, height))
                {
                    res += 1;
                }
                if (CheckHorizontalUp(data, i - 1, j, height)) { res += 1; }
                if (CheckVerticalRight(data, i, j + 1, len)) { res += 1; }
                if (CheckVerticalLeft(data, i, j - 1, len)) { res += 1; }
                if (CheckDiagonalDownRight(data, i + 1, j + 1, height, len)) { res += 1; }
                if (CheckDiagonalDownLeft(data, i + 1, j - 1, height, len)) { res += 1; }
                if (CheckDiagonalUpRight(data, i - 1, j + 1, height, len)) { res += 1; }
                if (CheckDiagonalUpLeft(data, i - 1, j - 1, height, len))
                {
                    res += 1;
                }
            }
        }
    }
    Console.WriteLine(res);
}
bool CheckDiagonalLeft(List<List<string>> data, int i, int j, int height, int len)
{
    var needs = new List<string> { "M", "S" };
    var currentNeeds = 0;
    while (i < height && i >= 0 && len > j && j >= 0)
    {
        if (needs.Contains(data[i][j]))
        {
            currentNeeds += 1;
            needs.Remove(data[i][j]);
        }
        else
        {
            return false;
        }
        if (currentNeeds == 2)
        {
            return true;
        }
        i += 2;
        j += 2;
    }
    return false;
}
bool CheckDiagonalRight(List<List<string>> data, int i, int j, int height, int len)
{
    var needs = new List<string> { "M", "S" };
    var currentNeeds = 0;
    while (i < height && i >= 0 && len > j && j >= 0)
    {
        if (needs.Contains(data[i][j]))
        {
            currentNeeds += 1;
            needs.Remove(data[i][j]);
        }
        else
        {
            return false;
        }
        if (currentNeeds == 2)
        {
            return true;
        }
        i += 2;
        j -= 2;
    }
    return false;
}
void Solve2(List<List<string>> data) { 
var len = data[0].Count - 1;
var height = data.Count;
var res = 0;
for (int i = 0; i < height; i++)
{
    for (int j = 0; j < len; j++)
    {
        if (data[i][j].Equals("A"))
        {
          if (CheckDiagonalLeft(data, i - 1, j - 1, height, len) && CheckDiagonalRight(data,i-1,j+1,height,len)) { res += 1; }
        }
    }
}
Console.WriteLine(res);
}
void Main(){
    var data = GetInput();
    Solve1(data);
    Solve2(data);

}
Main();