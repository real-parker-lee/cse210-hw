using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        return Console.ReadLine();
    }
    
    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    
    // oh i hate this syntax.
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }
    
    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    static void DisplayResult(string name, int squaredNum, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNum}.");
        Console.WriteLine($"{name}, you turn {2025 - birthYear} this year.");
    }
    
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNum = PromptUserNumber();
        
        int squaredNum = SquareNumber(favNum);
        
        int birthYear;
        PromptUserBirthYear(out birthYear);
        
        DisplayResult(name, squaredNum, birthYear);
    }
}
