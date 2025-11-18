class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("John Student", "AP underwater basket weaving final.");
        Console.WriteLine(a.GetSummary());
        
        MathAssignment m = new MathAssignment("John Student, Ttig Homework", "11.2", "1-16 odd");
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());
    }
}
