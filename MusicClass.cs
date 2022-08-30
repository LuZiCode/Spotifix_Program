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
            Console.WriteLine("\nMUSIC MENU\n1 For list of albums\n2 For search an album\n3 For add a new album");

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
                    AddAlbum();
                    break;
                default:
                    break;
            }
        }
        private void AddAlbum()
        {
            Album album = new Album();
            album.Title = methodsClass.GetString("Album Title: ");
            album.Artist = methodsClass.GetString("Artist: ");
            album.Genre = methodsClass.GetString("Album Genre: ");
            album.Length = methodsClass.GetLength();
            album.ReleaseDate = methodsClass.GetReleaseDate();
            album.WWW = methodsClass.GetString("WWW: ");

            Console.Clear();
            ShowAlbumAndSongs(album, false);
            Console.WriteLine("\nConfirm adding album to list (Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y) data.MusicList.Add(album);

            Console.WriteLine("Would you like to add a new song to the album?");
            while (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                AddSong(album);
                Console.WriteLine("\nAdd another song to album? (Y/N)");
            }
        }

        private void AddSong(Album album)
        {
            Song song = new Song();
            song.Title = methodsClass.GetString("Song Title: ");
            song.Artist = methodsClass.GetInputOrParent(album.Artist, "Artist: ");
            song.Genre = methodsClass.GetInputOrParent(album.Genre, "Genre: ");
            song.ReleaseDate = methodsClass.GetReleaseDate();
            song.Length = methodsClass.GetLength();
            ShowSong(song);
            Console.WriteLine("\nAdd this song to album? (Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                album.Songs.Add(song);
        }

        private void ShowAlbumAndSongs(Album a, bool ShowSongs = false)
        {
            Console.WriteLine($"\nAlbum Title: {a.Title}\nAlbum Artist: {a.Artist}\nAlbum Genre: {a.Genre}\nAlbum Length: {a.GetLength()}\nAlbum Release date: {a.GetReleaseDate()}\nAlbum Web: {a.WWW}");
            if (ShowSongs)
            {
                foreach(Song s in a.Songs)
                {
                    ShowSong(s);
                }
            }
        }
        private void ShowSong(Song s)
        {
            Console.WriteLine($"\nSong Title: {s.Title}\nArtist: {s.Artist}\nSong Genre: {s.Genre}\nSong Release date: {s.GetReleaseDate()}\nSong Length: {s.GetLength()}");
        }


        private void ShowMusicList()
        {
            foreach (Album album in data.MusicList)
            {
                ShowAlbumAndSongs(album, true);
            }
        }
        private void SearchMusic()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            Song song = new Song();
            foreach (Album album in data.MusicList)
            {
                if (search != null)
                {
                    if (album.Artist.Contains(search) || album.Genre.Contains(search) || album.Title.Contains(search) || album.WWW.Contains(search))
                    {
                        ShowAlbumAndSongs(album, false);
                    }
                    if (song.Title.Contains(search) || song.Genre.Contains(search))
                    {
                        ShowAlbumAndSongs(album, true);
                    }
                }
            }
        }

    }
}