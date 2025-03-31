using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    public class Food
    {
        public static List<string> PossibleNutrients = new List<string>()
        {
             //for example
            "Sugar",
            "Carbs",
            "Fat",
            "Sodium" //etc
        };

        public Dictionary<string, float> FoodNutrients = new Dictionary<string, float>();
        public string Name = "";
        public string Manufacturuer = "";
        public Unit Units = new Unit();


        public Food()
        {

        }
    }
}
