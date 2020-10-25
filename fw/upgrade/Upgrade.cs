using System;

public class Upgrade
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Unlocked { get; private set; } = false;
    public int RequiredLevel { get; set; } = 10; //required player's level (quantity) to unlock this specific Upgrade
    public int Effect { get; set; } = 100;
    public int BuyCost { get; set; } = 10;

    //public EventHandler OnUpgradeEvent;

    public Upgrade () { }

    public Upgrade (string name = "unnamed", string desc = "Generic Upgrade", int effect = 100, int buyCost = 10)
    {
        this.Name = name;
        this.Description = desc;
        // Inicialmente o efeito padrão é alterar o productionValue do Helper em x%. 
        // Mas será repensado uma forma de criar mais de um efeito.
        // Ex: Criar um efeito crítico aleatório de productionValue.
        // Mas isso acontecerá aqui? ou em um evento na classe Helper?
        this.Effect = effect; 
        this.BuyCost = buyCost;
    }

    public void DebugUpgrade ()
    {
        Console.WriteLine(
            "Name: " + this.Name +
            "\nDesc: " + this.Description +
            "\nEffect Value: " + this.Effect +
            "\nBuy Cost: " + this.BuyCost
        );
    }

    public Upgrade(bool unlocked)
    {
        this.Unlocked = unlocked;
    }

    public void SetUnlocked(int level)
    {
        if (RequiredLevel == level)
            this.Unlocked = true;
    }

    public void ApplyEffect(Helper helper)
    {
        helper.ProductionValue = this.Effect;
    }

}