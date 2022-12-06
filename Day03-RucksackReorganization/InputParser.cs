using Utility;

namespace RucksackReorganization;

public class InputParser
{
    private readonly string _inputFile;

    public InputParser (string input)
    {
        _inputFile = input;
    }

    public List<Rucksack> GetContent()
    {

        List<Rucksack> output = new List<Rucksack>();


        using (StreamReader file = new StreamReader(_inputFile))
        {

            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                Rucksack rucksack = new Rucksack(ln);
                    output.Add(rucksack);
            }
            file.Close();
        }


        return output;
    }

}
