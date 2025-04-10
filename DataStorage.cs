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
    public static class DataStorage
    {
        public static Dictionary<string, float> DefaultDVs = LoadDefaultDVs();
        public static List<Week> StoredWeeks = new List<Week>();

        public static string storagePath = Environment.CurrentDirectory + "nutriWeek.db";
        public static SqliteConnection db;
        public static void OpenDatabase()
        {
            if (!File.Exists(storagePath))
            {
                try
                {
                    File.Create(storagePath);
                    db = new SqliteConnection($"Filename={storagePath}");
                    db.Open();
                    
                    string createFoodTableString = "CREATE TABLE Foods foodname TEXT PRIMARY KEY, manufacturer TEXT, liquid TEXT, ";
                    for (int i = 0; i < Food.PossibleNutrients.Count(); i++)
                    {
                        createFoodTableString += Food.PossibleNutrients[i] + " INTEGER,";
                    }
                    QueryDB(createFoodTableString);
                    QueryDB("CREATE TABLE Days daydate TEXT PRIMARY KEY, foodname TEXT, meal TEXT");
                    QueryDB("CREATE TABLE Weeks INTEGER weekstartdate PRIMARY KEY, weekname TEXT, day0 TEXT, day1 TEXT, day2 TEXT, day3 TEXT, day4 TEXT, day5 TEXT, day6 TEXT");
                }
                catch
                {
                    Console.WriteLine("FATAL: FAILED TO CREATE DATABASE FILE");
                    Console.ReadLine();
                    System.Environment.Exit(29);
                }                
            }
            else
            {
                db = new SqliteConnection($"Filename={storagePath}");
                db.Open();

                LoadWeeks();
            }

            return;
        }

        public static SqliteDataReader QueryDB(String query)
        {
            return new SqliteCommand(query, db).ExecuteReader();
        }

        public static void CreateCustomFoodDB()
        {
            //product_name
            //quantity
            //PossibleNutrients
            //brands
            //WHERE countries_EN = 'United States'
            //allergens
            //serving_size
            //serving_quantity
            //nutriscore_score
            //product_quantity
            //popularity_tags

            int i = 0;

            List<string> valid = new List<string>();

            using (StreamReader r = new StreamReader("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\db.csv"))
            {
                string l;
                while ((l = r.ReadLine()) != null)
                {
                    i++;
                    if(l.Contains("United States"))
                    {
                        valid.Add(l);
                    }
                }
            }

            using (StreamWriter w = new StreamWriter("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\rawfood.csv"))
            {
                foreach (string s in valid)
                {
                    w.WriteLine(s);
                }
            }
        }


        public static Food LoadFood(string foodName)
        {
            string query = "SELECT manufacturer liquid ";
            for(int i = 0; i < Food.PossibleNutrients.Count(); i++)
            {
                query += Food.PossibleNutrients[i] + " ";
            }
            query += "FROM Foods" +
                     "WHERE foodname = '" + foodName + "'";


            SqliteDataReader response = QueryDB(query);

            Food food = new Food("");

            food.Manufacturuer = response.GetString(1);
            
            if(response.GetBoolean(2))
            {
                food.Units.type = UnitType.liquid;
            }

            for(int i = 3; i < Food.PossibleNutrients.Count(); i++)
            {
                food.FoodNutrients.Add(Food.PossibleNutrients[i - 3], response.GetInt32(i));
            }

            response.Close();

            return food;
        }

        public static void StoreFood(Food food)
        {
            SqliteCommand createTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS Foods", db);
            createTable.ExecuteReader();
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

        public static List<Food> ExampleFoods = new List<Food>()
        {
            new Food("Pancake"),
            new Food("Pizza"),
            new Food("Hamburger"),
            new Food("Waffles"),
            new Food("Burrito"),
            new Food("Steak"),
        };

        public static void LoadWeeks()
        {
            StoredWeeks.Add(new Week("4/7"));
            StoredWeeks.Add(new Week("4/14"));

            Day exampleDay = new Day();
            exampleDay.Foods.Add(ExampleFoods[0]);
            exampleDay.Foods.Add(ExampleFoods[1]);
            exampleDay.Foods.Add(ExampleFoods[2]);
            StoredWeeks[0].Days.Add(exampleDay);

            Day exampleDay2 = new Day();
            exampleDay2.Foods.Add(ExampleFoods[3]);
            exampleDay2.Foods.Add(ExampleFoods[4]);
            exampleDay2.Foods.Add(ExampleFoods[5]);
            StoredWeeks[0].Days.Add(exampleDay2);
        }

        public static Dictionary<string, float> LoadDefaultDVs()
        {
            return new Dictionary<string, float>();
        }

        public static Food NameLookup(string Name)
        {
            return new Food("");
        }
    }
}