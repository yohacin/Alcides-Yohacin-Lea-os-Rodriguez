using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MovieClubComponent;

namespace NetCoreApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        Movie _Movie;

        public MovieController()
        {
            _Movie = new Movie();
        }

        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Entities.Movie> Get()
        {
            return _Movie.GetLista();
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public Entities.Movie Get(int id)
        {
            Movie _Movie = new Movie();
            return _Movie.GetEntity(id);
        }


        // GET: api/Movie/GetActors/5
        [HttpGet("{id}/GetActors")]
        public IEnumerable<Entities.Actor> GetActors(int id)
        {
            return _Movie.GetMovieActors(id);
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] Entities.Movie eMovie)
        {
            _Movie.Guardar(eMovie);  
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Movie eMovie)
        {
           _Movie.Modificar(eMovie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _Movie.Eliminar(id);  
        }
    }
}
