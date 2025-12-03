public class GoalTracker
{
  private List<BaseGoal> _goals = new List<BaseGoal>();
  private int _totalPoints = 0;
  private string _currentPath = "EternalQuest.save";
  
  public void AddGoal(BaseGoal b)
  {
    _goals.Add(g);
  }
  
  public void DeserializeAndLoad(string path)
  {
    // for each line in file
    // if first line, read as number of points.
    // split by pipe
    // construct goal from remaining list, choosing type from first entry.
    // add goal to master list.
  }
  
  public BaseGoal SelectGoal() // by index from user input
  {
    
  }
  
  public SerializeAll(string path) // use custom path
  {
    // first line always has number of points accrued.
    
  }
  
  public SerializeAll() // use current path
  {
    // first line always has number of points accrued.
    
  }
  
  public void ShowAll()
  {
    
  }
  
  // main loop for handling user input and commands.
  public void RunRepl()
  {
    // commands:
    // save ?[path]
    // load [path]
    // list ?[eternal|checklist|one-time]
    // mark-done [index]
    // points
    // new-eternal
    // new-checklist
    // new-onetime
    // help
    // quit
  }
}
