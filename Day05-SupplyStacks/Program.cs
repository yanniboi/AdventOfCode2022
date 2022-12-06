// bool _debug = true;

using SupplyStacks;
using Utility;

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

Stacks stacks = new Stacks();

if (_debug)
{
    stacks.StackList.Add(new Stack(""));
    stacks.StackList.Add(new Stack("N,Z"));
    stacks.StackList.Add(new Stack("D,C,M"));
    stacks.StackList.Add(new Stack("P"));
}
else
{
    stacks.StackList.Add(new Stack(""));
    stacks.StackList.Add(new Stack("J,F,C,N,D,B,W"));
    stacks.StackList.Add(new Stack("T,S,L,Q,V,Z,P"));
    stacks.StackList.Add(new Stack("T,J,G,B,Z,P"));
    stacks.StackList.Add(new Stack("C,H,B,Z,J,L,T,D"));
    stacks.StackList.Add(new Stack("S,J,B,V,G"));
    stacks.StackList.Add(new Stack("Q,S,P"));
    stacks.StackList.Add(new Stack("N,P,M,L,F,D,V,B"));
    stacks.StackList.Add(new Stack("R,L,D,B,F,M,S,P"));
    stacks.StackList.Add(new Stack("R,T,D,V"));
}


foreach (var data in content)
{
    int score = 0;
    if (_round1)
    {

        Console.WriteLine(data.GetRaw());

        stacks.MoveCrates(data);
        stacks.Debug(_debug);

    }
    else
    {
        Console.WriteLine(data.GetRaw());

        stacks.MoveMultipleCrates(data);
        stacks.Debug(_debug);
    }

    totalScore += score;
}




Console.WriteLine(totalScore);
