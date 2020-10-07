using System;
/**
 * ResourceManager
 * It manages the reource generation and its use.
 * It can start with a predefined quantity of coins and/or maxCoins as in
 * the case of loading a saved game. for that just:
 * va resourceManager = new ResourceManager (coinsQuantity, maxCoinsQuantity) 
 * @param {int} coins
 * @param {int} maxCoins
 */
public class ResourceManager
{
    public int coins;
    public int maxCoins;
    
    public ResourceManager(int coins = 0, int maxCoins = 0)
    {
        this.coins = coins;
        this.maxCoins = maxCoins;

        if (coins < 0)
            this.coins = 0;

        if (maxCoins < 0)
            this.maxCoins = 0;
    }

    /**
     * adds the amount informed to the current quantity of coins
     * then returns the current quantity of coins.
     * @param {int} value 
     */
    public int Produce (int value)
    {
        if (value <= 0) return this.coins;

        this.coins += value;

        if (this.coins > this.maxCoins)
            this.maxCoins = this.coins;
        
        return this.coins;
    }

    /**     
     * Returns true if it is able to spend the value, false otherwise
     * @param {int} value 
     */
    public bool Spend (int value)
    {
        bool spent = false;

        if (value <= 0) return spent;

        if (this.coins >= value)
        {
            this.coins = (int) MathF.Floor(this.coins - value);
            spent = true;            
        }
        
        return spent;
    }
}
