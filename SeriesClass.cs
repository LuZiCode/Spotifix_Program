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
        public void SeriesMenu()
        {
            Console.WriteLine("\nSERIES MENU\n1 For list of series\n2 For search series\n3 For add a new series");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowSeriesList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchSeries();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddSeries();
                    break;
                default:
                    break;
            }
        }

        private void AddSeries()
        {
            Series series = new Series();
            series.Title = methodsClass.GetString("Series Title: ");
            series.Genre = methodsClass.GetString("Series Genre: ");
            series.Length = methodsClass.GetLength();
            series.ReleaseDate = methodsClass.GetReleaseDate();
            series.WWW = methodsClass.GetString("WWW: ");

            Console.Clear();
            ShowSeriesAndEpisodes(series, false);
            Console.WriteLine("\nConfirm adding series to list (Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y) data.SeriesList.Add(series);

            Console.WriteLine("Would you like to add a new episode to the series?");
            while (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                AddEpisode(series);
                Console.WriteLine("\nAdd another episode to series? (Y/N)");
            }
        }
        private void ShowSeriesAndEpisodes(Series series, bool ShowEpisodes = false)
        {
            Console.WriteLine($"\nSeries Title: {series.Title}\nSeries Genre: {series.Genre}\nSeries Length: {series.GetLength()}\nSeries Release date: {series.GetReleaseDate()}\nSeries Web: {series.WWW}");
            if (ShowEpisodes)
            {
                foreach (Episode e in series.Episodes)
                {
                    ShowEpisode(e);
                }
            }
        }
        private void ShowEpisode(Episode e)
        {
            Console.WriteLine($"\nEpisode Title: {e.Title}\nEpisode Genre: {e.Genre}\nEpisode Release date: {e.GetReleaseDate()}\nEpisode Length: {e.GetLength()}");
        }
        private void AddEpisode(Series series)
        {
            Episode episode = new();
            episode.Title = methodsClass.GetString("Title: ");
            episode.Season = methodsClass.GetInt("Season: ");
            episode.EpisodeNum = methodsClass.GetInt("Episode number: ");
            episode.Length = methodsClass.GetLength();
            episode.ReleaseDate = methodsClass.GetReleaseDate();

            Console.Clear();
            ShowEpisode(episode);
            Console.WriteLine("Add episode (Y/N)?");
            if (Console.ReadKey().Key == ConsoleKey.Y) series.Episodes.Add(episode);
        }
        private void ShowSeriesList()
        {
            foreach (Series s in data.SeriesList)
            {
                ShowSeriesAndEpisodes(s, true);
            }
        }
        private void SearchSeries()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            Episode episode = new();
            foreach (Series series in data.SeriesList)
            {
                if (search != null)
                {
                    if (series.Genre.Contains(search) || series.Title.Contains(search) || series.WWW.Contains(search))
                    {
                        ShowSeriesAndEpisodes(series, false);
                    }
                    if (episode.Title.Contains(search) || episode.Genre.Contains(search))
                    {
                        ShowSeriesAndEpisodes(series, true);
                    }
                }
            }
        }
    }
}
