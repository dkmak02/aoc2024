using System.Numerics;
using System.Text;

static (List<int>, List<int>) GetInput()
{
    var freeSpace = new List<int>();
    var files = new List<int>();
    var input = File.ReadAllText("C:\\Users\\dkmak\\Desktop\\aoc2024\\day09\\input.txt");
    bool isFile = true;
    foreach (var line in input.Split("\n", StringSplitOptions.RemoveEmptyEntries))
    {
        var trimmedLine = line.Trim();
        foreach (var c in trimmedLine)
        {
            if (isFile)
            {
                files.Add(int.Parse(c.ToString()));
            }
            else
            {

                freeSpace.Add(int.Parse(c.ToString()));
            }
            isFile = !isFile;
        }

    }
    return (files,freeSpace);

}
void Solve1(List<int> files, List<int> freeSpace)
{
    BigInteger res = 0;
    var finalBuilder = new List<string>();
    for (int i = 0; i < files.Count; i++)
    {
        for(int j =0; j < files[i]; j++)
        {
            finalBuilder.Add(i.ToString());
        }
        if (i < freeSpace.Count)
        {
            for (int j = 0; j < freeSpace[i]; j++)
            {
                finalBuilder.Add(".");
            }
        }
    }

    int startIndex = 0;
    int endIndex = finalBuilder.Count;

    while (startIndex < endIndex)
    {
        while (startIndex < endIndex && finalBuilder[startIndex] != ".")
        {
            startIndex++;
        }
        if (startIndex >= endIndex)
        {
            break;
        }
        while (endIndex > startIndex && finalBuilder[endIndex - 1] == ".")
        {
            endIndex--;
        }
        if (startIndex < endIndex)
        {
            finalBuilder[startIndex] = finalBuilder[endIndex - 1];
            finalBuilder[endIndex - 1] = ".";
            startIndex++;
            endIndex--;
        }
    }

    for (int i = 0; i < finalBuilder.Count; i++)
    {
        if (finalBuilder[i] != ".")
        {

            var temp = BigInteger.Parse(finalBuilder[i].ToString()) * i;
            res += temp;

        }
    }

    Console.WriteLine(res);
}
void Solve2(List<int> files, List<int> freeSpace)
{
    BigInteger res = 0;
    var finalBuilder = new List<string>();
    for (int i = 0; i < files.Count; i++)
    {
        for (int j = 0; j < files[i]; j++)
        {
            finalBuilder.Add(i.ToString());
        }
        if (i < freeSpace.Count)
        {
            for (int j = 0; j < freeSpace[i]; j++)
            {
                finalBuilder.Add(".");
            }
        }
    }

    
    int endIndex = finalBuilder.Count-1;
    int endStartIndex = 0;
    
    var temp = "s";
    var trueS = 0;
    while (0 < endIndex)
    {
        int startIndex = 0;
        var needsSpace = 0;
        int startEndIndex = finalBuilder.Count;
        while (endIndex > startIndex && finalBuilder[endIndex] == ".")
        {
            endIndex--;
        }
        if(endIndex <= 0)
        {
            break;
        }
        endStartIndex = endIndex;
        temp = finalBuilder[endIndex];
        while (finalBuilder[endStartIndex] == temp)
        {
            endStartIndex--;
            if(endStartIndex < 0)
            {
                break;
            }
            
        }
        if (endStartIndex < 0)
        {
            break;
        }
        var xd = finalBuilder.Slice(endStartIndex+1, endIndex - endStartIndex);

        while (startIndex < endIndex && finalBuilder[startIndex] != ".")
        {
            startIndex++;
        }
        startIndex--;
        startEndIndex = startIndex;
        while (true)
        {
            if(startEndIndex-startIndex == endIndex - endStartIndex)
            {
                for (int i = 0; i < endIndex - endStartIndex; i++)
                {
                    finalBuilder[startIndex+1 + i] = finalBuilder[endStartIndex + 1 + i];
                    finalBuilder[endStartIndex+1+ i] = ".";
                }
                startIndex = 0;
                endIndex = endStartIndex;
                trueS = startIndex;
                break;
            }
            startEndIndex++;
            if(startEndIndex >= endStartIndex)
            {
                endIndex = endStartIndex;
                break;
            }
            if(finalBuilder[startEndIndex] != ".")
            {
                startIndex = startEndIndex;
            }
        }
    }

    for (int i = 0; i < finalBuilder.Count; i++)
    {
        if (finalBuilder[i] != ".")
        {

            var temp1 = BigInteger.Parse(finalBuilder[i].ToString()) * i;
            res += temp1;

        }
    }

    Console.WriteLine(res);
}
void Main()
{
    var (files,freeSpace) = GetInput();
    //Solve1(files, freeSpace);
    Solve2(files, freeSpace);
}
Main();