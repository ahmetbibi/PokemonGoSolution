using PokemonGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGo.Models
{
    public class PointViewModel
    {

        public PointViewModel(string title, double latidude, double longitude, string type)
        {
            Title = title;
            Latitude = latidude;
            Longitude = longitude;
            Type = type;
        }

        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
    }
}
