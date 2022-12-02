using RockPaperScissors;

bool _debug = false;
bool _round1 = false;

string textFile = Path.Combine(Environment.CurrentDirectory, "../../../input.txt");

if (_debug)
{
    textFile = Path.Combine(Environment.CurrentDirectory, "../../../debug.txt");

}

InputParser parser = new InputParser(textFile);
List<GameData> content = parser.GetContent();

int totalScore = 0;
foreach (GameData data in content)
{
    int score = 0;
    // Console.WriteLine(data.Player1);
    if (_round1)
    {
        score = data.GetScore(data.Unknown);
    }
    else
    {
        score = data.GetScore(data.Player2);
    }

    Console.WriteLine(data.Player2 + " " + score);
    totalScore += score;
}

Console.WriteLine(totalScore);
