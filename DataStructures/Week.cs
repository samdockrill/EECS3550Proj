using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    public class Week
    {
        /// <summary>
        /// The calendar date this day object represents
        /// Used to store/load it
        /// </summary>
        /// 
        public Week(string date)
        {
            StartDate = date;
        }

        public string StartDate = "";
        public string Name = "";

        public List<Day> Days = new List<Day>();
    }
}