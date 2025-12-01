using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        shapes.Add(new Circle("green", 10.0));
        shapes.Add(new Square("red", 10.0));
        shapes.Add(new Rectangle("brown", 5.0, 7.2));
        
        for (int i = 0; i < shapes.Count; i++)
        {
            Console.WriteLine("Circle Square Rectangle".Split(" ")[i]);
            Console.WriteLine($"AREA: {shapes[i].GetArea()}");
            Console.WriteLine($"COLOR: {shapes[i].GetColor()}");
            Console.WriteLine("");
        }
    }
}
