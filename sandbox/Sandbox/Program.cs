using System;

class Program
{
    static void Main(string[] args)
    {
//         Console.WriteLine("Hello Sandbox World!");
//         
//         string firstName;
//         string lastName;
//         
//         Console.Write("Please enter your first name: ");
//         firstName = Console.ReadLine();
//         
//         Console.Write("Please enter your last name: ");
//         lastName = Console.ReadLine();
//         
//         Console.WriteLine($"Your name is {lastName}; {firstName} {lastName}.");
//         
//         int x = 10;
//         Console.WriteLine($"{x}, {++x}, {x++}, {x}");
//         Console.WriteLine(Math.Pow(x, 10));
//         
//         // for loop from 0 - 1000 by tens
//         for(int i = 0; i <= 1000; i+=10)
//         {
//             Console.WriteLine($"{i}");
//         }
//         
//         bool done = false;
//         // do-while loop: condition checked at the End of the loop.
//         do
//         {
//             Console.Write("input age: ");
//             // if you're worried about performance, avoid declaring variables within loops.
//             int age = int.Parse(Console.ReadLine());
//             
//             if (age >= 0 && age <= 125)
//             {
//                 done = true;
//                 Console.WriteLine($"Super age: {age}");
//             }
//         } while (!done);
        
        // LISTS
        // List is a class/type.
        // lists are dynamic
        List<int> numbers = new List<int>();
        // adding elements
        numbers.Add(10);
        numbers.Add(3);
        numbers.Add(20);
        
        // iterating over lists
        foreach(int n in numbers)
        {
            Console.WriteLine($"number is {n}");
        }
        
        
    }
}
