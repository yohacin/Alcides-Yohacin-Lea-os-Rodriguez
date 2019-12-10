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
    public class ActorController : ControllerBase
    {
        Actor _DllMovieClubComponent;

        public ActorController()
        {
            _DllMovieClubComponent = new Actor();
        }

        // GET: api/Actor
        [HttpGet]
        public IEnumerable<Entities.Actor> Get()
        {
            return _DllMovieClubComponent.GetLista();
        }

        // GET: api/Actor/5
        [HttpGet("{id}")]
        public Entities.Actor Get(int id)
        {
            return _DllMovieClubComponent.GetEntity(id);
        }


        // GET: api/Actor/GetActors/5
        [HttpGet("{id}/GetMovies")]
        public IEnumerable<Entities.Movie> GetMovies(int id)
        {
            return _DllMovieClubComponent.GetMovies(id);
        }

        // POST: api/Actor
        [HttpPost]
        public void Post([FromBody] Entities.Actor eActor)
        {
            _DllMovieClubComponent.Guardar(eActor);
        }

        // PUT: api/Actor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Actor eActor)
        {
            _DllMovieClubComponent.Modificar(eActor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _DllMovieClubComponent.Eliminar(id);
        }
    }
}
