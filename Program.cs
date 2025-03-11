using NutriWeek.Views;
using System;

namespace NutriWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();


            //TODO: Code to make the main update loop only run at a fixed rate per second
            //MainUpdateLoop();
        }

        public static View CurrentView = new WeekView();
        static void MainUpdateLoop()
        {
            //Render current view...
            CurrentView.Render();
        }
    }
}