using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieControllerDemoCursoController : ControllerBase
    {
        // GET: api/MovieControllerDemoCurso
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MovieControllerDemoCurso/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MovieControllerDemoCurso
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MovieControllerDemoCurso/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
