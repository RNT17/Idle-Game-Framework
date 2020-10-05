public class Idlegfw
{
    ResourceManager resourceManager = new ResourceManager();

    public Idlegfw()
    {
        Loop();
    }

    void Loop()
    {
        while (true) 
        {
            updateLogic();
            //player.CalculateTotalProductionValue();
        }
    }

    void updateLogic () 
    {
        //resourceManager.Produce(player.currentProductionValue);
    }

    void OnItemBought()
    {

    }

    void PlayAreaOnClick()
    {
        //app.totalAmountOfClicks++;
    }
}