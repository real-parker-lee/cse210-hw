using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        
        string firstName;
        string lastName;
        
        Console.WriteLine("Please enter your first name: ");
        firstName = Console.ReadLine();
        
        Console.WriteLine("Please enter your last name: ");
        lastName = Console.ReadLine();
        
        Console.WriteLine($"Your name is {lastName}; {firstName} {lastName}.");
    }
}
