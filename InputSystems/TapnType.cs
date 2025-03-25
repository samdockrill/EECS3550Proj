using NutriWeekMAUI.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeekMAUI.InputSystems
{
    public class TapnType
    {
        /// <summary>
        /// Returns a list of strings containing all foods that match the currently typed input
        /// Could return a list of Food objects instead, potentially? Either one should work fine
        /// </summary>
        /// <returns></returns>
        List<string> GetAutocompleteList(string input)
        {
            List<string> list = new List<string>();

            return list;
        }
    }
}
