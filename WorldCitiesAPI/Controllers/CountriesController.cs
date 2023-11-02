using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCitiesClass;

namespace WorldCitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountriesController : ControllerBase
    {
        private readonly Com584dbContext _db;

        public CountriesController(Com584dbContext db)
        {
            _db = db;
        }
        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _db.Countries.ToList();
        }
        // GET: api/Countries/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Countries
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
