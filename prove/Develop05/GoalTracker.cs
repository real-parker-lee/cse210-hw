public class GoalTracker
{
  private List<BaseGoal> _goals = new List<BaseGoal>();
  private int _totalPoints = 0;
  private string _currentPath = "EternalQuest.save";
  private bool _shouldExit = false;
  private bool _fileErrorThrown = false;
  
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
    _fileErrorThrown = false;
    string[] lines;
    try
    {
      _fileErrorThrown = false;
      lines = File.ReadAllLines(GetCurrentPath());
    }
    catch (FileNotFoundException)
    {
      _fileErrorThrown = true;
      Console.WriteLine($"ERROR: File \"{GetCurrentPath()}\" does not exist.");
      return;
    }
    catch (PathTooLongException)
    {
      _fileErrorThrown = true;
      Console.WriteLine("ERROR: path is too long. Try changing the working directory of this program.");
      return;
    }
    catch (UnauthorizedAccessException)
    {
      _fileErrorThrown = true;
      Console.WriteLine("ERROR: Access to file denied.");
      return;
    }
    catch (Exception)
    {
      _fileErrorThrown = true;
      Console.WriteLine("ERROR: unknown error occurred. Exiting program.");
      SetShouldExit(true);
      return;
    }
    
    
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
    //Console.WriteLine("Input a command, or type \"help\" for a list of commands.");
    Console.Write("> ");
    string cmd = Console.ReadLine();
    string[] args = cmd.Split(" ");
    
    bool shouldAskAgain = false; // for input validation.
    
    switch (args[0])
    {
      case "help":
        Console.WriteLine("-----COMMAND-----   ------------DESCRIPTION------------");
        Console.WriteLine("load [path]         Load data from file at given path.");
        Console.WriteLine("save [?path]        Save data to file at given path.");
        Console.WriteLine("                      If a path is not specified, will");
        Console.WriteLine("                      instead overwrite the most");
        Console.WriteLine("                      recently loaded file.");
        Console.WriteLine("list                List all goals.");
        Console.WriteLine("check-off [index]   Record completon of the goal at");
        Console.WriteLine("                      the given index.");
        Console.WriteLine("points              Display your current point score.");
        Console.WriteLine("create              Create a new goal interactively.");
        Console.WriteLine("quit                Exit the application.");
        Console.WriteLine("clear               Clear the screen.");
        Console.WriteLine("help                Show this help message.");
        Console.WriteLine("about               Show the program description.");
        Console.WriteLine("");
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
        Console.WriteLine($"Saved {GetGoals().Count()} goals to file at \"{GetCurrentPath()}\"\n");
        break;
        
      case "load":
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
        if (_fileErrorThrown)
        {
          Console.WriteLine("No file loaded.\n");
        }
        else
        {
          Console.WriteLine($"Loaded {GetGoals().Count()} goals from file at \"{GetCurrentPath()}\"\n");
        }
        
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
        Console.WriteLine($"Checked off goal #{idx + 1}.\n");
        break;
        
      case "points":
        Console.WriteLine($"You have {GetPoints()} points.\n");
        break;
        
      case "create":
        // make new goal in guided setup process
        Console.Write("Enter the type of goal (eternal/checklist/onetime): ");
        bool validType = false;
        do
        {
          string goalType = Console.ReadLine();
          switch (goalType)
          {
            case "eternal":
              Console.Write("Goal Name: ");
              string n_e = Console.ReadLine();
              Console.Write("Point Value: ");
              int p_e = 0;
              string p_e_str = "";
              
              do
              {
                shouldAskAgain = false;
                try
                {
                  p_e_str = Console.ReadLine();
                  p_e = int.Parse(p_e_str);
                }
                catch (FormatException)
                {
                  shouldAskAgain = true;
                  Console.WriteLine($"Expected an int, got \"{p_e_str}\"\n");
                }
              } while (shouldAskAgain);
              
              AddGoal(new EternalGoal(n_e, p_e));
              validType = true;
              break;
              
            case "checklist":
              Console.Write("Goal Name: ");
              string n_c = Console.ReadLine();
              int p_c = 0;
              string p_c_str = "";
              do
              {
                shouldAskAgain = false;
                Console.Write("Point Value: ");
                try
                {
                  p_c_str = Console.ReadLine();
                  p_c = int.Parse(p_c_str);
                }
                catch (FormatException)
                {
                  shouldAskAgain = true;
                  Console.WriteLine($"Expected an int, got \"{p_c_str}\"\n");
                }
              } while (shouldAskAgain);
              shouldAskAgain = false;
              
              Console.WriteLine("How many times should this goal be completed?");
              Console.Write("Count: ");
              string min_c_str = "";
              int min_c = 0;
              do
              {
                shouldAskAgain = false;
                try
                {
                  min_c_str = Console.ReadLine();
                  min_c = int.Parse(min_c_str);
                }
                catch (FormatException)
                {
                  shouldAskAgain = true;
                  Console.WriteLine($"Expected an int, got \"{min_c_str}\"\n");
                }
              } while (shouldAskAgain);
              
              Console.WriteLine("How many bonus points should reaching the threshold give?");
              string b_c_str = "";
              int b_c = 0;
              do
              {
                shouldAskAgain = false;
                Console.Write("Bonus: ");
                try
                {
                  b_c_str = Console.ReadLine();
                  b_c = int.Parse(b_c_str);
                }
                catch (FormatException)
                {
                  shouldAskAgain = true;
                  Console.WriteLine($"Expected an int, got \"{b_c_str}\"\n");
                }
              } while (shouldAskAgain);
              shouldAskAgain = false;
              
              AddGoal(new ChecklistGoal(n_c, b_c, p_c, min_c));
              validType = true;
              break;
              
            case "onetime":
              Console.Write("Goal Name: ");
              string n_o = Console.ReadLine();
              Console.Write("Point Value: ");
              int p_o = 0;
              string p_o_str = "";
              do
              {
                shouldAskAgain = false;
                try
                {
                  p_o_str = Console.ReadLine();
                  p_o = int.Parse(p_o_str);
                }
                catch (FormatException)
                {
                  shouldAskAgain = true;
                  Console.WriteLine($"Expected an int, got \"{p_o_str}\"\n");
                }
              } while (shouldAskAgain);
              AddGoal(new OneTimeGoal(n_o, p_o));
              validType = true;
              break;
              
            default:
              Console.WriteLine($"Unrecognized goal type: {goalType}\n");
              break;
          }
        } while (!validType);
        break;
        
      case "quit":
        SetShouldExit(true);
        Console.WriteLine("Goodbye.\n");
        break;
        
      case "about":
        Console.WriteLine("EternalQuest is a program designed to track and gamify your goals, both short and long-term.");
        Console.WriteLine("");
        Console.WriteLine("There are three types of goals:");
        Console.WriteLine("1. One-Time Goals: goals meant to be accomplished once.");
        Console.WriteLine("2. Check-list Goals: Goals meant to be done a set number of times (or more if you want).");
        Console.WriteLine("3. Eternal Goals: Goals you try to always do.");
        Console.WriteLine("");
        Console.WriteLine("Each goal gives points when you check it off, but Check-list goals will give a bonus once you reach the set threshold.");
        Console.WriteLine("");
        Console.WriteLine("You write commands to interact with the program. For example, to mark the 3rd goal in the list as having been completed, you'd write:\n");
        Console.WriteLine("check-off 3");
        Console.WriteLine("Not all goals take arguments; some run interactively. For example, the \"create\" command will ask for the details of the goal to be created.");
        Console.WriteLine("\nFor a list of all commands, run the \"help\" command.\n");
        break;
        
      case "clear":
        Console.Clear();
        break;
        
      default:
        Console.WriteLine($"Invalid Command: \"{cmd}\"\n");
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
