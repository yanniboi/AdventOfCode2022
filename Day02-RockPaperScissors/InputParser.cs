using Utility;

namespace RockPaperScissors;

public class InputParser
{
    private readonly string _inputFile;

    public InputParser (string input)
    {
        _inputFile = input;
    }

    public List<GameData> GetContent()
    {

        List<GameData> output = new List<GameData>();
        using (StreamReader file = new StreamReader(_inputFile))
        {

            string line;

            while ((line = file.ReadLine()) != null)
            {
                output.Add(new GameData(line));
            }
            file.Close();
        }


        return output;
    }

}
