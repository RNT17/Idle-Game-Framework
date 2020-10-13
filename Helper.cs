using System;

public class Helper 
{
    public string name = "unnamed helper";
    public string description = "Generic helper that produces resources";
    public int baseCost = 10; //how much it costs initially
    public int productionValue = 1; //how much it produces after each iteration
    public int buyPrice = 10; //baseCost;
    public bool isUnique = false;        
    public int level = 1;
    public int quantity = 0;

    public Helper(
        string name = "unnamed helper", 
        string description = "Generic helper that produces resources", 
        int baseCost = 10, 
        int productionValue = 1)
    {
        this.name = name;
        this.description = description;
        this.baseCost = baseCost;
        this.productionValue = productionValue;
    }

    public void OnItemBought ()
    {
        this.quantity++;
        this.buyPrice = this.CalculatePrice();

        //DebugHelper();
    }    

    void DebugHelper()
    {
        Console.WriteLine("Name: " + this.name +
        "\nDescription: " + this.description +
        "\nBase Cost: " + this.baseCost +
        "\nBuy Price: " + this.buyPrice +
        "\nIs Unique: " + this.isUnique +
        "\nQuantity: " + this.quantity +
        "\nLevel: " + this.level +
        "\nProductionValue: " + this.productionValue);
    }

    int CalculatePrice ()
    {
        if (this.quantity == 0)
            return this.baseCost;
        var multiplier = 1.09; //TODO: Move this to a global            
        var price = this.baseCost * Math.Pow(multiplier, this.quantity);
        
        return (int) Math.Ceiling(price); //The Math.ceil() function returns the smallest integer greater than or equal to a given number.
    }
}