namespace CalorieCounting;

public class InputParser
{
    private readonly string _inputFile;

    public InputParser (string input)
    {
        _inputFile = input;
    }

    public List<string> GetContent()
    {

        List<string> output = new List<string>();


        using (StreamReader file = new StreamReader(_inputFile))
        {

            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                output.Add(ln);
            }
            file.Close();
        }


        return output;
    }

}
