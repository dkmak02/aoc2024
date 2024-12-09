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
    File.WriteAllText("C:\\Users\\dkmak\\Desktop\\aoc2024\\day09\\output2.txt", string.Join("", finalBuilder));

    for (int fileId = files.Count - 1; fileId >= 0; fileId--)
    {
        var fileStr = fileId.ToString();
        var fileIndices = new List<int>();

        for (int i = 0; i < finalBuilder.Count; i++)
        {
            if (finalBuilder[i] == fileStr)
            {
                fileIndices.Add(i);
            }
        }

        if (fileIndices.Count == 0) continue; 

        int fileLength = fileIndices.Count;
        int firstIndex = fileIndices[0];

        for (int i = 0; i <= firstIndex; i++)
        {
            bool hasEnoughSpace = true;
            for (int j = i; j < i + fileLength; j++)
            {
                if (j >= finalBuilder.Count || finalBuilder[j] != ".")
                {
                    hasEnoughSpace = false;
                    break;
                }
            }

            if (hasEnoughSpace)
            {
                foreach (var index in fileIndices)
                {
                    finalBuilder[index] = ".";
                }
                for (int j = 0; j < fileLength; j++)
                {
                    finalBuilder[i + j] = fileStr;
                }

                break; 
            }
        }
        //output finalBuilder
       // Console.WriteLine(string.Join("", finalBuilder));

    }

    for (int i = 0; i < finalBuilder.Count; i++)
    {
        if (finalBuilder[i] != ".")
        {
            var value = BigInteger.Parse(finalBuilder[i]);
            res += value * i;
        }
    }

    Console.WriteLine(res);
}
void Main()
{
    var (files,freeSpace) = GetInput();
    Solve1(files, freeSpace);
    Solve2(files, freeSpace);
}
Main();