using System;

public class Upgrade
{
    private string name = "unnamed";
    private string desc = "Generic Upgrade";
    private bool unlocked = false;
    public bool Unlocked { get; }
    private int effect = 100; // 100 percent
    private int requiredLevel = 10; //required player's level (quantity) to unlock this specific Upgrade
    private int buyCost = 10;
    public int BuyCost { get; }

    public Upgrade(string name = "unnamed", string desc = "Generic Upgrade", int effect = 0, int buyCost = 0)
    {
        this.name = name;
        this.desc = desc;
        this.effect = effect;
        this.buyCost = buyCost;
    }

    public void SetUnlocked(int level)
    {
        if (requiredLevel == level)
        {
            this.unlocked = true;
        }
    }

    
}