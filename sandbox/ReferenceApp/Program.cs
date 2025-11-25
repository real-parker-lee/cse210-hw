class Program
{
  
  static void PassByValue(int x)
  {
    x = 1001;
    Console.WriteLine($"in the scope of PassByValue(), x is set to {x}");
  }
  
  static void PassByReference(ref int x)
  {
    x = 999;
    Console.WriteLine($"in the scope of PassByReference(), x is set to {x}");
  }
  
  static void PassByOut(out int a)
  {
    a = 17; // function MUST initialize this value.
    Console.WriteLine($"In PassByOut(), a is set to {a}");
  }
  
  static void PassReferenceType(int[] data)
  {
    data[3] = 12345;
    Console.WriteLine($"In PassReferenceType(): data[3] is {data[3]}");
  }
  
  public static void Main(string[] args)
  {
    //Console.WriteLine("Sanity Check");
    
    // BY VALUE: values are COPIED to new memory location.
    int x = 10;
    int y = x;
    y++;
    Console.WriteLine($"x is {x}, y is {y}.");
    
    // BY REFERENCE: b changes a, memory is shared.
    int[] a = {1, 2, 3, 4};
    int[] b = a;
    b[3] = 111;
    Console.WriteLine($"a[3] is {a[3]}, b[3] is {b[3]}");
    
    // PASS BY VALUE: Function has its own scope. Makes a copy of its input variable and modifies that.
    PassByValue(x);
    Console.WriteLine($"In the main scope, x is now {x}");
    
    // PASS BY REFERENCE: memory address to x is passed, x is mutated directly.
    PassByReference(ref x);
    Console.WriteLine($"In the main scope, x is now {x}");
    
    // PASS BY OUT: will mutate z. Function must declare the variable!!!
    // benefit: this forces the initialization of variables within the scope in which the function was called.
    int z;
    PassByOut(out z);
    Console.WriteLine($"In main scope: z is now set by a to {z}");
    
    // PASS REFERENCE TYPE: pass a type that is already a reference.
    // mutates memory at address.
    PassReferenceType(a);
    int idx = 0;
    foreach (int i in a)
    {
      Console.WriteLine($"In main scope: a[{idx}] is now {i}");
      idx++;
    }
  }
}
