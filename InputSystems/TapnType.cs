using NutriWeek.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NutriWeekMAUI.InputSystems
{
    public class TapnType
    {
        /// <summary>
        /// Returns a list of strings containing all foods that match the currently typed input
        /// Could return a list of Food objects instead, potentially? Either one should work fine
        /// </summary>
        /// <returns></returns>
        
        public static List<string> GetAutocompleteList(string input)
        {
            TreeNode Cur = NameTree.Root;
            TreeNode FirstNode = null;
            List<string> AutoCompleteList = new List<string>();

            if (input.Length < 4)
            {
                while (Cur != null)
                {
                    if (input[0].CompareTo(Cur.FoodName[0]) < 0) Cur = Cur.Left;
                    else if (input[0].CompareTo(Cur.FoodName[0]) > 0) Cur = Cur.Right;
                    else
                    {
                        if (input.Length <= Cur.FoodName.Length)
                        {
                            for (int i = 0; i < input.Length; i++)
                            {
                                if (input[i].CompareTo(Cur.FoodName[i]) != 0) break;
                                if (input[i].CompareTo(Cur.FoodName[i]) == 0 && i == (input.Length - 1)) AutoCompleteList.Add(Cur.FoodName);
                            }
                        }
                        Cur = Cur.Middle;
                    }
                }

            }
            else
            {
                while (Cur != null) // Goes through the root (middle) and left half of the tree.
                {
                    if (Cur.Parent == null) FirstNode = NameTree.Root;
                    else if (Cur.FoodName[0].CompareTo(Cur.Parent.FoodName[0]) != 0) FirstNode = Cur;

                    if (Cur.FoodName.Contains(input)) AutoCompleteList.Add(Cur.FoodName);

                    if (Cur.Middle != null) Cur = Cur.Middle;
                    else Cur = FirstNode.Left;
                }

                Cur = NameTree.Root.Right;
                FirstNode = null;
                while (Cur != null) // Goes through the right half of the tree.
                {
                    if (Cur.Parent == null) FirstNode = NameTree.Root;
                    else if (Cur.FoodName[0].CompareTo(Cur.Parent.FoodName[0]) != 0) FirstNode = Cur;

                    if (Cur.FoodName.Contains(input)) AutoCompleteList.Add(Cur.FoodName);

                    if (Cur.Middle != null) Cur = Cur.Middle;

                    else Cur = FirstNode.Right;
                }
            }

            return AutoCompleteList;
    }
    }
}
