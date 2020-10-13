using System;

public class App 
{
    public Game game;
    public HelperManager helperManager { get; set; }
    public AchievementManager achievementManager;
    public int totalAmountOfClicks;
    
    public App()
    {
        Console.WriteLine("App Was Created!");

        game = new Game();
        
        helperManager = new HelperManager();
        helperManager.InitHelpers();

        achievementManager = new AchievementManager();
        achievementManager.InitAchievement();
    }
}