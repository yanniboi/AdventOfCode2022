using CalorieCounting;

List<int> ElfTotals = new List<int>();

string textFile = Path.Combine(Environment.CurrentDirectory, "../../../input.txt");
InputParser parser = new InputParser(textFile);
List<string> content = parser.GetContent();

int counter = 0;

foreach (string line in content)
{
    if (line.Length == 0)
    {
        ElfTotals.Add(counter);
        Console.WriteLine(counter);
        counter = 0;
    }

    int calories;
    if (Int32.TryParse(line, out calories))
    {
        counter += calories;
    }
}


Console.WriteLine($"File has {ElfTotals.Count} elves.");

int max = ElfTotals.Max();
Console.WriteLine($"Max calories = {max}");

int totalTopThree = 0;
for (int i = 0; i < 3; i++)
{
    max = ElfTotals.Max();
    totalTopThree += max;
    Console.WriteLine($"Total Max calories {i + 1} = {max}");
    ElfTotals.Remove(max);
}

Console.WriteLine($"Max calories = {totalTopThree}");
