using System;
using System.Timers;

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

        Console.WriteLine("Press the Ctrl + C to exit the program at any time... ");
        while (true) 
        {
            if (Console.ReadKey(true).KeyChar == 'a') {
                OnClickEventEnter?.Invoke(this, EventArgs.Empty);
                OnNotifyAchievement?.Invoke(app, new MyEventArs(MyEventArs.AmountOfClicks, app.totalAmountOfClicks));
            }
            else if (Console.ReadKey(true).KeyChar == 'b')
                OnItemBought(app.helperManager.helpers[0]);
            else if(Console.ReadKey(true).KeyChar == '1')
                Console.WriteLine("Total Production Value: {0} ", app.game.currentProductionValue);
            else if (Console.ReadKey(true).KeyChar == '2')
                Console.WriteLine("Resource Generated Per Click: {0} ", app.game.resourceGeneratedPerClick);
        }
    }

    void FixedUpdate(object sender, ElapsedEventArgs e)
    {
        Console.Write("Rodando: {0} ", e.SignalTime);
        UpdateCoinsCount();

        updateLogic();
        app.game.CalculateTotalProductionValue();
    }

    void updateLogic () 
    {
        resourceManager.Produce(app.game.currentProductionValue);
    }

    void OnItemBought(Helper helper)
    {
        //Console.WriteLine("OnItemBought");
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
        Console.WriteLine("Coins: " + resourceManager.coins);       
    }
    
}