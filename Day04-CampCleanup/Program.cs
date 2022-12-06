using InputParser = CampCleanup.InputParser;

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

foreach (var data in content)
{
    int score = 0;
    if (_round1)
    {
        if (data.IsOverlap())
        {
            score = 1;
            Console.WriteLine(data.getRaw());
            // Console.WriteLine(string.Join(',', data.GetZoneOne()));
            // Console.WriteLine(string.Join(',', data.GetZoneTwo()));
            // Console.WriteLine(string.Join(',', data.GetIntersection()));
            // Console.WriteLine(string.Join(',', data.GetUnion()));
        }

    }
    else
    {
        if (data.GetIntersection().Count > 0)
        {
            score = 1;
            // Console.WriteLine(data.getRaw());
        }
    }

    totalScore += score;
}


Console.WriteLine(totalScore);
