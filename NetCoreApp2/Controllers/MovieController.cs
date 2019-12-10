using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MovieClubComponent;

namespace NetCoreApp2.Controllers
{
    [Route("RestMovieClubCmp/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        Movie _DllMovieClubComponent;

        public MovieController()
        {
            _DllMovieClubComponent = new Movie();
        }

        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Entities.Movie> Get()
        {
            return _DllMovieClubComponent.GetLista();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public Entities.Movie Get(int id)
        {
            return _DllMovieClubComponent.GetEntity(id);
        }


        // GET: api/Movie/GetActors/5
        [HttpGet("{id}/GetActors")]
        public IEnumerable<Entities.Actor> GetActors(int id)
        {
            return _DllMovieClubComponent.GetMovieActors(id);
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] Entities.Movie eMovie)
        {
            _DllMovieClubComponent.Guardar(eMovie);  
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Movie eMovie)
        {
            _DllMovieClubComponent.Modificar(eMovie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _DllMovieClubComponent.Eliminar(id);  
        }
    }
}
