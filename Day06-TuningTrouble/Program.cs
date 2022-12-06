using TuningTrouble;

// bool _debug = true;
bool _debug = false;
// bool _round1 = true;
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
        score = data.GetStartMarker();
        Console.WriteLine(score);

    }
    else
    {
        score = data.GetStartMessage();
        Console.WriteLine(score);
    }

    totalScore += score;
}


Console.WriteLine(totalScore);
