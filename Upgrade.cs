using System;

public class Upgrade
{
    private string name = "unnamed";
    private string desc = "Generic Upgrade";
    private int effect = 100; // 100 percent
    private int requiredLevel = 10; //required player's level (quantity) to unlock this specific helper
    private int buyCost = 10;
    public int BuyCost { get; }

    public Upgrade(string name, string desc, int effect, int buyCost)
    {
        this.name = name;
        this.desc = desc;
        this.effect = effect;
        this.buyCost = buyCost;
    }

    
}