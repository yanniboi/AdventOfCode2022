using Utility;

namespace CampCleanup;

public class InputParser
{
    private readonly string _inputFile;

    public InputParser (string input)
    {
        _inputFile = input;
    }

    public List<CampSearch> GetContent()
    {

        List<CampSearch> output = new List<CampSearch>();
        using (StreamReader file = new StreamReader(_inputFile))
        {

            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                output.Add(new CampSearch(ln));
            }
            file.Close();
        }


        return output;
    }

}
