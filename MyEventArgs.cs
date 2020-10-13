public class MyEventArs 
{
    public readonly static int AmountOfClicks = 0;
    public readonly static int BuyHelper = 1;
    public readonly static int SpendResource = 2;

    public MyEventArs(int evento, int quantity)
    {   
        this.Evento = evento;
        this.Quantity = quantity;
    }

    public int Evento {get;}
    public int Quantity {get;}
}