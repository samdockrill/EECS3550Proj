using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    public class Day
    {
        /// <summary>
        /// The calendar date this day object represents
        /// Used to store/load it
        /// </summary>
        string Date = "";

        public List<Food> Foods = new List<Food>();
        Dictionary<string, float> DailyValues = new Dictionary<string, float>();

        void SumDailyNutritionValues()
        {
            //Clear the existing DailyValues dictionary
            DailyValues = new Dictionary<string, float>();

            //For each food being eaten today...
            foreach (Food food in Foods)
            {
                //Go through each substance in it, one by one
                foreach(KeyValuePair<string, float> substance in food.FoodNutrients)
                {
                    //Check if the DailyValues dictionary already has an entry for that substance
                    if(DailyValues.Keys.Contains(substance.Key))
                    {
                        //If so, add this food's amount to the existing total
                        DailyValues[substance.Key] += substance.Value;
                    }
                    else
                    {
                        //If not, create an entry for it and set its value to the value of this food
                        DailyValues.Add(substance.Key, substance.Value);
                    }
                }
            }
        }
    }
}