using System;
using System.Diagnostics;
using System.Timers;

public class Idlegfw
{
    ResourceManager resourceManager = new ResourceManager();
    
    App app;
    bool isUpdating = false;

    private static System.Timers.Timer aTimer;

    public Idlegfw()
    {
        app = new App();

        aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += loop;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;

        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();
    }

    void loop(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Rodando: "+ e.SignalTime);
        updateLogic();
        app.game.CalculateTotalProductionValue();
    }

    void updateLogic () 
    {
        //resourceManager.Produce(app.game.currentProductionValue);
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

    // void PlayAreaOnClick()
    // {
    //     //resourceManager.Produce(app.game.resourceGeneratedPerClick);
    //     //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins);
    //     app.totalAmountOfClicks++;
    // }

}