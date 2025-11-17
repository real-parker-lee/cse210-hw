class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hi");
    Person john = new Person("John", "Csharp", 25, 178);
    Police harry = new Police("Teargas Launcher, submachine gun, mask, pepper spray, flashbang(58), baton, rubber bullets(258)", "Harry", "Preston", 34, 250);
    john.SetWeight(180);
    Console.WriteLine(john.PersonInformation());
  }
}
