using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Utils;

namespace NetCoreApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Entities.Movie> Get()
        {
              Business.Movie  oMovie = new Business.Movie();
            return oMovie.GetListaMovies();
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public Entities.Movie Get(int id)
        {
            Business.Movie oMovie = new Business.Movie();
            return oMovie.GetMovie(id);
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] Entities.Movie eMovie)
        {
            Business.Movie oMovie = new Business.Movie();
            oMovie.Guardar(eMovie);  
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Movie eMovie)
        {
            Business.Movie oMovie = new Business.Movie();
            oMovie.Modificar(eMovie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
