using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSpotiflixV2
{
    public class MusicClass
    {
        MethodsClass methodsClass = new MethodsClass();
        Data data = new Data();
        public void MusicMenu()
        {
            Console.WriteLine("\nMUSIC MENU\n1 For list of songs\n2 For search songs\n3 For add a new song");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMusicList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchMusic();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddMusic();
                    break;
                default:
                    break;
            }
        }
        private void AddMusic()
        {
            MusicPropertys music = new MusicPropertys();
            music.Title = methodsClass.GetString("Title: ");
            music.Artist = methodsClass.GetString("Artist: ");
            music.Genre = methodsClass.GetString("Genre: ");
            music.Album = methodsClass.GetString("Album: ");
            music.Length = methodsClass.GetLength();
            music.ReleaseDate = methodsClass.GetReleaseDate();
            music.WWW = methodsClass.GetString("WWW: ");

            Console.Clear();
            ShowMusic(music);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.MusicList.Add(music);
        }
        private void ShowMusic(MusicPropertys m)
        {
            Console.WriteLine($"Title: {m.Title}\nArtist: {m.Artist}\nGenre: {m.Genre}\nAlbum: {m.Album}\nLength: {m.GetLength()}\nRelease date: {m.GetReleaseDate()}\nWeb: {m.WWW}");
        }


        private void ShowMusicList()
        {
            foreach (MusicPropertys m in data.MusicList)
            {
                ShowMusic(m);
            }
        }
        private void SearchMusic()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (MusicPropertys music in data.MusicList)
            {
                if (search != null)
                {
                    if (music.Title.Contains(search) || music.Genre.Contains(search) || music.Album.Contains(search) || music.Artist.Contains(search))
                        ShowMusic(music);
                }
            }
        }
    }
}
