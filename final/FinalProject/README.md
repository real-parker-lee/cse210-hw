# Docket: a CLI productivity helper
Docket is a program that lets you save and load things called "dockets": a plain-text, AWK-able file containing a sort of calendar, a list of tasks, and some notes.

Docket is designed to be familiar to those who've used a REPL (Read-Evaluate-Print Loop) before. This design paradigm makes for a flexible user interface that allows a user to do anything the program lets you do in one command.

For example, to load a docket, one would use the following command
```
load example.docket
```
# Classes:
## Repl
The class responsible for mutating entry trackers and parsing user input. It contains a list of commands that can be invoked by the user. It also makes sure all EntryTrackers can be saved and loaded.
## Command
Basically a wrapper around a lambda function that operates on entryTrackers. it stores the command name, usage, and description, and has its behavior defined upon instantiation.
## Note
a helper class that implements a very basic text-editor and base64-encoding/decoding.
## Entry
the base class for all entries
### NoteEntry
represents a Note in memory.
### EventEntry
represents an event (like for a calendar) in memory.
### TaskEntry
represents a task that can be completed.
## EntryTracker
a collection of events, responsible for the serialization of all events it contains.
## Priority
A small utility class for defining, representing, and validating priorities.

# The Docket file format:
A file with the `.docket` extension is a plaintext file that stores data in an AWK-able format, should you wish to write your own tool for interacting with these files.
Each line represents an `Entry`, with each attribute of the entry split by a pipe symbol. The first field of each entry is always an all-caps string denoting its type, the second field is always the name of the entry, and the third is always an integer representing the assigned priority. After that, the fields become more entry-type-dependant.
## Tasks
The remaining entries and their types are as follows:
- Boolean string denoting whether the task is done.
## Events
- string denoting the location
- string denoting the start time
- string denoting the end time
## Note 
- string denoting the date the note was created
- a base64-encoded string containing the actual content of the note.

# The Command System
it is easy to add new commands to docket: in the main Program file, add the following code before `repl.Run()`:
```c#
repl.AddCommand(new Command("my-command", "my-command [args]", "this is the description for my-command and its arguments.",
                                          (args, tracker) => {
                                            // your code here.
                                            // needs to validate non entry-type args itself.
                                          }));
```
This system affords total control to the developer writing the commands, but it comes with a few caveats:
1. You need to do all input validation (apart from checking the entry type) yourself.
2. If your command's first argument is not an entry type (`event`, `task`, or `note`), the command will run on each EntryTracker tracked by the REPL. In some cases, we can ignore this, such as when clearing the console. If you'd rather run the command only once, enclose all code in your lambda body in this conditional statement:
```c#
repl.IncrementEvalCounter(); // must be at the very start of the method, to ensure it does not run more than once per Eval call.
if (repl.GetEvalCounter == 0)
{
  // your code here.
}
```
Internally, the `evalCounter` is an int mod 3, meaning that during the first loop, the eval-counter is 1, during the second it's 2, and during the third its `3 % 3` which is 0. Since there are only three entry types, this works. If you plan to add a new entry type, you'll need to change the modulus in `Repl.cs`.

## Some Tricks
### 1. Checking if a priority is valid
You can easily check if an int corresponds to a valid Priority with the following code:
```c#
// assume the integer variable priorityInt is obtained earlier in the body.
try
{
  int throwaway = int.Parse(Priority.FromNumber(priorityInt).AsString());
  // stuff you want to do if the priority is INVALID
}
catch (FormatException)
{
  // stuff to do if the priority is VALID
}
```
This works because the `AsString` method returns the integer it was passed as a string if that integer doesn't correspond to a valid priority, so successfully parsing the output as an int means the int wasn't a valid priority.
### 2. persisting data across Eval calls
The `Repl` class has an attribute containing a string that acts as a buffer for yet-to-be-saved data. You could use this in your commands to persist data across eval calls, or modify the repl class to include your own buffer. Whatever you do, make sure you erase that buffer on the *last* eval call.
