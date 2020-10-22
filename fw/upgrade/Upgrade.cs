using System;

public class Upgrade
{
    public string name = "unnamed";
    public string desc = "Generic Upgrade";
    public bool unlocked = false;
    public int requiredLevel = 10; //required player's level (quantity) to unlock this specific Upgrade
    public int effect = 100;
    public int buyCost = 10;

    //public EventHandler OnUpgradeEvent;

    public Upgrade(string name = "unnamed", string desc = "Generic Upgrade", int effect = 100, int buyCost = 10)
    {
        this.name = name;
        this.desc = desc;
        // Inicialmente o efeito padrão é alterar o productionValue do Helper em x%. 
        // Mas será repensado uma forma de criar mais de um efeito.
        // Ex: Criar um efeito crítico aleatório de productionValue.
        // Mas isso acontecerá aqui? ou em um evento na classe Helper?
        this.effect = effect; 
        this.buyCost = buyCost;
    }

    public void DebugUpgrade ()
    {
        Console.WriteLine(
            "Name: " + this.name +
            "\nDesc: " + this.desc +
            "\nEffect Value: " + this.effect +
            "\nBuy Cost: " + this.buyCost
        );
    }

    public Upgrade(bool unlocked)
    {
        this.unlocked = unlocked;
    }

    public void SetUnlocked(int level)
    {
        if (requiredLevel == level)
            this.unlocked = true;
    }

    public void ApplyEffect(Helper helper)
    {
        helper.productionValue = effect;
    }

}