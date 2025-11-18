class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hi");
    Person john = new Person("John", "Csharp", 25, 178);
    Police harry = new Police("Teargas Launcher, submachine gun, mask, pepper spray, flashbang(58), baton, rubber bullets(258)", "Harry", "Preston", 34, 250);
    Doctor jough = new Doctor("scalpel, stethescope", "Jough", "Psmythe", 54, 140);
    john.SetWeight(180);
    Surgeon gionnovich = new Surgeon("Sir", "Scalpel", "Geonnovich", "Movsesyan", 50, 190);
    Console.WriteLine(gionnovich.SurgeonInformation());
    Console.WriteLine(john.PersonInformation());
    Console.WriteLine(jough.DoctorInformation());
    Console.WriteLine(jough.PersonInformation());
  }
}
