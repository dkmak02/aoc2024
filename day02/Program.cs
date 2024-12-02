// List<List<int>> GetInput(){
//     var data = new List<List<int>>();
//     StreamReader file = new StreamReader("data.txt");
//     var line = file.ReadLine();
//     foreach(var value in line.Split(' ')){
//         var newList = new List<int>(int.Parse(value));
//         data.Add()
//     }
//     return data;
// }

static int GetInputSolve1()
{
    int validLinesCount = 0;

    try
    {
        using (StreamReader file = new StreamReader("data.txt"))
        {
            while (!file.EndOfStream)
            {
                var line = file.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line == null || line.Length < 2)
                {
                    continue;
                }

                bool isValid = true; 
                int prevValue = int.Parse(line[0]);
                bool isAscending = prevValue -  int.Parse(line[1]) < 0; 

                for (int i = 1; i < line.Length; i++)
                {
                    int currentValue = int.Parse(line[i]);

                    if (Math.Abs(prevValue - currentValue) >= 4)
                    {
                        isValid = false;
                        break;
                    }
                    if (prevValue < currentValue)
                    {
                        if (isAscending == false) 
                        {
                            isValid = false;
                            break;
                        }
                        isAscending = true;
                    }
                    else if (prevValue > currentValue)
                    {

                        if (isAscending == true) 
                        {
                            isValid = false;
                            break;
                        }
                        isAscending = false;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }

                    prevValue = currentValue; 
                }

                if (isValid)
                {
                    validLinesCount++;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    return validLinesCount;
}
static int GetInputSolve2()
{
    int validLinesCount = 0;

    try
    {
        using (StreamReader file = new StreamReader("data.txt"))
        {
            while (!file.EndOfStream)
            {
                var line = file.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line == null || line.Length < 2)
                {
                    continue; // Skip invalid or empty lines
                }

                bool deleted = false; // Flag to allow one "fix"
                bool isValid = true;  // Assume the line is valid unless proven otherwise
                int prevValue = int.Parse(line[0]);
                bool? isAscending = null; // Null indicates no trend determined yet

                for (int i = 1; i < line.Length; i++)
                {
                    int currentValue = int.Parse(line[i]);
                    // Handle large differences
                    if (Math.Abs(prevValue - currentValue) >= 4)
                    {
                        if (!deleted)
                        {
                            deleted = true; // Use the one allowed "fix"
                            continue;
                        }
                        isValid = false;
                        break;
                    }

                    // Determine or validate the trend
                    if (currentValue > prevValue)
                    {
                        // Ascending
                        if (isAscending == false) // If previously descending
                        {
                            if (!deleted)
                            {
                                deleted = true; // Fix the trend inconsistency
                                continue;
                            }
                            isValid = false;
                            break;
                        }
                        isAscending = true;
                    }
                    else if (currentValue < prevValue)
                    {
                        // Descending
                        if (isAscending == true) // If previously ascending
                        {
                            if (!deleted)
                            {
                                deleted = true; // Fix the trend inconsistency
                                continue;
                            }
                            isValid = false;
                            break;
                        }
                        isAscending = false;
                    }
                    else
                    {
                        if (!deleted)
                        {
                            deleted = true; 
                            continue;
                        }
                        isValid = false;
                        break;
                    }

                    prevValue = currentValue; // Update previous value
                }

                if (isValid)
                {
                    validLinesCount++;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    return validLinesCount;
}


void Main(){
    // var res = GetInputSolve1();
    // System.Console.WriteLine(res);
    var res = GetInputSolve2();
    System.Console.WriteLine(res);

}
Main();