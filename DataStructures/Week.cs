using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    [Serializable]
    public class Week
    {
        /// <summary>
        /// The calendar date this day object represents
        /// Used to store/load it
        /// </summary>
        /// 
        public Week(DateTime startday)
        {
            startDate = startday;
        }

        public DateTime startDate;
        public int month
        {
            get
            {
                return startDate.Month;
            }
        }
        public int day
        {
            get
            {
                return startDate.Day;
            }
        }

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