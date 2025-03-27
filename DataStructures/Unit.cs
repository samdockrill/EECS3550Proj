using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.DataStructures
{
    public class Unit
    {
        static Dictionary<Prefix, double> conversion = new Dictionary<Prefix, double>
        {
            { Prefix.kilo, 1000 },
            { Prefix.unit, 1 },
            { Prefix.milli, 0.001 },
            { Prefix.micro, 0.000001 },
            { Prefix.nano, 0.000000001 },
        };

        UnitType type;
        double amount;

        /// <summary>
        /// Converts between units
        /// </summary>
        /// <param name="siprefix"></param>
        /// <returns></returns>
        double ConvertUnit(Prefix siprefix)
        {
            return conversion[siprefix] / amount;
        }
    }

    enum UnitType
    {
        solid,
        liquid
    }
    
    enum Prefix
    {
        kilo,
        unit,
        milli,
        micro,
        nano
    }
}
