class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hi");
    Person john = new Person("John", "Csharp", 25, 178);
    john.SetWeight(180);
    Console.WriteLine(john.PersonInformation());
  }
}
