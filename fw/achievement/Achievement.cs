using System;
public class Achievement
{
    private bool unlocked = false; 
    private string name; 
    private string desc; 
    private int evento; 
    private int quantity;
    private MyEventArs mEventArgs;

    public string Name { get => name; }
    public string Desc { get => desc; }
    public int Evento { get => evento; }
    public int Quantity { get => quantity; }
    public MyEventArs MEventArgs { get => mEventArgs; }

    public Achievement (string name, string desc, int evento, int quantity) 
    {
        this.name = name;
        this.desc = desc;
        this.evento = evento;
        this.quantity = quantity;
        // passive effects
    }

    public Achievement (string name, string desc, MyEventArs mEventArgs) 
    {
        this.name = name;
        this.desc = desc;
        this.mEventArgs = mEventArgs;
        // passive effects
    }

    public void Unlocked()
    {
        if (this.unlocked == false)
            this.unlocked = true;
        UnlockedDebug();
    }

    private void UnlockedDebug()
    {
        Console.WriteLine(
            "Achievement Unlocked: " + this.name +
            " " + this.desc
        );
    }   

    public void Details()
    {
        Console.WriteLine("Name: {0}\nDesc: {1}\nEvento: {2}\nQuantity: {3}", this.name, this.desc, this.evento, this.quantity);
    }
}