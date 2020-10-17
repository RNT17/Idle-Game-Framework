using System;
using System.Timers;
using System.Collections.Generic;

/**
    Classe responsável por manipular e disparar eventos

    Entradas para visuazação de ações:
    Use: a to Produce Currencies.
    Use: b to buy a Helper.
    Use: 1 to see Stats.
    Use: 2 to see Helpers to buy.
    Use: 3 to see Upgrade from a específic Helper

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

        UserInput();
    }

    void UserInput()
    {
        Console.WriteLine("Press the Ctrl + C to exit the program at any time or h to see helper... ");
        while (true) 
        {
            if (Console.ReadKey(true).KeyChar == 'a') {
                OnClickEventEnter?.Invoke(this, EventArgs.Empty);
                OnNotifyAchievement?.Invoke(app, new MyEventArs(MyEventArs.AmountOfClicks, app.totalAmountOfClicks));
            }

            else if (Console.ReadKey(true).KeyChar == 'b')
                BuyAHelper();

            else if (Console.ReadKey(true).KeyChar == 'h')
                Console.WriteLine(
                    "Use: a to Produce Currencies.\n" +
                    "Use: b to buy a Helper.\n" +
                    "Use: 1 to see Stats\n" +
                    "Use: 2 to see Helpers to by\n" 
                );

            else if (Console.ReadKey(true).KeyChar == '1')
                Console.WriteLine(
                    "======================\n"+
                    "Coins: {0}\nMax Cois: {1}\nResource Generated Per Click: {2}\nTotal Production Value: {3}\nHelpers: {4}\n"+
                    "======================",
                resourceManager.coins,
                resourceManager.maxCoins,
                app.game.resourceGeneratedPerClick,
                app.game.currentProductionValue,
                app.game.helpers.Count
                );

            else if (Console.ReadKey(true).KeyChar == '2')               
                app.helperManager.DebugerHelpers();

            else if (Console.ReadKey(true).KeyChar == '3')
                BuyAUpgrade();

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
    
    /**
        Metodo responsável por fazer upgrade em helper
        Se existir recurso suficiente, chamar OnUpgrade em Helper.
    */
    void OnUpgrade(Helper helper)
    {
        if(resourceManager.Spend(helper.upgrade.buyCost))
        {
            helper.OnUpgrade(helper.upgrade);
        }
    }

    // ============== metodos temporarios para seguir o fluxo
    void BuyAHelper()
    {
        Console.WriteLine("Choose a helper:");

        ConsoleKeyInfo UserInput = Console.ReadKey();
        int helperId = int.Parse(UserInput.KeyChar.ToString());

        Console.WriteLine(helperId);
        //if (app.helperManager.helpers.Count > 0)
        if (!app.game.HasHelperWithId(helperId))
            this.OnItemBought(app.helperManager.helpers[helperId]);
    }

    void BuyAUpgrade()
    {
        Console.WriteLine("Chosse a helper to upgrade:");

        ConsoleKeyInfo UserInput = Console.ReadKey();
        int helperId = int.Parse(UserInput.KeyChar.ToString());
        
        //Console.WriteLine("HelperId: {0}\nHelpers List Count: {1}", helperId, app.game.helpers.Count);

        Helper helper = app.game.helpers[helperId];

        if (helper == null) {
            Console.WriteLine("No Helper Found!");
            return;
        }
        
        //h.upgrade.DebugUpgrade();                
        this.OnUpgrade(helper);
    }

    // =============

}