using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSpotiflixV2
{
    public class MovieClass
    {
        Data data = new Data();
        MethodsClass methods = new MethodsClass();
        public void MovieMenu()
        {
            Console.WriteLine("\nMOVIE MENU\n1 for list of movies\n2 for search movies\n3 for add new movie");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMovieList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchMovie();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddMovie();
                    break;
                default:
                    break;
            }
        }
        private void AddMovie()
        {
            MoviePropertys movie = new MoviePropertys();
            movie.Title = methods.GetString("Title: ");
            movie.Length = methods.GetLength();
            movie.Genre = methods.GetString("Genre: ");
            movie.ReleaseDate = methods.GetReleaseDate();
            movie.WWW = methods.GetString("WWW: ");

            Console.Clear();
            ShowMovie(movie);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.MovieList.Add(movie);
        }
        private void ShowMovie(MoviePropertys m)
        {
            Console.WriteLine($"Title: {m.Title}\nGenre: {m.Genre}\nLength: {m.GetLength()}\nRelease Date: {m.GetReleaseDate()}\nWeb: {m.WWW}");
        }

        private void ShowMovieList()
        {
            foreach (MoviePropertys m in data.MovieList)
            {
                ShowMovie(m);
            }
        }
        private void SearchMovie()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (MoviePropertys movie in data.MovieList)
            {
                if (search != null)
                {
                    if (movie.Title.Contains(search) || movie.Genre.Contains(search))
                        ShowMovie(movie);
                }
            }
        }
    }
}
