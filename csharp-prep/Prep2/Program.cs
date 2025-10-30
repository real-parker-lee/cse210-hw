using System;

class Program
{
    static void Main(string[] args)
    {
        // prompt for and parse integer percentage
        Console.Write("Enter the grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());
        
        string letter;
        
        // print appropriate grade
        //Console.Write("Your Letter Grade Is: ");
        if (percentage >= 90) {
            //Console.WriteLine("A");
            letter = "A";
        } else if (percentage >= 80) {
            //Console.WriteLine("B");
            letter = "B";
        } else if (percentage >= 70) {
            //Console.WriteLine("C");
            letter = "C";
        } else if (percentage >= 60) {
            //Console.WriteLine("D");
            letter = "D";
        } else {
            //Console.WriteLine("F");
            letter = "F";
        }
        
        // print grade sign
        string sign;
        if (percentage % 10 >= 7) {
            sign = "+";
        } else if (percentage % 10 < 3) {
            sign = "-";
        } else {
            sign = "";
        }
        Console.WriteLine($"Your Letter Grade Is: {letter}{sign}");
        
        // determine if user passed the course
        if (percentage >= 70) {
            Console.WriteLine("Congrats on passing the course!");
        } else {
            Console.WriteLine("Don't give up! There's always next time!");
        }
    }
}
