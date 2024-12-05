static (List<List<int>> pipeSeparated, List<List<int>> commaSeparated) GetInput()
{
    var pipeSeparated = new List<List<int>>();
    var commaSeparated = new List<List<int>>();

    string input = File.ReadAllText("C:\\Users\\dkmak\\Desktop\\aoc2024\\day05\\input.txt");

    string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

    foreach (var line in lines)
    {
        if (line.Contains('|'))
        {
            var parts = line.Split('|');
            var numbers = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
            }
            pipeSeparated.Add(numbers);
        }
        else if (line.Contains(','))
        {
            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int number)) 
                {
                    numbers.Add(number);
                }
            }
            commaSeparated.Add(numbers);
        }
    }

    return (pipeSeparated, commaSeparated);
}
static bool CheckUpdateOrder(List<List<int>> orders, List<int> update)
{
    foreach (var order in orders)
    {
        var first = order[0];
        var second = order[1];
        var firstOccured = false;
        foreach (var item in update)
        {
            if (item == first)
            {
                firstOccured = true;
            }
            if (item == second && !firstOccured && update.Contains(first))
            {
                return false;
            }
        }
    }
    return true;
}
static List<int> FixUpdate(List<List<int>> orders, List<int> update)
{
    foreach (var order in orders)
    {
        var first = order[0];
        var second = order[1];
        var firstOccured = false;
        var res = new List<int>();
        var toSwap = new List<(int, int)>();
        foreach (var item in update)
        {
            if (item == first)
            {
                firstOccured = true;
            }
            if (item == second && !firstOccured && update.Contains(first))
            {
                var firstIndex = update.IndexOf(first);
                var secondIndex = update.IndexOf(second);
                var temp = update[firstIndex];
                update[firstIndex] = update[secondIndex];
                update[secondIndex] = temp;
                return update;

            }
        }
    }
    return update;
}
static List<List<int>> Solve1(List<List<int>> orders, List<List<int>> updates)
{
    var res = 0;
    var incorrectUpdates = new List<List<int>>();
    foreach (var update in updates)
    {
        if(CheckUpdateOrder(orders, update))
        {
            res += update[update.Count/2];
        }
        else
        {
            incorrectUpdates.Add(update);
        }
    }
    Console.WriteLine(res);
    return incorrectUpdates;

}
static void Solve2(List<List<int>> orders, List<List<int>> updates)
{
    var res = 0;
    foreach (var update in updates)
    {
        var toFix = new List<int>();
        foreach (var u in update)
        {
            toFix.Add(u);
        }
        while (!CheckUpdateOrder(orders, toFix))
        {
            toFix = FixUpdate(orders, update);
        }
        res += update[update.Count / 2];
            
        
    }
    Console.WriteLine(res);

}
void Main()
{
    var (orders,updates) = GetInput();
    var inccorectUpdates = Solve1(orders,updates);
    Solve2(orders, inccorectUpdates);

}
Main();