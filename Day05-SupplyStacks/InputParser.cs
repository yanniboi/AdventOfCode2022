using Utility;

namespace SupplyStacks;

public class InputParser
{
    private readonly string _inputFile;

    public InputParser (string input)
    {
        _inputFile = input;
    }

    public List<CraneInstructions> GetContent()
    {

        List<CraneInstructions> output = new List<CraneInstructions>();
        using (StreamReader file = new StreamReader(_inputFile))
        {

            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                output.Add(new CraneInstructions(ln));
            }
            file.Close();
        }


        return output;
    }

}
