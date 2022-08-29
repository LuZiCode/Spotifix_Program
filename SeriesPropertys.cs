using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSpotiflixV2
{
    internal class Series
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Length { get; set; }
        public List<Episode> Episodes { get; set; } = new();
        public string GetLength()
        {
            return Length.ToString("hh:mm:ss");
        }
        public string GetReleaseDate()
        {
            return ReleaseDate.ToString("D");
        }
    }
    internal class Episode
    {
        public string? Title { get; set; }
        public int Season { get; set; }
        public int EpisodeNum { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Length { get; set; }
    }
}
