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
            "You buy 10 Helper's!", 
            "You've got 10 Helper's. That's awelsome!", 
            MyEventArs.BuyHelper,
            10);

        Achievement spendTenResource = new Achievement(
            "Spend 10 in Resource!", 
            "You've Spend a Resource to buy somenthing!", 
            MyEventArs.SpendResource,
            10);

        achievements.Add(tenClicks);
        achievements.Add(fiftyClicks);
        achievements.Add(firstHelperBuy);
        achievements.Add(moreThenOneHelperBuy);
        achievements.Add(spendTenResource);
    }

    // TODO: Event Handler
    public void OnNotity(object sender, MyEventArs e)
    {
        Console.WriteLine("Sender: {0} \nMyEventsArgs: {1} ", sender.GetType().ToString(), e.GetType().ToString());
        Unlock(ValidateAchievement(e));
    }

    // TODO: verificar se conquista é válida
    // 1 - Existe na lista de conquista cadastrada
    // 2 - Quantidade é a mesma de conquisata cadastrada
    Achievement ValidateAchievement(MyEventArs e)
    {
        foreach (var achievement in achievements)
        {
            //Console.WriteLine("Evento: {0}\nQuantity: {1}", e.Evento, e.Quantity);
            if (achievement.Evento == e.Evento && achievement.Quantity == e.Quantity)
                return achievement;
        }
        return null;
    }

    private void Unlock(Achievement achievement)
    {
        achievement?.Unlocked();
    }
}