using NutriWeekMAUI.DataStructures;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace NutriWeekMAUI
{
    public static class Testing
    {
        public static List<Food> ExampleFoods
        {
            get
            {
                List<Food> val = new List<Food>(){
                    new Food("Pancake"),
                    new Food("Pizza"),
                    new Food("Hamburger"),
                    new Food("Waffle"),
                    new Food("Burrito"),
                    new Food("Steak"),
                };

                val[0].FoodNutrients.Add("fat", 1.5f);
                val[0].FoodNutrients.Add("sodium", 530f);
                val[0].FoodNutrients.Add("carbohydrates", 37f);
                val[0].FoodNutrients.Add("proteins", 4f);
                val[0].FoodNutrients.Add("sugars", 6f);
                val[0].FoodNutrients.Add("fiber", 1f);

                val[1].FoodNutrients.Add("fat", 16f);
                val[1].FoodNutrients.Add("cholesterol", 55f);
                val[1].FoodNutrients.Add("sodium", 650f);
                val[1].FoodNutrients.Add("carbohydrates", 49f);
                val[1].FoodNutrients.Add("fiber", 3f);
                val[1].FoodNutrients.Add("sugars", 4f);
                val[1].FoodNutrients.Add("proteins", 13f);

                val[2].FoodNutrients.Add("fat", 27f);
                val[2].FoodNutrients.Add("cholesterol", 87f);
                val[2].FoodNutrients.Add("sodium", 824f);
                val[2].FoodNutrients.Add("carbohydrates", 40f);
                val[2].FoodNutrients.Add("fiber", 0f);
                val[2].FoodNutrients.Add("sugars", 0f);
                val[2].FoodNutrients.Add("proteins", 26f);

                val[3].FoodNutrients.Add("fat", 2.5f);
                val[3].FoodNutrients.Add("cholesterol", 35f);
                val[3].FoodNutrients.Add("sodium", 450f);
                val[3].FoodNutrients.Add("carbohydrates", 87f);
                val[3].FoodNutrients.Add("fiber", 2f);
                val[3].FoodNutrients.Add("sugars", 10f);
                val[3].FoodNutrients.Add("proteins", 8f);

                val[4].FoodNutrients.Add("fat", 28f);
                val[4].FoodNutrients.Add("cholesterol", 100f);
                val[4].FoodNutrients.Add("sodium", 980f);
                val[4].FoodNutrients.Add("carbohydrates", 33f);
                val[4].FoodNutrients.Add("fiber", 20f);
                val[4].FoodNutrients.Add("sugars", 4f);
                val[4].FoodNutrients.Add("proteins", 37f);

                val[5].FoodNutrients.Add("fat", 38f);
                val[5].FoodNutrients.Add("cholesterol", 195f);
                val[5].FoodNutrients.Add("sodium", 230f);
                val[5].FoodNutrients.Add("carbohydrates", 0f);
                val[5].FoodNutrients.Add("fiber", 0f);
                val[5].FoodNutrients.Add("sugars", 0f);
                val[5].FoodNutrients.Add("proteins", 56f);

                return val;
            }
        }

        public static int startingDay = 7;
        public static int startingMonth = 4;
        /// <summary>
        /// Fills the StoredWeeks list with a number of randomly generated weeks for testing
        /// </summary>
        /// <param name="number">The number of weeks to generate. Defaults to 2</param>
        public static void GenerateTestWeeks(int number = 2)
        {
            for(int i = 0; i < number; i++)
            {
                DataStorage.StoredWeeks.Add(GenerateTestWeek(startingMonth, startingDay));
                startingDay += 7;
                if(startingDay > 30)
                {
                    startingDay -= 30;
                    startingMonth++;
                    if(startingMonth > 12)
                    {
                        startingMonth = 0;
                    }
                }
            }
            DataStorage.StoredWeeks.Add(new Week(4, 14));

            Day exampleDay = new Day();
            exampleDay.Foods.Add(Testing.ExampleFoods[0]);
            exampleDay.Foods.Add(Testing.ExampleFoods[1]);
            exampleDay.Foods.Add(Testing.ExampleFoods[2]);
            DataStorage.StoredWeeks[0].Days.Add(exampleDay);

            Day exampleDay2 = new Day();
            exampleDay2.Foods.Add(Testing.ExampleFoods[3]);
            exampleDay2.Foods.Add(Testing.ExampleFoods[4]);
            exampleDay2.Foods.Add(Testing.ExampleFoods[5]);
            DataStorage.StoredWeeks[0].Days.Add(exampleDay2);

            for (int i = 2; i < 7; i++)
            {
                DataStorage.StoredWeeks[0].Days.Add(new Day());
            }

            for (int i = 0; i < 7; i++)
            {
                DataStorage.StoredWeeks[1].Days.Add(new Day());
            }
        }

        /// <summary>
        /// Generates a random Week object full of random Day objects full of random Food for testing
        /// </summary>
        /// <param name="startingMonth">The month the week starts in</param>
        /// <param name="startingDay">The day the week starts on</param>
        /// <returns></returns>
        public static Week GenerateTestWeek(int startingMonth, int startingDay)
        {
            Week exampleWeek = new Week(startingMonth, startingDay);
            for (int i = 0; i < 7; i++)
            {
                exampleWeek.Days.Add(GenerateTestDay());
            }

            return exampleWeek;
        }

        public static Random rand = new Random();

        /// <summary>
        /// Generates a random Day object full of random foods for testing
        /// </summary>
        /// <returns></returns>
        public static Day GenerateTestDay(bool useRandom = false)
        {
            Day exampleDay = new Day();

            for(int i = 0; i < 3; i++)
            {
                if (useRandom)
                {
                    exampleDay.Foods.Add(GenerateTestFood());
                }
                else
                {
                    exampleDay.Foods.Add(ExampleFoods[rand.Next(0, ExampleFoods.Count)]);
                }
            }

            return exampleDay;
        }

        /// <summary>
        /// Generates a random Food object with a random name and random nutrition values for testing
        /// </summary>
        /// <returns></returns>
        public static Food GenerateTestFood()
        {
            Food exampleFood = new Food(GenerateTestString());

            exampleFood.FoodNutrients.Add("fat", (float)(rand.NextDouble() * 32768.0));
            exampleFood.FoodNutrients.Add("cholesterol", (float)(rand.NextDouble() * 32768.0));
            exampleFood.FoodNutrients.Add("sodium", (float)(rand.NextDouble() * 32768.0));
            exampleFood.FoodNutrients.Add("carbohydrates", (float)(rand.NextDouble() * 32768.0));
            exampleFood.FoodNutrients.Add("fiber", (float)(rand.NextDouble() * 32768.0));
            exampleFood.FoodNutrients.Add("sugars", (float)(rand.NextDouble() * 32768.0));
            exampleFood.FoodNutrients.Add("proteins", (float)(rand.NextDouble() * 32768.0));

            return exampleFood;

        }

        public static string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQURSTUVWXYZ1234567890!@#$%^&*()-=_+[]{};:'\"<>,./?\\|`~";
        /// <summary>
        /// Returns a random string of a random length for testing
        /// </summary>
        /// <param name="maxLength">The maximum possible length of the string, default 32</param>
        /// <returns></returns>
        public static string GenerateTestString(int maxLength = 32)
        {
            int length = rand.Next(0, maxLength);
            string s = "";
            for (int i = 0; i < length; i++)
            {
                s += validCharacters[rand.Next(0, validCharacters.Length)];
            }

            return s;
        }
    }
}