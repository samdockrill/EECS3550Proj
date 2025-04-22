using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    [Serializable]
    public class Food
    {
        public Dictionary<string, float> FoodNutrients = new Dictionary<string, float>();
        public string Name = "";
        //public string Manufacturuer = "";
        public string Allergens = "unknown";
        public string Nutriscore = "unknown";
        //public Unit Units = new Unit();

        

        public Food(string foodName)
        {
            Name = foodName;
        }
    }
}
