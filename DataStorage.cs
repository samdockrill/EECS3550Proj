using NutriWeekMAUI.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI
{
    public static class DataStorage
    {
        public static NutritionData DefaultDVs = LoadDefaultDVs();
        public static Food LoadFood(string foodName)
        {
            return new Food();
        }

        public static void StoreFood(Food food)
        {

        }

        /// <summary>
        /// Retrieves a day object, containing a list of foods etc
        /// </summary>
        /// <param name="date">The date of the day you want to load</param>
        public static Day LoadDay(string date)
        {
            return new Day();
        }

        public static void StoreDay(Day day)
        {

        }

        /// <summary>
        /// Pull the pre-generated food name tree out of storage
        /// </summary>
        /// <returns></returns>
        public static void LoadNameTree()
        {

        }

        public static void StoreNameTree()
        {

        }

        public static NutritionData LoadDefaultDVs()
        {
            return new NutritionData();
        }
    }
}
