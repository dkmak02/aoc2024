(List<int>, List<int>) ReadInput(){
        List<int> x = new List<int>();
        List<int> y = new List<int>();
        string line;
        StreamReader file = new StreamReader("data.txt");
        while ((line = file.ReadLine()) != null)
        {
            string[] parts = line.Split("   ");
            x.Add(int.Parse(parts[0]));
            y.Add(int.Parse(parts[1]));
        }
        return (x, y);
}
int GetOutput(List<int> x, List<int> y){
        int result = 0;
        for (int i = 0; i < x.Count; i++)
        {
            result += Math.Abs(x[i] - y[i]);
        }
        return result;
}
void Solve1(){
        (List<int> x, List<int> y) = ReadInput();
        Console.WriteLine(GetOutput(x, y));
}
//Solve1();
int GetOutput2(List<int> x, List<int> y){
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (int i in y)
        {
            if (dict.ContainsKey(i))
            {
                dict[i]++;
            }
            else
            {
                dict[i] = 1;
            }
        }
        int result = 0;
        foreach(int i in x){
            if (dict.ContainsKey(i)){
                result += dict[i] * i;
            }
        }
        return result;
}
void Solve2(){
        (List<int> x, List<int> y) = ReadInput();
        Console.WriteLine(GetOutput2(x, y));
}
//Solve2();