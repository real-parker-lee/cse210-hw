public class GoalTracker
{
  private List<BaseGoal> _goals = new List<BaseGoal>();
  private int _totalPoints = 0;
  private string _currentPath = "EternalQuest.save";
  private bool _shouldExit = false;
  
  public List<BaseGoal> GetGoals()
  {
    return _goals;
  }
  
  public void SetShouldExit(bool x)
  {
    _shouldExit = x;
  }
  
  public bool ShouldExit()
  {
    return _shouldExit;
  }
  
  public string GetCurrentPath()
  {
    return _currentPath;
  }
  
  public void SetCurrentPath(string p)
  {
    _currentPath = p;
  }
  
  public int GetPoints()
  {
    return _totalPoints;
  }
  
  public void SetPoints(int p)
  {
    _totalPoints = p;
  }
  
  public void AddGoal(BaseGoal b)
  {
    _goals.Add(b);
  }
  
  public void Deserialize()
  {
    string[] lines = File.ReadAllLines(GetCurrentPath());
    for (int i = 0; i < lines.Length; i++)
    {
      // Console.WriteLine($"{i}");
      string[] data = lines[i].Split("|");
      if (i == 0)
      {
        SetPoints(int.Parse(data[0]));
      }
      else
      {
        switch (data[0])
        {
          case "ETERNAL":
            AddGoal(new EternalGoal(data[1], int.Parse(data[2]), int.Parse(data[3])));
            break;
          case "CHECK":
            AddGoal(new ChecklistGoal(data[1], int.Parse(data[2]), int.Parse(data[6]), int.Parse(data[5]), int.Parse(data[4]), bool.Parse(data[3])));
            break;
          case "ONETIME":
            AddGoal(new OneTimeGoal(data[1], int.Parse(data[2]), bool.Parse(data[3])));
            break;
          default:
            Console.WriteLine($"Malformed Data: \"{lines[i]}\"");
            break;
        }
      }
    }
  }
  
  public BaseGoal SelectGoal(int idx)
  {
    return GetGoals()[idx];
  }
  
  public void SerializeAll(string path) // use custom path
  {
    // first line always has number of points accrued.
    string data = $"{GetPoints()}\n";
    
    foreach (BaseGoal g in _goals)
    {
      data = data + g.Serialize() + "\n";
    }
    File.WriteAllText(path, data);
  }
  
  public void SerializeAll() // use current path
  {
    // first line always has number of points accrued.
    string data = $"{GetPoints()}\n";
    
    foreach (BaseGoal g in _goals)
    {
      data = data + g.Serialize() + "\n";
    }
    File.WriteAllText(GetCurrentPath(), data);
  }
  
  public void ShowAll()
  {
    for (int i = 0; i < GetGoals().Count(); i++)
    {
      Console.WriteLine($"{i+1}. {GetGoals()[i].Show()}");
    }
  }
  
  // main loop for handling user input and commands.
  public void ReplStep()
  {
    Console.WriteLine("Input a command, or type \"help\" for a list of commands.");
    Console.Write("> ");
    string cmd = Console.ReadLine();
    string[] args = cmd.Split(" ");
    switch (args[0])
    {
      case "help":
        Console.WriteLine("-----COMMAND-----   ------------DESCRIPTION------------");
        Console.WriteLine("");
        Console.WriteLine("load [path]         Load data from file at given path.");
        Console.WriteLine("save [?path]        Save data to file at given path.");
        Console.WriteLine("                      If a path is not specified, will");
        Console.WriteLine("                      instead overwrite the most");
        Console.WriteLine("                      recently loaded file.");
        Console.WriteLine("list                List all goals");
        Console.WriteLine("check-off [index]   Record completon of the goal at");
        Console.WriteLine("                      the given index.");
        Console.WriteLine("points              Display your current point score");
        Console.WriteLine("new-eternal         Create a new Eternal goal");
        Console.WriteLine("new-checklist       Create a new checklist goal");
        Console.WriteLine("new one-time        Create a new one-time goal");
        Console.WriteLine("quit                Exit the application.");
        Console.WriteLine("help                Show this help message.");
        break;
      case "save":
        if (args.Count() == 1 && GetCurrentPath() == "")
        {
          Console.Write("New file path: ");
          SetCurrentPath(Console.ReadLine());
        }
        else if (args.Length == 2)
        {
          SetCurrentPath(args[1]);
        }
        SerializeAll();
        break;
      case "load":
        Console.Write("Load from Path: ");
        if (args.Length == 1 && GetCurrentPath() == "")
        {
          Console.Write("Choose a path: ");
          SetCurrentPath(Console.ReadLine());
        }
        else if (args.Length == 2)
        {
          SetCurrentPath(args[1]);
        }
        Deserialize();
        Console.WriteLine($"Loaded {GetGoals().Count()} goals from {GetCurrentPath()}\n");
        break;
      case "list":
        ShowAll();
        break;
      case "check-off":
        int idx = 0;
        if (args.Length < 2)
        {
          // prompt for index
          Console.Write("Select a goal by index: ");
          idx = int.Parse(Console.ReadLine()) - 1;
        }
        else
        {
          idx = int.Parse(args[1]) - 1;
        }
        
        BaseGoal g = SelectGoal(idx);
        int deltapts = g.CheckOff();
        SetPoints(GetPoints() + deltapts);
        break;
      case "points":
        Console.WriteLine($"You have {GetPoints()} points.");
        break;
      case "new-eternal":
        break;
      case "new-checklist":
        break;
      case "new-onetime":
        break;
      case "quit":
        SetShouldExit(true);
        break;
      default:
        Console.WriteLine($"Invalid Command: \"{cmd}\"");
        break;
    }
  }
  
  public void RunRepl()
  {
    do
    {
      ReplStep();
    } while (!ShouldExit());
  }
}
