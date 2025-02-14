using NutriWeek.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeek
{
    public class DataStorage
    {
        Food LoadFood(string foodName)
        {
            return new Food();
        }

        void StoreFood(Food food)
        {

        }

        /// <summary>
        /// Retrieves a day object, containing a list of foods etc
        /// </summary>
        /// <param name="date">The date of the day you want to load</param>
        Day LoadDay(string date)
        {
            return new Day();
        }

        void StoreDay(Day day)
        {

        }

        /// <summary>
        /// Pull the pre-generated food name tree out of storage
        /// </summary>
        /// <returns></returns>
        NameTree LoadNameTree()
        {
            return new NameTree();
        }

        void StoreNameTree(NameTree tree)
        {

        }

        void LoadDefaultDVs()
        {

        }
    }
}
