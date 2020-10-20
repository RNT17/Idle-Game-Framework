using System;
public class UiManager
{
    public UiManager()
    {

    }

    public static void ShowOptions()
    {
        Console.WriteLine(
                    "======================\n"+
                    "Coins: {0}\nMax Cois: {1}\nResource Generated Per Click: {2}\nTotal Production Value: {3}\nHelpers: {4}\n"+
                "======================",
            App.Instance.resourceManager.coins,
            App.Instance.resourceManager.maxCoins,
            App.Instance.game.resourceGeneratedPerClick,
            App.Instance.game.currentProductionValue,
            App.Instance.game.helpers.Count
            );
    }

}