class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("John Student", "AP underwater basket weaving final.");
        Console.WriteLine(a.GetSummary());
        
        Console.WriteLine(" ");
        
        MathAssignment m = new MathAssignment("11.2", "1-16 odd", "John Student", "Trig Homework");
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());
        
        Console.WriteLine(" ");
        
        WritingAssignment w = new WritingAssignment("Mario, the Idea vs. Mario, the Man.", "Phil Jameson", "Philosophy 101 Midterm"); // lol
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());
    }
}
