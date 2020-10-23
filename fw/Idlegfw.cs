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
   
    App app = App.Instance;
    
    private static Timer aTimer;

    event EventHandler OnClickEventEnter;

    event EventHandler<MyEventArs> OnNotifyAchievement;

    public Idlegfw()
    {
        aTimer = new Timer(1000);
        aTimer.Elapsed += FixedUpdate;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;

        OnClickEventEnter += PlayAreaOnClick;
        OnNotifyAchievement += app.achievementManager.OnNotity;

        UserInput();
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
        app.resourceManager.Produce(app.game.currentProductionValue);
    }

    void OnItemBought(Helper helper)
    {
        if(app.resourceManager.Spend(helper.buyPrice))
        {
            OnNotifyAchievement?.Invoke(app.resourceManager, new MyEventArs(MyEventArs.SpendResource, helper.buyPrice)); // Spend Resource

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
        app.resourceManager.Produce(app.game.resourceGeneratedPerClick);
        app.totalAmountOfClicks++;       
        UpdateCoinsCount();
    }

    void UpdateCoinsCount()
    {
        //UIManager.UpdateCoinsCount(resourceManager.coins, resourceManager.maxCoins);
        Console.WriteLine("Coins: {0} | Clicks: {1} ", app.resourceManager.coins, app.totalAmountOfClicks);       
    }
    
    /**
        Metodo responsável por fazer upgrade em helper
        Se existir recurso suficiente, chamar OnUpgrade em Helper.
    */
    void OnUpgrade(Helper helper)
    {
        if(app.resourceManager.Spend(helper.upgrade.buyCost))
        {
            helper.OnUpgrade(helper.upgrade);
        }
    }

    
    // ==== Métodos não fixos ou que podem deixar de existir ==== //

    void UserInput()
    {
        ConsoleKeyInfo cki;
        // Prevent example from ending if CTL+C is pressed.
        Console.TreatControlCAsInput = true;

        Console.WriteLine("\nType h to Help.");
        Console.WriteLine("Press the Escape (Esc) key to quit: \n");
        
        do 
        {
            cki = Console.ReadKey();

            string ch = cki.Key.ToString(); 
            
            if (ch == "A") {
                OnClickEventEnter?.Invoke(this, EventArgs.Empty);
                OnNotifyAchievement?.Invoke(app, new MyEventArs(MyEventArs.AmountOfClicks, app.totalAmountOfClicks));
            }
            else if (ch == "B")
                BuyAHelper();
            else if (ch == "H")
                UiManager.Status();
            else if (ch == "D1")
                UiManager.ShowOptions();
            else if (ch == "D2")               
                app.helperManager.DebugerHelpers();
            else if (ch == "D3")
                BuyAUpgrade();           

        } while (cki.Key != ConsoleKey.Escape);
    }

    void BuyAHelper()
    {
        Console.WriteLine("Choose a helper:");
        app.helperManager.DebugerHelpers(true);

        ConsoleKeyInfo UserInput = Console.ReadKey();
        int helperId = int.Parse(UserInput.KeyChar.ToString());

        if (app.helperManager.HasHelperWithId(helperId))
            this.OnItemBought(app.helperManager.HelperById(helperId));
        else 
            Console.WriteLine("No Helper with this id ({0})", helperId);
    }

    void BuyAUpgrade()
    {
        Console.WriteLine("Chosse a helper to upgrade:");

        // Listar Helpers com Id

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