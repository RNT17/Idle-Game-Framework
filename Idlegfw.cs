using System;
using System.Timers;

/**
    Classe responsável por manipular e disparar eventos

    Entradas para visuazação de ações:
    Use: a to Produce Currencies.
    Use: b to buy a Helper.
    Use: 1 to see Stats.
    Use: 2 to see Helpers active.

**/

public class Idlegfw
{
    ResourceManager resourceManager = new ResourceManager();       
    
    App app;
    
    // bool isUpdating = false;

    private static Timer aTimer;

    event EventHandler OnClickEventEnter;

    event EventHandler<MyEventArs> OnNotifyAchievement;

    public Idlegfw()
    {
        app = new App();

        aTimer = new Timer(1000);
        aTimer.Elapsed += FixedUpdate;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;

        OnClickEventEnter += PlayAreaOnClick;
        OnNotifyAchievement += app.achievementManager.OnNotity;

        Console.WriteLine("Press the Ctrl + C to exit the program at any time or h to see helper... ");
        while (true) 
        {
            if (Console.ReadKey(true).KeyChar == 'a') {
                OnClickEventEnter?.Invoke(this, EventArgs.Empty);
                OnNotifyAchievement?.Invoke(app, new MyEventArs(MyEventArs.AmountOfClicks, app.totalAmountOfClicks));
            }

            else if (Console.ReadKey(true).KeyChar == 'b')
                OnItemBought(app.helperManager.helpers[0]);

            else if (Console.ReadKey(true).KeyChar == 'h')
                Console.WriteLine(
                    "Use: a to Produce Currencies.\n" +
                    "Use: b to buy a Helper.\n" +
                    "Use: 1 to see Stats\n" +
                    "Use: 2 to see Helpers to by."
                );

            else if (Console.ReadKey(true).KeyChar == '1')
                Console.WriteLine(
                    "======================\n"+
                    "Coins: {0}\nMax Cois: {1}\nResource Generated Per Click: {2}\nTotal Production Value: {3}\nHelpers: {4}\n"+
                    "======================",
                resourceManager.coins,
                resourceManager.maxCoins,
                app.game.currentProductionValue,
                app.game.resourceGeneratedPerClick,
                app.game.helpers.Count
                );

            else if (Console.ReadKey(true).KeyChar == '2')               
                app.helperManager.DebugerHelpers();
        }
    }

    void FixedUpdate(object sender, ElapsedEventArgs e)
    {
        //Console.Write("Rodando: {0} ", e.SignalTime);

        updateLogic();
        app.game.CalculateTotalProductionValue();
        //UpdateCoinsCount();
    }

    void updateLogic () 
    {
        resourceManager.Produce(app.game.currentProductionValue);
    }

    void OnItemBought(Helper helper)
    {
        if(resourceManager.Spend(helper.buyPrice))
        {
            OnNotifyAchievement?.Invoke(resourceManager, new MyEventArs(MyEventArs.SpendResource, helper.buyPrice)); // Spend Resource

            if (app.game != null) 
            {
                app.game.helpers.Add(helper);
                helper.OnItemBought(); //adds +1 to quantity and recalculate buyPrice

                //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins); // to display updated info of coins spent        
                UpdateCoinsCount();
                //UIManager.UpdateHelpersList(app.helperManager.helpers, app);
                
                OnNotifyAchievement?.Invoke(app, new MyEventArs(MyEventArs.BuyHelper, app.game.helpers.Count)); // buy Helper
            } 
        }
    }

    void PlayAreaOnClick(object sender, EventArgs e)
    {
        resourceManager.Produce(app.game.resourceGeneratedPerClick);
        app.totalAmountOfClicks++;       
        UpdateCoinsCount();
    }

    void UpdateCoinsCount()
    {
        //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins);
        Console.WriteLine("Coins: {0} | Clicks: {1} ", resourceManager.coins, app.totalAmountOfClicks);       
    }
    
}