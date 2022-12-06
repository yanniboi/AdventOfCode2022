namespace Utility;

public class Rucksack
{
    private Char[] _total;
    private Char[] _compartmentOne, _compartmentTwo;
    private Char _intersection;

    public Rucksack(string row)
    {
        int length = row.Length;
        _total = row.ToCharArray();
        _compartmentOne = row.Substring(0, length / 2).ToCharArray();
        _compartmentTwo = row.Substring(length / 2).ToCharArray();
        Char[] intersection = _compartmentOne.Intersect(_compartmentTwo).ToArray();
        _intersection = intersection.Length > 0 ? intersection[0] : ' ';
    }

    public Char[] GetTotal()
    {
        return _total;
    }

    public Char GetIntersection()
    {
        return _intersection;
    }

    public int GetPriority()
    {
        int index = char.ToUpper(_intersection) - 64;
        if (Char.IsUpper(_intersection))
        {
            return (int) index + 26;
        }

        return index;
    }

    public static int GetPriority(char badge)
    {
        int index = char.ToUpper(badge) - 64;
        if (Char.IsUpper(badge))
        {
            return (int) index + 26;
        }

        return index;
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

public class CampSearch
{
    private string _row;
    private CampZone _zoneOne, _zoneTwo;

    public CampSearch(string row)
    {
        _row = row;
        string[] zones = row.Split(',');
        _zoneOne = new CampZone(zones[0]);
        _zoneTwo = new CampZone(zones[1]);
    }

    public bool IsOverlap()
    {
        int small, large;
        if (_zoneOne.GetZones().Count < _zoneTwo.GetZones().Count)
        {
            small = _zoneOne.GetZones().Count;
            large = _zoneTwo.GetZones().Count;
        }
        else
        {
            small = _zoneTwo.GetZones().Count;
            large = _zoneOne.GetZones().Count;
        }

        List<int> union = GetUnion();
        List<int> intersect = GetIntersection();

        if (union.Count == large && intersect.Count == small)
        {
            return true;
        }
        return false;
    }

    public List<int> GetZoneOne()
    {
        return _zoneOne.GetZones().ToList();
    }

    public List<int> GetZoneTwo()
    {
        return _zoneTwo.GetZones().ToList();
    }


    public List<int> GetUnion()
    {
        return _zoneOne.GetZones().Union(_zoneTwo.GetZones()).ToList();
    }

    public List<int> GetIntersection()
    {
        return _zoneOne.GetZones().Intersect(_zoneTwo.GetZones()).ToList();
    }

    public string getRaw()
    {
        return _row;
    }
}

public class CampZone
{
    private List<int> _zones = new List<int>();

    public CampZone(string zones)
    {
        string[] data = zones.Split('-');

        Int32.TryParse(data[0], out int start);
        Int32.TryParse(data[1], out int end);

        for (int i = start; i <= end; i++)
        {
            _zones.Add(i);
        }

    }

    public List<int> GetZones()
    {
        return _zones;
    }

    public void Union(CampZone zoneTwo)
    {
        throw new NotImplementedException();
    }
}

public class CommsBuffer
{
    private string _buffer;

    public CommsBuffer(string ln)
    {
        _buffer = ln;
    }

    public int GetStartMarker()
    {
        Queue<char> tracker = new Queue<char>();
        int startCount = 0;
        for (int i = 0; i < _buffer.Length; i++)
        {
            while (tracker.ToList().Contains(_buffer[i]))
            {
                tracker.Dequeue();
            }

            tracker.Enqueue(_buffer[i]);

            // Console.WriteLine(string.Join("", tracker.ToList()));
            if (tracker.Count == 4)
            {
                return i + 1;
            }
        }

        return startCount;
    }

    public int GetStartMessage()
    {
        Queue<char> tracker = new Queue<char>();
        int startCount = 0;
        for (int i = 0; i < _buffer.Length; i++)
        {
            while (tracker.ToList().Contains(_buffer[i]))
            {
                tracker.Dequeue();
            }

            tracker.Enqueue(_buffer[i]);

            // Console.WriteLine(string.Join("", tracker.ToList()));
            if (tracker.Count == 14)
            {
                return i + 1;
            }
        }

        return startCount;
    }
}

public class CraneInstructions
{
    private string _raw;

    public int Quantity;
    public int Origin;
    public int Destination;

    public CraneInstructions(string instructions)
    {
        _raw = instructions;

        string[] components = instructions.Split(" ");

        Int32.TryParse(components[1], out Quantity);
        Int32.TryParse(components[3], out Origin);
        Int32.TryParse(components[5], out Destination);
    }

    public string GetRaw()
    {
        return _raw;
    }
}

public class Stacks
{
    public List<Stack> StackList = new List<Stack>();

    public void MoveCrates(CraneInstructions data)
    {
        for (int i = 0; i < data.Quantity; i++)
        {
            string box = StackList[data.Origin].Boxes[0];
            StackList[data.Origin].Boxes.RemoveAt(0);
            StackList[data.Destination].Boxes = StackList[data.Destination].Boxes.Prepend(box).ToList();
        }
    }

    public void MoveMultipleCrates(CraneInstructions data)
    {

        List<string> movingBoxes = new List<string>();
        for (int i = 0; i < data.Quantity; i++)
        {
            movingBoxes.Add(StackList[data.Origin].Boxes[0]);
            StackList[data.Origin].Boxes.RemoveAt(0);
        }
        StackList[data.Destination].Boxes = movingBoxes.Concat(StackList[data.Destination].Boxes.ToList()).ToList();
    }

    public void Debug(bool debug)
    {
        Console.WriteLine(string.Join(",", StackList[1].Boxes));
        Console.WriteLine(string.Join(",", StackList[2].Boxes));
        Console.WriteLine(string.Join(",", StackList[3].Boxes));

        if (!debug)
        {
            Console.WriteLine(string.Join(",", StackList[4].Boxes));
            Console.WriteLine(string.Join(",", StackList[5].Boxes));
            Console.WriteLine(string.Join(",", StackList[6].Boxes));
            Console.WriteLine(string.Join(",", StackList[7].Boxes));
            Console.WriteLine(string.Join(",", StackList[8].Boxes));
            Console.WriteLine(string.Join(",", StackList[9].Boxes));

        }
    }
}

public class Stack
{
    public List<string> Boxes;

    public Stack(string crates)
    {
        Boxes = crates.Split(",").ToList();
    }
}
