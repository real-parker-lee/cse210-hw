using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        
        string firstName;
        string lastName;
        
        Console.Write("Please enter your first name: ");
        firstName = Console.ReadLine();
        
        Console.Write("Please enter your last name: ");
        lastName = Console.ReadLine();
        
        Console.WriteLine($"Your name is {lastName}; {firstName} {lastName}.");
        
        int x = 10;
        Console.WriteLine($"{x}, {++x}, {x++}, {x}");
        Console.WriteLine(Math.Pow(x, 10));
        
        // for loop from 0 - 1000 by tens
        for(int i = 0; i <= 1000; i+=10)
        {
            Console.WriteLine($"{i}");
        }
    }
}
