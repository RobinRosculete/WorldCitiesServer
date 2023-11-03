using Microsoft.AspNetCore.Mvc;
using WorldCitiesClass;
using Microsoft.AspNetCore.Authorization;
using WorldCitiesAPI.DTOs;

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
        [Authorize]
        public IEnumerable<Country> Get()
        {
            return _db.Countries.ToList();
        }

        //LINQ statement to get country info inculding population
        [HttpGet("Population/{id}")]
        public CountryPopulation? GetPopulation(int id)
        {
            /* *SELECT ID, NAME, COUNT(POPULATION)
               *FROM Countries
               *WHERE Countrie.ID = ID*/
             return _db.Countries.Where(c => c.Id == id).Select(c => new CountryPopulation()
             {
                 Id = c.Id,
                 Name = c.Name,
                 Population = c.Cities.Sum(t => t.Population)

             }).SingleOrDefault();

           /* return (from country in _db.Countries
                    where country.Id == id
                    select new CountryPopulation()
                    {
                        Id = country.Id,
                        Name = country.Name,
                        Population = country.Cities.Sum(t => t.Population)

                    }).SingleOrDefault(); */

                ;
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
