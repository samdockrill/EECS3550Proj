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
        public Week(int startmonth, int startday)
        {
            month = startmonth;
            day = startday;
        }

        public int month;
        public int day;

        public string StartDate
        {
            get
            {
                return month.ToString() + "/" + day.ToString();
            }
        }

        public string Name = "";

        public List<Day> Days = new List<Day>();
    }
}