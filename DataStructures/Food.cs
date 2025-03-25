using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    public class Food
    {
        public NutritionData FoodData = new NutritionData();
        public string Name = "";
        public string Manufacturuer = "";
        public Unit Units = new Unit();
    }
}
