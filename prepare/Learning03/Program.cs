using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        Fraction one = new Fraction();
        Fraction six = new Fraction(6);
        Fraction sixSevenths = new Fraction(6,7);
        
        Console.WriteLine($"numerator of 6/7: {sixSevenths.GetNumerator()}");
        Console.WriteLine($"Denominator of 6/7: {sixSevenths.GetDenominator()}");
        
        Console.WriteLine(one.GetFractionString());
        Console.WriteLine(sixSevenths.GetFractionString());
    }
}
