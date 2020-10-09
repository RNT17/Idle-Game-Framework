using System;
using System.Diagnostics;
using System.Timers;

public class Idlegfw
{
    ResourceManager resourceManager = new ResourceManager();       
    App app;
    bool isUpdating = false;

    private static Timer aTimer;

    event EventHandler OnClickEventEnter;

    public Idlegfw()
    {
        app = new App();

        aTimer = new Timer(1000);
        aTimer.Elapsed += loop;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;

        Console.WriteLine("Press the ENTER key to exit the program at any time... ");
        while (true)
        {
            if(Console.ReadKey(true).KeyChar == 'a')
                Console.WriteLine("Total Production Value: {0} ", app.game.currentProductionValue);
            else if (Console.ReadKey(true).KeyChar == 's')
                Console.WriteLine("Resource Generated Per Click: {0} ", app.game.resourceGeneratedPerClick);
        }
    }

    void loop(object sender, ElapsedEventArgs e)
    {
        Console.Write("Rodando: {0} ", e.SignalTime);
        Console.WriteLine("Coins: " + resourceManager.coins);

        updateLogic();
        app.game.CalculateTotalProductionValue();

    }

    void updateLogic () 
    {
        resourceManager.Produce(app.game.currentProductionValue);
    }

    void OnItemBought(Helper helper)
    {
        if(resourceManager.Spend(helper.buyPrice))
        {
            //app.achievementManager.onNotifyResoucer<ResourceManager>(resourceManager, Event.SpendResource); // spend achievement 
            //app.achievementManager.onNotify(resourceManager, Event.SpendResource);

            if (app.game != null) 
            {
                app.game.helpers.Add(helper);
                helper.OnItemBought(); //adds +1 to quantity and recalculate buyPrice

                //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins); // to display updated info of coins spent        
                //UIManager.UpdateHelpersList(app.helperManager.helpers, app);
                
                //app.achievementManager.onNotify<App>(app, Event.BuyHelper); // buy achievement
            } 
        }
    }

    void PlayAreaOnClick()
    {
        resourceManager.Produce(app.game.resourceGeneratedPerClick);
        //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins);
        app.totalAmountOfClicks++;
    }

    
}