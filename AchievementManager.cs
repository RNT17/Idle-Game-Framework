using System;
using System.Collections.Generic;
public class AchievementManager
{
    List<Achievement> achievements = new List<Achievement>();    

    public void InitAchievement ()
    {
        Console.WriteLine("AchievementManager:InitAchiement()");

        Achievement tenClicks = new Achievement(
            "Wowie! 10 whole clicks!", 
            "You've clicked the big button 10 times. Well done. Well done indeed.", 
            MyEventArs.AmountOfClicks,
            10);

        Achievement fiftyClicks = new Achievement(
            "Wowie! 50 whole clicks!", 
            "You've clicked the big button 50 times. Well done!", 
            MyEventArs.AmountOfClicks,
            50);

        Achievement firstHelperBuy = new Achievement(
            "Nice, you buy a Helper!", 
            "You've buy a nice Helper. Congrat's!", 
            MyEventArs.BuyHelper,
            1);
        
        Achievement moreThenOneHelperBuy = new Achievement(
            "You buy a new Helper!", 
            "You've purchase another Helper!", 
            MyEventArs.BuyHelper,
            10);

        Achievement spendTenResource = new Achievement(
            "Spend 10 in Resource!", 
            "You've Spend a Resource to buy somenthing!", 
            MyEventArs.SpendResource,
            10);

        achievements.Add(tenClicks);
        // achievements.Add(fiftyClicks);
        achievements.Add(firstHelperBuy);
        // achievements.Add(moreThenOneHelperBuy);
        achievements.Add(spendTenResource);
    }

    // TODO: Event Handler
    void  OnNotity()
    {

    }

    private void unlock(Achievement achievement)
    {
        achievement.Unlocked();
    }

}