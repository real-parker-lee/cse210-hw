public class Program
{
    static void Main(string[] args)
    {
        List<BaseGoal> goals = new List<BaseGoal>();
        goals.Add(new EternalGoal("test goal", 1000));
        goals.Add(new OneTimeGoal("onetime", 2000));
        goals.Add(new ChecklistGoal("checklist", 1500, 500, 5));
        
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {goals[i].Show()}");
        }
        int points = 0;
        Console.WriteLine(points);
        points = goals[0].CheckOff();
        Console.WriteLine(points);
        
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {goals[i].Show()}");
        }
    }
}
