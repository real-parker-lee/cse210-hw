using System;

class Program
{
    static void Main(string[] args)
    {
        Activity a = new Activity("descriptionTest");
        a.SetDuration(5);
        a.Run();
    }
}
