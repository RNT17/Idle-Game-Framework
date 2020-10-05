using System.Collections.Generic;

public class HelperManager
{
    int currentProductionValue = 0;
    private List<Helper> helpers;
    
    public void InitHelpers()
    {
        
    }

    int CalculateTotalProductionValue ()
    {
        return this.currentProductionValue;    
    }
}