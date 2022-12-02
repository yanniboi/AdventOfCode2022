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

public class GameData
{
    public string Player1 { get; set; }
    public string Player2 { get; set; }
    public string Unknown { get; set; }

    public GameData(string gameData)
    {
        string[] data = gameData.Split(' ');

        Player1 = data[0];
        Unknown = data[1];

        switch (Unknown)
        {
            case "X":
                // Need to lose.
                Player2 = GetLosingMove(Player1);
                break;

            case "Y":
                // Need to draw.
                Player2 = GetDrawingMove(Player1);
                break;

            case "Z":
                // Need to win.
                Player2 = GetWinningMove(Player1);
                break;
        }
    }

    private string GetLosingMove(string player1)
    {
        string move = "";
        switch (player1)
        {
            case "A":
                move = "Z";
                break;
            case "B":
                move =  "X";
                break;
            case "C":
                move =  "Y";
                break;
        }

        return move;
    }

    private string GetWinningMove(string player1)
    {
        string move = "";
        switch (player1)
        {
            case "A":
                move = "Y";
                break;
            case "B":
                move =  "Z";
                break;
            case "C":
                move =  "X";
                break;
        }

        return move;
    }

    private string GetDrawingMove(string player1)
    {
        string move = "";
        switch (player1)
        {
            case "A":
                move = "X";
                break;
            case "B":
                move =  "Y";
                break;
            case "C":
                move =  "Z";
                break;
        }

        return move;
    }

    public int GetScore(string myMove)
    {
        int score = 0;

        switch (myMove)
        {
            case "X":
                score += 1;
                if (Player1 == "A")
                    score += 3;
                else if (Player1 == "C")
                    score += 6;
                break;
            case "Y":
                score += 2;
                if (Player1 == "B")
                    score += 3;
                else if (Player1 == "A")
                    score += 6;
                break;
            case "Z":
                score += 3;
                if (Player1 == "C")
                    score += 3;
                else if (Player1 == "B")
                    score += 6;
                break;
        }

        return score;
    }
}
