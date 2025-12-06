class Program
{
    static void Main(string[] args)
    {
        /*For some context, I taught myself a language called Common Lisp, which is a beautiful and powerful language with first-class functions, powerful macros, and multiple-inheritance. It changed the way I thought about what code could be. My implementation of this program was informed by commonplace Lisp conventions, which you will see later in this file.
         
        To be honest, the Repl class and the Command class are cool enough to be a stand-alone library. It affords total control to the developer implementing the UI, defines all data in one place, and maintains separation from classes that hold data and classes that show the UI. I'm really proud of those classes! Just replace any occurence of EntryHandler with a custom class and it should work.
        
        To make a new command, one provides the name, usage, and description, along with a lambda function cast to an Action<string[], EntryTracker>. This allows the behavior of the command to be defined upon instantiation, and to act on the EntryHandler by invoing the EhtryHandler's methods, passing Parsed values from the string array when necessary.
        
        This works even if no one EntryTracker is specified, since the Command class overloads the method that calls the lambda function, allowing us to define a version that operates on each EntryTracker stored by the REPL class. The only downside is that, in cases where a specific EntryTracker is not specified, the function will run once for each tracker, even in cases where we're not operating on the tracker. For example, the 'clear' command actually clears the console three times, but clearing the console is idempotent so we don't really care.
        
        There are cases where you do need to be careful of the aforementioned downside: making a command that does not specify an EntryTracker that just prints a message will result in that message being printed three times.
        */
        
        // instance a REPL (Read-Evaluate-Print Loop) for user interaction
        // (another thing I borrowed from LISP, which invented the concept as far as I know).
        Repl repl = new Repl("> ", "Welcome to the Docket REPL!\nType 'help' to get a list of commands.\n");
        
        // define all commands, their behavior, and their documentations.
        // DONE
        repl.AddCommand(new Command("load", "load [path::string]", "    Load a docket from the file at the given path.\n",
                                    (args, tracker) => {
                                        repl.IncrementEvalCount();
                                        string path = "";
                                        try
                                        {
                                            path = args[1];
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            Console.WriteLine("ERROR: insufficient number of arguments. MUST specify a path to load from.\n");
                                            return;
                                        }
                                        repl.SetCurrentPath(args[1]);
                                        Console.WriteLine($"Loading all {tracker.GetGroupName()} from file at {repl.GetCurrentPath()}.");
                                        if (repl.GetEvalCount() == 0)
                                        {
                                            Console.WriteLine("");
                                        }
                                        try
                                        {
                                            string[] lines = File.ReadAllLines(repl.GetCurrentPath());
                                            repl.SetEntryTrackers(EntryTracker.Deserialize(repl.GetCurrentPath()));
                                        }
                                        catch (FileNotFoundException)
                                        {
                                            Console.WriteLine($"Error: no file found at path '{repl.GetCurrentPath()}'");
                                            return;
                                        }
                                        // invoke the static deserialize method from EntryTracker to set the repl's tracker in bulk.
                                    }));
        // DONE
        repl.AddCommand(new Command("save", "save [?path::string]", "    Save the current docket to the file at [path], or to the last loaded file if no path is provided.\n",
                                    (args, tracker) => {
                                        if (args.Count() == 2)
                                        {
                                            tracker.SetCurrentPath(args[1]);
                                            repl.SetCurrentPath(args[1]); // yeah i know this is redundant. dont care.
                                            repl.AppendToSaveBuffer(tracker.Serialize());
                                            //Console.WriteLine(savePart);
                                        }
                                        else if (args.Count() == 1)
                                        {
                                            repl.AppendToSaveBuffer(tracker.Serialize());
                                            //savePart = savePart + tracker.Serialize();
                                            //Console.WriteLine(savePart);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid number of arguments.\n");
                                        }
                                        
                                        repl.IncrementEvalCount();
                                        try
                                        {
                                            File.WriteAllText(repl.GetCurrentPath(), repl.GetSaveBuffer());
                                            if (repl.GetEvalCount() == 0)
                                            {
                                                repl.SetSaveBuffer("");
                                                //savePart = ""; // erase SavePart only after the last entry type has been saved to the file.
                                            }
                                        }
                                        catch (FileNotFoundException)
                                        {
                                            Console.WriteLine($"Error: no file found at path '{repl.GetCurrentPath()}'.\n");
                                            return;
                                        }
                                        catch (AccessViolationException)
                                        {
                                            Console.WriteLine("Error: file access denied.\n");
                                            return;
                                        }
                                        if (repl.GetEvalCount() == 0)
                                        {
                                            Console.WriteLine($"Saved all entries to file at '{repl.GetCurrentPath()}'\n");
                                        }
                                    }));
        // DONE
        repl.AddCommand(new Command("list", "list [?type::string]", "    list all entries of the given [type], or all entries if no type is given.\n    Type can be one of the following literals: 'event', 'note', or 'task'\n",
                                    (args, tracker) => {
                                        tracker.ShowAll();
                                    }));
        repl.AddCommand(new Command("view", "view [type::string] [index::int]", "    View the entry with the given index in more detail.\n",
                                    (args, tracker) => {
                                        if (args.Count() < 3)
                                        {
                                            repl.IncrementEvalCount();
                                            if (repl.GetEvalCount() == 0)
                                                Console.WriteLine($"Error: insufficient number of arguments.\n");
                                                return;
                                        }
                                        
                                        // validate index
                                        try
                                        {
                                            int vIdx = int.Parse(args[2]) - 1;
                                            tracker.GetEntries()[vIdx].Show();
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine($"Error: could not parse {args[2]} as an Integer.\n");
                                            return;
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            Console.WriteLine($"Error: index {int.Parse(args[2]) - 1} is out of range. There is no entry #{int.Parse(args[2])} in {args[1]}s.");
                                        }
                                    }));
        // TODO
        repl.AddCommand(new Command("new", "new [type::string] [ARGS]", "    Create a new entry of the given type. Arguments for each are order-sensitive, and are as follows:\n      EVENT: name::string, priority::int, location::string, start::string, end::string\n      TASK: name::string, priority::int\n      NOTE: name::string, priority::int\n    Start and end strings must be parseable dates, and the priority must be from 0 through 4.\n    The actual contents of the note will be obtained interactively.\n",
                                    (args, tracker) => {
                                        try
                                        {
                                            switch (args[1].ToUpper())
                                            {
                                                case "TASK":
                                                    if (args.Count() < 4)
                                                    {
                                                        Console.WriteLine("Error: Insufficient number of arguments.");
                                                        return;
                                                    }
                                                    // attempt to parse rest of args
                                                    string name = args[2];
                                                    int priorityInt = -1;
                                                    try
                                                    {
                                                        priorityInt = int.Parse(args[3]);
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        //Console.WriteLine($"> list {args[1]} {args[2]} ... ");
                                                        Console.WriteLine($"Error: could not parse \"{args[3]} as an Int.\"");
                                                        return;
                                                    }
                                                    // check if integer is in range:
                                                    if (0 > priorityInt || priorityInt > 4)
                                                    {
                                                        Console.WriteLine($"Error: The integer \"{args[3]}\" does not correspond to a valid Priority.");
                                                        return;
                                                    }
                                                    
                                                    //Are we still in this block? if so, make a new Task:
                                                    tracker.AddEntry(new TaskEntry(name, Priority.FromNumber(priorityInt), false));
                                                    Console.WriteLine($"Created new Task.\n");
                                                    break;
                                                case "EVENT":
                                                    if (args.Count() < 7)
                                                    {
                                                        Console.WriteLine("Error: Insufficient number of arguments.");
                                                        return;
                                                    }
                                                    string eventName = args[2];
                                                    // try to get priority.
                                                    priorityInt = -1;
                                                    try
                                                    {
                                                        priorityInt = int.Parse(args[3]);
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine($"Error: could not parse \"{args[3]}\" as an Int.");
                                                    }
                                                    Priority p = Priority.FromNumber(priorityInt);
                                                    // TRICK: if this int does not represent a valid priority, calling AsString() will return a string that is parseable as an int.
                                                    try
                                                    {
                                                        int throwaway = int.Parse(p.AsString());
                                                        // if we're here, the int wasn't a valid priority. show an error and stop.
                                                        Console.WriteLine($"Error: The integer \"{args[3]}\" does not correspond to a valid Priority.");
                                                        return;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        // if we're here, AsString was able to find a corresponding priority.
                                                        // parse the rest of the data
                                                        // get location
                                                        string eventLocation = args[4];
                                                        
                                                        // try to get start
                                                        DateTime start = new DateTime();
                                                        try
                                                        {
                                                            start = DateTime.Parse(args[5]);
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine($"Error: Could not parse \"{args[5]}\" as DateTime.");
                                                            return;
                                                        }
                                                        // try to get end
                                                        DateTime end = new DateTime();
                                                        try
                                                        {
                                                            end = DateTime.Parse(args[6]);
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine($"Error: Could not parse \"{args[6]}\" as DateTime");
                                                            return;
                                                        }
                                                        
                                                        tracker.AddEntry(new EventEntry(eventName, p, eventLocation, start, end));
                                                        Console.WriteLine("Created new Event.\n");
                                                    }
                                                    break;
                                                
                                                case "NOTE":
                                                    if (args.Count() <= 3)
                                                    {
                                                        Console.WriteLine($"Error: insufficient number of arguments.\n");
                                                        return;
                                                    }
                                                    string noteName = args[2];
                                                    Priority noteP;
                                                    try
                                                    {
                                                        noteP = Priority.FromNumber(int.Parse(args[3]));
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine($"Error: could not parse {args[3]} as Integer.\n");
                                                        return;
                                                    }
                                                    
                                                    // check if int corresponds to valid priority
                                                    try
                                                    {
                                                       int throwaway = int.Parse(noteP.AsString());
                                                       Console.WriteLine($"Error: The integer {args[3]} does not correspond to a valid priority.\n");
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        // edit a note
                                                        Note note = new Note();
                                                        note.Edit(noteName, "Edit Me, then press ESC when done!");
                                                        Console.Clear();
                                                        string b64Data = note.GetEncodedData();
                                                        Console.WriteLine($"Encoded: {b64Data}");
                                                        
                                                        tracker.AddEntry(new NoteEntry(noteName, noteP, b64Data, DateTime.Now));
                                                        Console.WriteLine("Created new Note.\n");
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("Error: unrecognized entry type: {args[1]}.\n");
                                                    return;
                                            }
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            Console.WriteLine($"Error: insufficient number of arguments.\n");
                                        }
                                    }));
        // DONE
        repl.AddCommand(new Command("complete", "complete [type::string] [index::int]", "    Marks an item as complete if such an action is supported.\n",
                                    (args, tracker) => {
                                        int idx;
                                        //Console.WriteLine("complete invoked");
                                        try
                                        {
                                            idx = int.Parse(args[2]);
                                            tracker.GetEntries()[idx - 1].CheckOff(idx);
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine($"Error: could not parse {args[2]} as an Int.\n");
                                            return;
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            Console.WriteLine($"Error: index {int.Parse(args[2]) - 1} is out of range. There is no entry #{args[2]} in {args[1]}s.\n");
                                            return;
                                        }
                                        
                                    }));
        // DONE
        repl.AddCommand(new Command("delete", "delete [type::string] [index::int]", "    Removes the item at the given index of the given group.\n",
                                    (args, tracker) => {
                                        // check for correct number of args.
                                        if (args.Count() < 3)
                                        {
                                            Console.WriteLine("Error: insufficient amount of arguments.\n");
                                            return;
                                        }

                                        // check that index is parseable
                                        int delIdx = -1;
                                        try
                                        {
                                            delIdx = int.Parse(args[2]) - 1;
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine($"Error: could not parse '{args[2]}' as an Int.\n");
                                            return;
                                        }
                                        
                                        // remove item
                                        try
                                        {
                                            tracker.GetEntries().RemoveAt(delIdx);
                                            Console.WriteLine($"Deleted {args[1]} #{delIdx + 1}.\n");
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            Console.WriteLine($"Error: index {delIdx} is out of range. There is no entry #{delIdx + 1} in {args[1]}s\n");
                                            return;
                                        }
                                    }));
        // DONE
        repl.AddCommand(new Command("clear", "clear", "    Clear the console.\n",
                                    (args, tracker) => {
                                        Console.Clear();
                                    }));
       
        // run the REPL
        repl.Run();
    }
}
