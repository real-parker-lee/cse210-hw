using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Instructor";
        job1._company = "Mathnasium";
        job1._startYear = 2022;
        job1._endYear = 2025;
        
        Job job2 = new Job();
        job2._jobTitle = "Underwater Basket Weaver";
        job2._company = "UBWAA";
        job2._startYear = 1950;
        job2._endYear = 2030;
        
        Resume myResume = new Resume();
        myResume._name = "Parker Lee";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        
        // Console.WriteLine($"{job1._company}");
        // Console.WriteLine($"{job2._company}");
        
        // Console.WriteLine($"{myResume._jobs[0]._company}");
        
        myResume.Display();
    }
}
