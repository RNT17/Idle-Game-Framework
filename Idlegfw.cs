using System;
using System.Diagnostics;

public class Idlegfw
{
    ResourceManager resourceManager = new ResourceManager();
    App app;
    bool isUpdating = false;

    public Idlegfw()
    {
        app = new App();
        loop();
    }

    void loop()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        while (sw.Elapsed < TimeSpan.FromSeconds(1)) 
        {
            updateLogic();
            app.game.CalculateTotalProductionValue();
        }
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
        resourceManager.Produce(app.game.productionValue);
        //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins);
        app.totalAmountOfClicks++;
    }
}