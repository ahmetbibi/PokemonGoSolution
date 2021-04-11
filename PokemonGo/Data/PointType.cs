using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGo.Data
{
    public class PointType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}
