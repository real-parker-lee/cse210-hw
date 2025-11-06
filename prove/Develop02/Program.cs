using System;
// using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        int selection;
        bool done = false;
        
        do
        {
            selection = menu.ProcessMenu();
            switch(selection)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break
                case 4:
                    break;
                case 5:
                    done = true;
                    break;
            }
        } while (!done);
    }
}
