using System;
using System.Collections.Generic;

public class HelperManager
{
    public int currentProductionValue = 0;
    public List<Helper> helpers;
    
    /**
     * This function should load and create helpers,
     * then add them to the helper list.
     * TODO: In the future make it read from a file
     */
    public void InitHelpers()
    {
        helpers = new List<Helper>();

        Helper playerCharacter = new Helper(
            "Hero", "A Brave Hero", 10, 1
        );

        playerCharacter.isUnique = true;

        Helper woodenSword = new Helper(
            "WoodenSword", "A Wooden Sword", 20, 2
        );

        Helper medicine = new Helper(
            "Medicine", "A super strong medicine that heals all wounds", 30, 5
        );

        helpers.Add(playerCharacter);
        helpers.Add(woodenSword);
        helpers.Add(medicine);
    }

    /**
     * Calculates the total production value based on the 
     * current production value of each helper
     */
    int CalculateTotalProductionValue ()
    {
        int acumulator = 0;

        foreach (Helper helper in helpers)
        {
            int value = 0;
            if (helper.quantity >= 0)
                value = helper.productionValue * helper.quantity;

            acumulator += value;
        }        
        
        this.currentProductionValue = acumulator;
        
        return this.currentProductionValue;
    }

    public void DebugerHelpers()
    {
        foreach (var helper in helpers)
        {
            Console.WriteLine(
                "Helpers: \n"
            );
            
            helper.DebugHelper();

            Console.WriteLine(
                "======================\n"
            );
        }
    }
}