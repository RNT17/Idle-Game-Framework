using System;
using System.Collections.Generic;

public class Game
{
    public List<Helper> helpers = new List<Helper>();
    public int currentProductionValue = 0; // Acumulado de valor de produção de todos os helpers
    public int productionValue = 1; // recurso gerado por click -> TODO: mudar tudo para resourceGeneratedPerClick 
    public int buyPrice = 10;

    private int baseCost = 10;
    private int quantity = 1;

    /**
    * After the framework have checked if the player has enough money to upgrade productionValue Game
    * the method OnProductionValueUpgraded is called. It them acts as necessary.
    * The default behavior is to add +1 to productionValue and +1 to quantity and upgrade its price.
    */
    public void OnProductionValueUpgraded()
    {
        this.productionValue += 1;
        this.quantity++;
        this.buyPrice = this.CalculatePrice();
    }

    public int CalculatePrice ()
    {                
        if (this.quantity == 0)
            return this.baseCost;
        float multiplier = 1.09f; //TODO: Move this to a global            
        float price = this.baseCost * MathF.Pow(multiplier, this.quantity);

        return (int) MathF.Ceiling(price); //The Math.ceil() function returns the smallest integer greater than or equal to a given number.
    }

    public int CalculateTotalProductionValue()
    {
        int acumulator = 0;

        foreach (Helper helper in helpers)
        {
            acumulator += helper.productionValue;
        }        
        
        this.currentProductionValue = acumulator;
        
        return this.currentProductionValue;
    }   
}