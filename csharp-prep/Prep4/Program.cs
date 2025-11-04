using System;

class Program
{
    static void Main(string[] args)
    {
        // ask user for numbers
        int inputParsed;
        bool keepAsking = true;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, enter 0 when done.");
        do
        {
            Console.Write("Input a number: ");
            inputParsed = int.Parse(Console.ReadLine());
            keepAsking = (0 != inputParsed);
            
            if (keepAsking)
            {
                numbers.Add(inputParsed);
            }
            
        } while (keepAsking);
        
        // foreach (int i in numbers)
        // {
        //     Console.WriteLine($"{i}");
        // }
        
        // Compute sum, max, and avg.
        int runningTotal = 0;
        int maxSoFar = 0;
        foreach (int n in numbers)
        {
            runningTotal += n;
            maxSoFar = (n > maxSoFar) ? n : maxSoFar;
        }
        
        double average = (double)runningTotal / numbers.Count;
        Console.WriteLine($"TOTAL:   {runningTotal}");
        Console.WriteLine($"MAXIMUM: {maxSoFar}");
        Console.WriteLine($"AVERAGE: {average}");
    }
}
