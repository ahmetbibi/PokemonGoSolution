using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGo.Data
{
    public class Point
    {
        //public Point()
        //{

        //}
        //public Point(string title, double latidude, double longitude)
        //{
        //    Title = title;
        //    Latitude = latidude;
        //    Longitude = longitude;
        //}

        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:f6}", ApplyFormatInEditMode = true)]
        public double Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:f6}", ApplyFormatInEditMode = true)]
        public double Longitude { get; set; }

        public int? PointTypeId { get; set; }
        public PointType PointType { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        //public string UserId { get; set; }

    }
}
