using NutriWeekMAUI.DataStructures;
using Microsoft.Data.SqlClient;
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

        static SqlConnection? connection = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
        public static string storagePath = Environment.CurrentDirectory;
        public static void ConnectToDatabase()
        {
            SqlConnectionStringBuilder? builder = new()
            {
                DataSource = "tbd",
                UserID = "username",
                Password = "password",
                InitialCatalog = "database"
            };

            String? connectionString = builder.ConnectionString;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (SqlException e) when (e.Number == /* database doesn't exist */ 1)
            {
                String createDatabaseString = "CREATE DATABASE MyDatabase ON PRIMARY " +
                             "(NAME = MyDatabase_Data, " +
                             "FILENAME = '" + storagePath + "MyDatabaseData.mdf', " +
                             "SIZE = 2MB, MAXSIZE = 100MB, FILEGROWTH = 10%)" +
                             "LOG ON (NAME = MyDatabase_Log, " +
                             "FILENAME = '" + storagePath + "MyDatabaseLog.ldf', " +
                             "SIZE = 1MB, " +
                             "MAXSIZE = 5MB, " +
                             "FILEGROWTH = 10%)";

                SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseString, connection);

                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                {
                    throw new Exception("connection failed!!");
                }

                connection.Open();
                createDatabaseCommand.ExecuteNonQuery();
                Console.WriteLine("Database is Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static SqlDataReader QueryDatabase(String query)
        {
            if(connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                return sqlCommand.ExecuteReader();
            }
            else
            {
                Console.WriteLine("oof");
            }

            return null;
        }

        

        public static Food LoadFood(string foodName)
        {
            string query = "SELECT Manufacturer Liquid ";
            for(int i = 0; i < Food.PossibleNutrients.Count(); i++)
            {
                query += Food.PossibleNutrients[i] + " ";
            }
            query += "FROM Foods" +
                     "WHERE Name = '" + foodName + "'";


            SqlDataReader response = QueryDatabase(query);

            Food food = new Food();

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

        public static Dictionary<string, float> LoadDefaultDVs()
        {
            return new Dictionary<string, float>();
        }

        public static Food NameLookup(string Name)
        {
            return new Food();
        }
    }
}