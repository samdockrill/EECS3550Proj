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
using NutriWeek.DataStructures;
using System.Runtime.Serialization.Formatters.Binary;

namespace NutriWeekMAUI
{
    public static class DataStorage
    {
        public static NameTree FoodNameTree = new NameTree();
        public static Dictionary<string, float> DefaultDVs = LoadDefaultDVs();
        public static List<Week> StoredWeeks = new List<Week>();
        public static List<Food> LoadedFoodData = new List<Food>();

        public static string storagePath = Environment.CurrentDirectory + "nutriWeek.db";
        public static SqliteConnection db;


        public static Dictionary<string, int> NutrientIndicies = new Dictionary<string, int>()
        {
            {"Fat", 92 },
            {"Saturated-Fat", 93 },
            {"Trans-Fat", 127 },
            {"Cholesterol", 128 },
            {"Carbohydrates", 129 },
            {"Sugars", 130 },
            {"Fiber", 141 },
            {"Proteins", 145 },
            {"Sodium", 150 },
            {"Vitamin-A", 153 },
            {"Vitamin-E", 155 },
            {"Vitamin-C", 157 },
            {"Potassium", 169 },
            {"Calcium", 171 },
            {"Phosphorous", 172 },
            {"Iron", 173 },
            {"Magnesium", 174 },
            {"Zinc", 175 },
        };

        public static void LoadProgramData()
        {
            LoadNameTree();

            LoadedFoodData = LoadSerializedData("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\fooddatabase.db") as List<Food>;
            StoredWeeks = LoadSerializedData("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\weeks.db") as List<Week>;
            if (StoredWeeks == null || StoredWeeks.Count() == 0)
            {
                StoredWeeks = new List<Week>();
                StoredWeeks.Add(new Week(DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek)));
                for (int i = 0; i < 7; i++)
                {
                    Day day = new Day();
                    day.Foods.Add(LoadedFoodData[Testing.rand.Next(LoadedFoodData.Count())]);
                    day.Foods.Add(LoadedFoodData[Testing.rand.Next(LoadedFoodData.Count())]);
                    day.Foods.Add(LoadedFoodData[Testing.rand.Next(LoadedFoodData.Count())]);
                    StoredWeeks[0].Days.Add(day);
                }

                SaveSerializedData(StoredWeeks, "C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\weeks.db");

            }
        }

        public static async Task LoadAllFoodDataAsync()
        {
            await Task.Run(() =>
            {
                LoadedFoodData = LoadSerializedData("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\fooddatabase.db") as List<Food>;
            });
        }

        public static async Task StoreAllFoodData()
        {

        }

        public static void ReInitializePregeneratedDatabases()
        {
            //product_name 10
            //quantity 13
            //allergens 45, 49
            //nutriscore_grade 58
            List<string> valid = new List<string>();
            int i = 0;

            using (StreamReader r = new StreamReader("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\rawfood.csv"))
            {
                string l;
                while ((l = r.ReadLine()) != null)
                {
                    i++;
                    if (l.Contains("United States"))
                    {
                        valid.Add(l);
                    }
                }
            }
            
            string[][] data = new string[1000000][];
            for (int j = 0; j < valid.Count(); j++)
            {
                data[j] = valid[j].Split('\t');
            }

            Food[] AllFoodData = new Food[1000000];

            List<string> NNames = NutrientIndicies.Keys.ToList<string>();
            List<int> NInds = NutrientIndicies.Values.ToList<int>();

            List<Food> LoadedFoods = new List<Food>();

            for (int j = 0; j < 1000000; j++)
            {
                if (data[j] != null && data[j][10] != null && data[j][10] != "" && data[j][89] != "")
                {
                    FoodNameTree.Insert(new TreeNode(data[j][10]));
                    Food nFood = new Food(data[j][10]);
                    nFood.Allergens = data[j][45] + data[j][48];
                    nFood.Nutriscore = data[j][58];

                    for (int k = 0; k < NutrientIndicies.Count; k++)
                    {
                        float val = 0;
                        if(float.TryParse(data[j][NInds[k]], out val))
                        {
                            nFood.FoodNutrients.Add(NNames[k], val);
                        }
                    }

                    LoadedFoods.Add(nFood);
                }
            }

            //AllFoodData = LoadedFoods.ToArray();

            SaveSerializedData(LoadedFoods, "C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\fooddatabase.db");


            //List<Food> LoadedFoodData = LoadSerializedData("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\fooddatabase.db") as List<Food>;

            SaveNameTree();            
        }


        /*
            
        
        
        
        
        using (StreamWriter w = new StreamWriter("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\foodnames.txt"))
            {
                for (i = 0; i < 1000000; i++)
                {
                    if (data[i] != null && data[i][10] != null && data[i][10] != "")
                    {
                        w.WriteLine(data[i][10]);
                    }
                }
            }  
        
        
        
        
        
            using (StreamReader r = new StreamReader("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\db.csv"))
            {
                string l;
                while ((l = r.ReadLine()) != null)
                {
                    i++;
                    if (l.Contains("United States"))
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
         */


        public static async Task SaveNameTree()
        {
            await Task.Run(() =>
            {
                SaveSerializedData(FoodNameTree, "C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\nametree.txt");
            });
        }
        public static void LoadNameTree()
        {
            FoodNameTree = LoadSerializedData("C:\\Users\\SamDo\\source\\repos\\NutriWeekMAUI\\nametree.txt") as NameTree;
        }

        /// <summary>
        /// Serializes data structures into raw binary data.
        /// It takes a long time to generate certain things like the name tree, so this lets us save and load the whole thing instead of regenerating it
        /// </summary>
        public static void SaveSerializedData(object o, string path)
        {
            //https://i.imgflip.com/57mxr1.png
#pragma warning disable SYSLIB0011
            System.AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);
            try
            {
                using (StreamWriter r = new StreamWriter(path))
                {
                    MemoryStream ms = new MemoryStream();
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(r.BaseStream, o);
                }
            }
            catch
            {
                Console.WriteLine("ERROR: COULD NOT WRITE TO FILE!");
            }

#pragma warning restore SYSLIB0011
        }

        public static object LoadSerializedData(string path)
        {
#pragma warning disable SYSLIB0011
            System.AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);

            //Loads the serialized name tree data
            using (StreamReader r = new StreamReader(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(r.BaseStream);
            }

#pragma warning restore SYSLIB0011
        }

        //Full 'unsafe' binary serialization is the only practical approach to saving and loading an absolutely massive (700k entries) tree structure efficiently
        //JSON, XML, and other stupid nonsense that requires setting up a bunch of Attributes is automatically and permanently disqualified
        //If users want to inject executable code into their own custom food names to use locally in their own copy of the app, they can go right ahead

        /*
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
        }*/

        /// <summary>
        /// Get the full Food object with all extra data based on a given food name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Food NameLookup(string Name)
        {
            for(int i = 0; i < LoadedFoodData.Count; i++)
            {
                if(LoadedFoodData[i].Name == Name)
                {
                    return LoadedFoodData[i];
                }
            }

            return null;
        }

        public static Dictionary<string, float> LoadDefaultDVs()
        {
            return new Dictionary<string, float>()
            {
                { "Fat", 65 },
                {"Saturated-Fat", 20 },
                {"Trans-Fat", 20 },
                {"Cholesterol", 300 },
                {"Carbohydrates", 300 },
                {"Sugars", 120 },
                {"Fiber", 25 },
                {"Proteins", 50 },
                {"Sodium", 2400 },
                {"Vitamin-a", 1000 },
                {"Vitamin-e", 10 },
                {"Vitamin-c", 60 },
                {"Potassium", 3500 },
                {"Calcium", 750 },
                {"Phosphorous", 700 },
                {"Iron", 10 },
                {"Magnesium", 300 },
                {"Zinc", 10 },
            };
        }

        /*
         
          { "Fat", 92 },
            {"Saturated-Fat", 93 },
            {"Trans-Fat", 127 },
            {"Cholesterol", 128 },
            {"Carbohydrates", 129 },
            {"Sugars", 130 },
            {"Fiber", 141 },
            {"Proteins", 145 },
            {"Sodium", 150 },
            {"Vitamin-a", 153 },
            {"Vitamin-e", 155 },
            {"Vitamin-c", 157 },
            {"Potassium", 169 },
            {"Calcium", 171 },
            {"Phosphorous", 172 },
            {"Iron", 173 },
            {"Magnesium", 174 },
            {"Zinc", 175 },
         
         
         */
    }
}