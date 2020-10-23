using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class HelperManager
{
    public int currentProductionValue = 0;
    public List<Helper> helpers = new List<Helper>();

    /**
     * This function should load and create helpers,
     * then add them to the helper list.
     * TODO: In the future make it read from a file
     */
    public void InitHelpers()
    {
        Helper playerCharacter = new Helper(
            1, "Hero", "A Brave Hero", 10, 1
        );
        playerCharacter.upgrade = new Upgrade("Copo de Cerveja", "Aumenta o DPS de Ivan, O lutador em 100%", 100);

        playerCharacter.isUnique = true;

        Helper woodenSword = new Helper(
            2, "WoodenSword", "A Wooden Sword", 20, 2
        );

        Helper medicine = new Helper(
            3, "Medicine", "A super strong medicine that heals all wounds", 30, 5
        );

        helpers.Add(playerCharacter);
        helpers.Add(woodenSword);
        helpers.Add(medicine);
    }
    
    public void InitHelpers(bool json)
    {
        Helper helpers = JsonSerializer.Deserialize<Helper>(jsonHelpes());
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
            if (helper.quantity >= 1)
                value = helper.productionValue * helper.quantity;

            acumulator += value;
        }        
        
        this.currentProductionValue = acumulator;
        
        return this.currentProductionValue;
    }

    /**
     * Calculates the total production value for a specific helper 
     * @param {string} name 
     */
    public int CalculateTotalProductionByHelperName (string name)
    {
        var acumulator = 0;

        foreach (var helper in helpers)
        {
            var value = 0;
            if (helper.name == name)
            {
                if (helper.quantity >= 1)
                    value = helper.productionValue * helper.quantity;
            }
            acumulator += value;
        }

        this.currentProductionValue = acumulator;

        return this.currentProductionValue;
    }

    /**
     * Verifies if the helpers array has a helper with
     * the provided ID.
     * @param {int} id 
     */
    public bool HasHelperWithId (int id) 
    {
        var has = false;
        if (this.helpers.Count >= 1)
        {
            foreach (var helper in helpers)
            {
                if (helper.id == id)
                    has = true;
            }
        }

        return has;
    }

    /**
     * informs how many helpers with a specific ID there are in the helpers list
     * which means: how many helpers of that ID were already bought.
     * @param {int} id 
     */
    int NumberOfHelpersById (int id)
    {
        var count = 0;
        foreach (var helper in helpers)
        {
            if (helper.id == id)
                count++;
        }
        return count;
    }

    public Helper HelperById(int id)
    {
        foreach (var helper in helpers)
        {
            if (helper.id == id)
                return helper;
        }
        return null;
    }

    //returns the total amount that helpers of same ID will produce
    int TotalProductionByHelperId (int id)
    {
        // return this.helpers.filter(helper => helper.id === id).reduce(function (accumulator, helper) {
        //     return accumulator += helper.productionValue;
        // }, 0);
        return 0;
    }

    // ==== Métodos não fixos ou que podem deixar de existir ==== //

    public void DebugerHelpers(bool debugToBuy = false)
    {
        foreach (var helper in helpers)
        {
            Console.WriteLine(
                "Helpers: \n"
            );
            
            if (debugToBuy) helper.DebugHelperToBuy(); else helper.DebugHelper();

            Console.WriteLine(
                "============================================\n"
            );
        }
    }

    string jsonHelpes()
    {
        return "{" +
        "id: 1" + 
        "name: unnamed helper" + 
        "description: Generic helper that produces resources" + 
        "baseCost: 10" +
        "productionValue: 1" +
        "} ," +
        "{" +
        "id: 2" +
        "name: Hero" + 
        "description: Generic helper that produces resources" + 
        "baseCost: 11" +
        "productionValue: 2" +
        "}";
    }
}