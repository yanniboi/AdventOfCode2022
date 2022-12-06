using Utility;

namespace TuningTrouble;

public class InputParser
{
    private readonly string _inputFile;

    public InputParser (string input)
    {
        _inputFile = input;
    }

    public List<CommsBuffer> GetContent()
    {

        List<CommsBuffer> output = new List<CommsBuffer>();
        using (StreamReader file = new StreamReader(_inputFile))
        {

            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                output.Add(new CommsBuffer(ln));
            }
            file.Close();
        }


        return output;
    }

}
