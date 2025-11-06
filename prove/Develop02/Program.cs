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
                    // create new entry
                    break;
                    
                case 2:
                    // call journal.Display()
                    break;
                    
                case 3:
                    // save to file
                    break;
                    
                case 4:
                    // load from file
                    break;
                    
                case 5:
                    //quit
                    done = true;
                    break;
            }
        } while (!done);
    }
}
