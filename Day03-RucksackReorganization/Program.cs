using Utility;
using InputParser = RucksackReorganization.InputParser;

bool _debug = false;
bool _round1 = false;

string textFile = Path.Combine(Environment.CurrentDirectory, "../../../input.txt");

if (_debug)
{
    textFile = Path.Combine(Environment.CurrentDirectory, "../../../debug.txt");

}

InputParser parser = new InputParser(textFile);
var content = parser.GetContent();

int totalScore = 0;

int groupIndex = 0;
List<Char[]> groupRucksacks = new List<Char[]>();

foreach (var data in content)
{
    int score = 0;
    if (_round1)
    {
        score += data.GetPriority();
        // log data.
        // Console.WriteLine(data.GetIntersection().ToString());
        // Console.WriteLine(data.GetPriority());
        // data.Intersection;
    }
    else
    {
        if (groupIndex == 3)
        {
            groupIndex = 0;
            Char[] badges = groupRucksacks[0].Intersect(groupRucksacks[1]).Intersect(groupRucksacks[2]).ToArray();
            Char badge = badges[0];
            Console.WriteLine(badge);
            groupRucksacks.Clear();
            score += Rucksack.GetPriority(badge);
        }

        groupRucksacks.Add(data.GetTotal());
        groupIndex++;
    }

    totalScore += score;
}

if (!_round1)
{
    // Add one final group.
    Char[] badges = groupRucksacks[0].Intersect(groupRucksacks[1]).Intersect(groupRucksacks[2]).ToArray();
    Char badge = badges[0];
    Console.WriteLine(badge);
    totalScore += Rucksack.GetPriority(badge);
}


Console.WriteLine(totalScore);
