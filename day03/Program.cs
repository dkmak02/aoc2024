using System.Text.RegularExpressions;
string GetInput(){
    using (StreamReader file = new StreamReader("data.txt")){
        return file.ReadToEnd();
    }
}
void Solve1(string data){
    var regex = new Regex(@"mul\((\d+),(\d+)\)");
    var matches = regex.Matches(data);
    var res = 0;
    foreach (Match match in matches)
    {
        var x = int.Parse(match.Groups[1].Value);
        var y = int.Parse(match.Groups[2].Value);
        res += x * y;
    }
    System.Console.WriteLine(res);

}
void Solve2(string data){
    
    var regex = new Regex(@"(mul\((\d+),(\d+)\)|don't()|do())");
    var matches = regex.Matches(data);
    var res = 0;
    var multiple = true;
    foreach (Match match in matches)
    {
        if(match.Value == "don't"){
            multiple = false;
        }
        else if (match.Value == "do"){
            multiple = true;
        }
        else{
            if(multiple){
                var values = match.Value.Split('(')[1];
                values = values.Remove(values.Length - 1);
                var x = int.Parse(values.Split(',')[0]);
                var y = int.Parse(values.Split(',')[1]);
                res += x * y;
            }
        }
        
    }
    System.Console.WriteLine(res);

}
void Main(){
    var data = GetInput();
    //Solve1(data);
    Solve2(data);
}
Main();