using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSpotiflixV2
{
    public class MethodsClass
    {
        Data data = new Data();
        private string path = @"C:\Users\lucas\source\repos\SpotiflixData.json";
        public string GetString(string type)
        {
            string? input;
            do
            {
                Console.Write(type);
                input = Console.ReadLine();
            }
            while (input == null || input == "");
            return input;
        }

        public int GetIntSeason()
        {
            int input;
            do
            {
                Console.Write("Amount of seasons: ");
            } while (!int.TryParse(Console.ReadLine(), out input) || input <= 0);
            return input;
        }
        public int GetIntEpisode()
        {
            int input;
            do
            {
                Console.Write("Amount of episodes: ");
            } while (!int.TryParse(Console.ReadLine(), out input) || input <= 0);
            return input;
        }

        public DateTime GetLength()
        {
            DateTime time;
            do
            {
                Console.Write("Length (hh:mm:ss): ");
            }
            while (!DateTime.TryParse("0001-01-01 " + Console.ReadLine(), out time));
            return time;
        }
        public DateTime GetReleaseDate()
        {
            DateTime date;
            do
            {
                Console.Write("Release Date (dd/mm/yyyy): ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out date));
            return date;
        }
        public void SaveData()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
            Console.WriteLine("File saved succesfully at " + path);
        }

        public void LoadData()
        {
            string json = File.ReadAllText(path);
            //TODO Does File Exists?
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }
    }
}
