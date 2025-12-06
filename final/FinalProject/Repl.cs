public class Repl
{
  private string _prompt;
  private string _banner;
  private List<Command> _commands = new List<Command>();
  private bool _doExit = false;
  private List<EntryTracker> _trackers = new List<EntryTracker>();
  private string _currentPath = "docket.save";
  
  public string GetCurrentPath()
  {
    return _currentPath;
  }
  
  public void SetCurrentPath(string path)
  {
    _currentPath = path;
  }
  
  public void DoExit(bool e)
  {
    _doExit = e;
  }
  
  public bool DoExit()
  {
    return _doExit;
  }
  
  public string GetBanner()
  {
    return _banner;
  }
  
  public void SetBanner(string banner)
  {
    _banner = banner;
  }
  
  public string GetPrompt()
  {
    return _prompt;
  }
  
  public void SetPrompt(string prompt)
  {
    _prompt = prompt;
  }
  
  public List<EntryTracker> GetEntryTrackers()
  {
    return _trackers;
  }
  
  public void SetEntryTrackers(List<EntryTracker> trackers)
  {
    _trackers = trackers;
  }
  
  public List<Command> GetCommands()
  {
    return _commands;
  }
  
  public Repl(string prompt, string banner)
  {
    AddEntryTracker(new EntryTracker("TASK", "Tasks", GetCurrentPath()));
    AddEntryTracker(new EntryTracker("EVENT", "Events", GetCurrentPath()));
    AddEntryTracker(new EntryTracker("NOTE", "Notes", GetCurrentPath()));
    SetPrompt(prompt);
    SetBanner(banner);
  }
  
  public void AddCommand(Command cmd)
  {
    GetCommands().Add(cmd);
  }
  
  public void AddEntryTracker(EntryTracker e)
  {
    GetEntryTrackers().Add(e);
  }
  
  public void ShowAllHelp()
  {
    Console.WriteLine("help\n    Show this message.\n");
    Console.WriteLine("quit\n    Exit the program.\n");
    foreach (Command cmd in GetCommands())
    {
      cmd.ShowHelp();
    }
  }
  
  public int TrackerIndexFromTypeString(string type)
  {
    switch (type.ToUpper())
    {
      case "TASK":
        return 0;
      case "EVENT":
        return 1;
      case "NOTE":
        return 2;
      default:
        return -1; // WARNING: Catch this later on, either before or after passing to this function
    }
  }
  
  // DOCUMENTATION:
  /*
    We want to be able to use spaces in our entry names, but the arguments are delineated by spaces. To get around this, we pre-process the split argument array and join all elements between quotes. This new element then has all quotes TRIMMED from it, so it serializes and displays just like a regular string.
    This took me way too long to impement.
  */
  public string[] JoinStrings(string[] rawWords)
  {
    List<string> wordList = new List<string>();
    
    int i = 0; // track place in rawWords
    bool slurping = false;
    while (i < rawWords.Length)
    {
      if (rawWords[i][0] == '"')
      {
        // start slurping.
        slurping = true;
      }
      
      if (slurping)
      {
        // check if first word in quoted string.
        if (rawWords[i][0] == '"')
        {
          // add entry.
          wordList.Add(rawWords[i].Trim('"'));
        }
        else
        {
          // we're in the middle of the quotes.
          wordList[wordList.Count() - 1] = wordList[wordList.Count() - 1] + " " + rawWords[i].Trim('"');
        }
      }
      else
      {
        // not slurping.
        wordList.Add(rawWords[i]);
      }
      
      // check the word you just moved to for an end quote.
      if (rawWords[i][rawWords[i].Length - 1] == '"')
      {
        // stop slurping.
        slurping = false;
      }
      
      i++;
    }
    
    // finally, process the List<string> into a string[].
    string[] result = new string[wordList.Count()];
    for (int j = 0; j < wordList.Count(); j++)
    {
      result[j] = wordList[j];
    }
    
    return result;
  }

  public void Step()
  {
    Console.Write(GetPrompt());
    string input = Console.ReadLine();
    string[] rawargs = input.Split(" ");
    List<string> argList = new List<string>(); 
    Command target = new Command("invalid", "", "", (args, tracker) => {return;});
    EntryTracker tracker;
    
    // if nothing is in the input, do nothing.
    if (rawargs.Count() == 0)
    {
      return;
    }
    
    // Pre-process the argument array, joining any quoted entries into a single string argument.
    string[] args = JoinStrings(rawargs);
    for (int i = 0; i < argList.Count(); i++)
    {
      args[i] = argList[i];
      Console.WriteLine($"{i}: {args[i]}");
    }
    
    // check for special commands
    if (args[0] == "help")
    {
      ShowAllHelp();
    }
    else if (args[0] == "quit")
    {
      DoExit(true);
    }
    else
    {
      // loop thru all commands, find a match to args[0]
      foreach (Command cmd in GetCommands())
      {
        // break out early if command match already found.
        if (target.GetName() != "invalid")
        {
          break;
        }
        target = (cmd.GetName() == args[0]) ? cmd : target;
      }
      
      // if we haven't found a match, show an error.
      if (target.GetName() == "invalid")
      {
        Console.WriteLine($"Error: unrecognized command: \"{args[0]}\".\nType 'help' for a list of commands.");
        return;
      }
      
      // check length of args[], look for type argument at index 1
      //Console.WriteLine($"COMMAND: {target.GetName()}");
      if (args.Count() == 1)
      {
        // no arg, so no type
        // pass to multi-Eval()
        target.Eval(args, GetEntryTrackers());
      }
      else if (args.Count() >= 2)
      {
        // arg, but not definitely a type
        // check if it is a type
        if (TrackerIndexFromTypeString(args[1]) == -1)
        {
          // not a type
          // use multi-tracker version of Eval()
          target.Eval(args, GetEntryTrackers());
        }
        else
        {
          // is a type
          // select proper tracker
          tracker = GetEntryTrackers()[TrackerIndexFromTypeString(args[1])];
          // pass to Eval()
          target.Eval(args, tracker);
        }
      }
    }
  }
  
  public void Run()
  {
    Console.Clear();
    Console.WriteLine(GetBanner());
    do
    {
      Step();
    } while (!DoExit());
  }
}
