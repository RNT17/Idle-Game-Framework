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

    int coins;
    int maxCoins;

    public ResourceManager()
    {
        
    }

    public ResourceManager(int coins, int maxCoins)
    {
        if (coins < 0) coins = 0;
        
        if (maxCoins < 0) maxCoins = 0;

        this.coins = coins;
        this.maxCoins = maxCoins;
    }

    /**
     * adds the amount informed to the current quantity of coins
     * then returns the current quantity of coins.
     * @param {int} value 
     */
    int Produce (int value)
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
    bool Spend (int value)
    {
        bool spent = false;
        if (value <= 0) 
            return spent;
        if (this.coins >= value)
        {
            //this.coins = System.Math.Floor(this.coins - value);
            spent = true;            
        }
        return spent;
    }
}
