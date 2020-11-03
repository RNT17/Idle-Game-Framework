using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class MyUpgrade
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

class MyHelper 
{
    public int id { get; set; }
    public string name { get; set; }
    public int baseCost { get; set; }
    public int buyPrice { get; set; }
    public MyUpgrade upgrade { get; set;}
}

class Program
{

    public static void Main(string[] args)
    {
        //Idlegfw idleGame = new Idlegfw();        
        //ReadKeyExample();
        //ReadKeyConsoleKeyInfoExample();
        //JsonDeserializerFromFile();
        // JsonDeserializer();
        JsonDeserializerHelper();
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

    /*
        JsonConvert é uma lib de terceiros ()
    */
    public static void JsonDeserializerFromFile()
    {
        // string path = @"D:\Development Game\Unity\Projects\UTests\UTests\fw\HelpersConfig.json";
        // if (!File.Exists(path))
        // {
        //     Console.WriteLine("File not exists!");
        //     return; 
        // }
        
        // string readText = File.ReadAllText(path);
        // var HelperList = JsonConvert.DeserializeObject<Wrapper>(readText).HelperList;
        
        // Console.WriteLine("id: " + HelperList.Id);
        // foreach (KeyValuePair<string, Helper> kvp in HelperList.Helpers)
        // {
        //     Console.WriteLine(kvp.Key + " id: " + kvp.Helper.Id);
        //     Console.WriteLine(kvp.Key + " name: " + kvp.Helper.Name);
        // }
    }

    public static void JsonDeserializer()
    {
        //string json = @"['Starcraft','Halo','Legend of Zelda']";
        string json =
        @"
            [
                {id: 1, name: 'Hero', baseCost: 10, buyPrice: 10},
                {id: 2, name: 'Another Hero', baseCost: 20, buyPrice: 50, upgrade: {id:1, name: 'Copo de Cerveja', 'Description': 'Aumenta o DPS de Hero em 100%'} },
            ]
        ";

        List<MyHelper> mobj = JsonConvert.DeserializeObject<List<MyHelper>>(json);

        foreach (var obj in mobj)
        {
            Console.WriteLine("id: {0}\nname: {1}\nbaseCost: {2}\nbuyPrice: {3}", obj.id, obj.name, obj.baseCost, obj.buyPrice);
            Console.WriteLine("[\nupgrade:\nid: {0}\nname: {1}\ndescription: {2}\n]\n", obj.upgrade?.id, obj.upgrade?.name, obj.upgrade?.description);
        }
    }

    public static void JsonDeserializerHelper()
    {
        string path = @"D:\Development Game\Unity\Projects\UTests\UTests\fw\Helpers.json";
        if (!File.Exists(path))
        {
            Console.WriteLine("File not exists!");
            return; 
        }
        
        string readText = File.ReadAllText(path);
        List<MyHelper> HelperList = JsonConvert.DeserializeObject<List<MyHelper>>(readText);

        foreach(var h in HelperList) 
        {
            Console.WriteLine("id: {0}\nname: {1}\nbaseCost: {2}\nbuyPrice: {3}", h.id, h.name, h.baseCost, h.buyPrice);
            Console.WriteLine("[\nupgrade:\nid: {0}\nname: {1}\ndescription: {2}\n]\n", h.upgrade?.id, h.upgrade?.name, h.upgrade?.description);
        }
    }
}