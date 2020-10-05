using System;

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
            this.name = name;
            this.description = description;
            this.baseCost = baseCost;
            this.productionValue = productionValue;
        }

        void OnItemBought ()
        {
            this.quantity++;
            this.buyPrice = this.CalculatePrice();
        }

        int CalculatePrice ()
        {
            if (this.quantity == 0)
                return this.baseCost;
            var multiplier = 1.09; //TODO: Move this to a global            
            var price = this.baseCost * Math.Pow(multiplier, this.quantity);
            
            //return Math.Ceiling(price); //The Math.ceil() function returns the smallest integer greater than or equal to a given number.
            return 0;
        }
}