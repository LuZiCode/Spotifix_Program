namespace OOPSpotiflixV2
{
    internal class MainMenu
    {
        Data data = new Data();
        //private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string path = @"C:\Users\lucas\Desktop\SpotifixData.json";
        MovieClass movieClass = new MovieClass();
        MethodsClass methodsClass = new MethodsClass();
        MusicClass musicClass = new MusicClass();
        SeriesClass seriesClass = new SeriesClass();
        public MainMenu()
        {
            //data.MovieList.Add(new Movie() { WWW=@"https:\\netflix.com/rambo3.mp4", Title="Rambo III", Genre ="Action", ReleaseDate=new DateTime(1988,5,25), Length=new DateTime(1,1,1, 1, 42, 0)});
            while (true)
            {
                Menu();
            }
        }

        private void Menu()
        {
            Console.WriteLine("\nMENU\n1 for movies\n2 for series\n3 for music\n4 for save\n5 for load");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    movieClass.MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    seriesClass.SeriesMenu();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    musicClass.MusicMenu();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    methodsClass.SaveData();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    methodsClass.LoadData();
                    break;
                default:
                    break;
            }
        }
    }
}
