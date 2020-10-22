using System;
class Program
{
    public static void Main(string[] args)
    {
        Idlegfw idleGame = new Idlegfw();        
        //ReadKeyExample();
        //ReadKeyConsoleKeyInfoExample();
    }

    public static void ReadKeyConsoleKeyInfoExample()
    {
        ConsoleKeyInfo cki;
        // Prevent example from ending if CTL+C is pressed.
        Console.TreatControlCAsInput = true;

        Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
        Console.WriteLine("Press the Escape (Esc) key to quit: \n");
        do
        {
            cki = Console.ReadKey();
            //Console.Write(" --- You pressed ");
            // if((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
            // if((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
            // if((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
            if (cki.Key.ToString() == "A")
                Console.WriteLine("Pressionu A: " + cki.Key.ToString());
            else if (cki.Key.ToString() == "B")
                Console.WriteLine("Pressionou B: " + cki.Key.ToString());
        } while (cki.Key != ConsoleKey.Escape);
    }

    public static void ReadKeyExample()
    {
        string m1 = "\nType a string of text then press Enter. " +
                "Type '+' anywhere in the text to quit:\n";
        string m2 = "Character '{0}' is hexadecimal 0x{1:x4}.";
        string m3 = "Character     is hexadecimal 0x{0:x4}.";
        char ch;
        int x;

        Console.WriteLine(m1);
        do
        {
            x = Console.Read();
            try
            {
                ch = Convert.ToChar(x);
                if (Char.IsWhiteSpace(ch))
                {
                    Console.WriteLine(m3, x);
                    if (ch == 0x0a)
                        Console.WriteLine(m1);
                }
                else
                {
                    Console.WriteLine(m2, ch, x);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("{0} Value read = {1}.", e.Message, x);
                ch = Char.MinValue;
                Console.WriteLine(m1);
            }
        } while (ch != '+');
    }
}