using System;

public class Upgrade
{
    public string name = "unnamed";
    public string desc = "Generic Upgrade";
    public bool unlocked = false;
    public int requiredLevel = 10; //required player's level (quantity) to unlock this specific Upgrade
    public int effect = 100; // 100 percent
    public int buyCost = 10;

    public Upgrade(string name = "unnamed", string desc = "Generic Upgrade", int effect = 0, int buyCost = 0)
    {
        this.name = name;
        this.desc = desc;
        // Inicialmente o efeito padrão é alterar o productionValue em Helper em x%. 
        // Mas será repensado uma forma de criar mais de um efeito.
        // Ex: Criar um efeito crítico aleatório de productionValue.
        // Mas isso acontecerá aqui? ou em um evento na classe Helper?
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