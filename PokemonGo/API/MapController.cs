using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonGo.Data;
using PokemonGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonGo.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Map
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointViewModel>>> GetPoints()
        {
            var points = await _context.Points
                                //.Where(p => p.PointTypeId == 1)
                                .Select(p => new PointViewModel(p.Title, p.Latitude, p.Longitude, p.PointType.Name)).ToListAsync(); //.Name.Equals("Stop"));

            return points;
        }

        // GET: api/MapTest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Point>> GetPoint(int id)
        {
            var point = await _context.Points.FindAsync(id);

            if (point == null)
            {
                return NotFound();
            }

            return point;
        }
    }
}
