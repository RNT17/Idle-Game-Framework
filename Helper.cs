public class Helper 
{
        private string name = "unnamed helper";
        private string description = "Generic helper that produces resources";
        private int baseCost = 10; //how much it costs initially
        private int productionValue = 1; //how much it produces after each iteration
        private int buyPrice = 10; //baseCost;
        private bool isUnique = false;        
        private int level = 1;
        private int quantity = 0;

        public Helper(string name, string description, int baseCost, int productionValue)
        {
            
        }

        void OnItemBought ()
        {

        }

        int CalculatePrice ()
        {
            return 0;
        }
}