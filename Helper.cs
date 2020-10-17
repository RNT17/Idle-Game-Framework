using System;

// Same as Buildings
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
    public Upgrade upgrade;

    public Helper (
        string name = "unnamed helper", 
        string description = "Generic helper that produces resources", 
        int baseCost = 10, 
        int productionValue = 1)
    {
        this.name = name;
        this.description = description;
        this.baseCost = baseCost;
        this.productionValue = productionValue;

        // May be implemented in the future:
        /*
        canEvolve: false, //remove?
        needItem: false, //remove?
        itemNeeded: [], //remove?        
        public int nextLevelPrice = 10;
        requiredLevel: 10, //required player's level to unlock this specific helper
        this.unlocksAt: "", // expression to be converted/executed by eval, eg.: maxCoins > 800. PlayerLevel > 15
        */
    }  

    public void OnItemBought ()
    {
        this.quantity++;
        this.buyPrice = this.CalculatePrice();

        // Acredito que não seja o melhor local pra fazer isso.        
        this.level++; // Tratando level como item comprado ?
        upgrade.SetUnlocked(level); // Usando level para fazer unlock de upgrade para permitir upgrade ?

        //var audio = new Audio("game/assets/sounds/OnItemBought.mp3"); //play audio of being bought
        //var audio = new Audio(this.sounds.OnItemBought); //play audio of being bought
        //audio.play();
        //TODO: display animation            

        //DebugHelper();
    }    
    
    public void OnItemSold ()
    {
        Console.WriteLine("Idle Game Framework: Function not implemented");
        
    }

    public void OnLevelUp ()
    {
        Console.WriteLine("Idle Game Framework: Function not implemented");
    }

    /*
        Depois que class Idlegfw checar que game tem recurso suficiente para fazer upgrade.
        Chamar OnUpgrade de Helper. Aqui é feita a verificação para saber se Upgrade está unlocked para
        ativar seu efeito em Helper. Ex: Upgrade tem o poder de maximizar a produção de recurso em x%.
    */
    public void OnUpgrade(Upgrade upgrade)
    {
        if (!upgrade.unlocked)
        {
            Console.WriteLine("Upgrade is locked!\nRequired level: {0}", upgrade.requiredLevel);
            return;
        }

        productionValue += upgrade.effect;
        Console.WriteLine("Upgraded sucessfull!");
    }

    public void OnUpgrade()
    {

    }

    public void DebugHelper ()
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