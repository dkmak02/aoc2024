static int GetInputSolve1(List<int> line)
{
    int validLinesCount = 0;

    try
    {

        bool isValid = true; 
        int prevValue = line[0];
        bool isAscending = prevValue -  line[1] < 0; 

        for (int i = 1; i < line.Count; i++)
        {
            int currentValue = line[i];

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
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    return validLinesCount;
}

void Main(){
    var res = 0;
    using (StreamReader file = new StreamReader("data.txt")){
            while (!file.EndOfStream)
            {
                var line = file.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line == null || line.Length < 2)
                {
                    continue;
                }
                List<int> l = new List<int>();
                foreach (var item in line)
                {
                    l.Add(int.Parse(item));
                }
                res += GetInputSolve1(l);
            }
    }
    System.Console.WriteLine(res);
    res = 0;
    using (StreamReader file = new StreamReader("data.txt")){
            while (!file.EndOfStream)
            {
                var curRes = 0;
                var line = file.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line == null || line.Length < 2)
                {
                    continue;
                }
                List<int> l = new List<int>();
                foreach (var item in line)
                {
                    l.Add(int.Parse(item));
                }
                curRes += GetInputSolve1(l);
                for (int i = 0; i < l.Count; i++)
                {
                    var temp = new List<int>(l);
                    temp.RemoveAt(i);
                    curRes += GetInputSolve1(temp);
                }
                if(curRes >0){
                    res++;
                }
                
            }
    }
    System.Console.WriteLine(res);
}
Main();