using System;

class Program
{
    static void Main(string[] args)
    {
        // prompt for and parse integer percentage
        Console.Write("Enter the grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());
        
        // print appropriate grade
        Console.Write("Your Letter Grade Is: ");
        if (percentage >= 90) {
            Console.WriteLine("A");
        } else if (percentage >= 80) {
            Console.WriteLine("B");
        } else if (percentage >= 70) {
            Console.WriteLine("C");
        } else if (percentage >= 60) {
            Console.WriteLine("D");
        } else {
            Console.WriteLine("F");
        }
        
        // determine if user passed the course
        if (percentage >= 70) {
            Console.WriteLine("Congrats on passing the course!");
        } else {
            Console.WriteLine("Don't give up! There's always next time!");
        }
    }
}
