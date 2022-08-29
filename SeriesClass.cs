using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSpotiflixV2
{
    internal class SeriesClass
    {
        MethodsClass methodsClass = new MethodsClass();
        Data data = new Data();
        Episode episodeClass = new Episode();
        public void SeriesMenu()
        {
            Console.WriteLine("\nSERIES MENU\n1 For list of series\n2 For search series\n3 For add a new series");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    //ShowSeriesList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    //SearchSeries();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    //AddSeries();
                    break;
                default:
                    break;
            }

            //private void AddSeries()
            //{
            //    Series series = new Series();
            //    series.Title = methodsClass.GetString("Tile of the series: ");
            //    series.Genre = methodsClass.GetString("Genre of the series: ");
            //    series.Length = methodsClass.GetLength();
            //    series.Episodes.Add() = methodsClass.GetIntSeason();

            //    Console.Clear();
            //    ShowMovie(movie);
            //    Console.WriteLine("Confirm adding to list (Y/N)");
            //    if (Console.ReadKey().Key == ConsoleKey.Y) data.MovieList.Add(movie);
            //}
        }
    }
}
