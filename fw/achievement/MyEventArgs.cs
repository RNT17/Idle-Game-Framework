public class MyEventArs 
{
    public readonly static int AmountOfClicks = 0;
    public readonly static int BuyHelper = 1;
    public readonly static int SpendResource = 2;

    public MyEventArs(int type, int quantity)
    {   
        this.Type = type;
        this.Quantity = quantity;
    }

    public int Type {get;}
    public int Quantity {get;}
}