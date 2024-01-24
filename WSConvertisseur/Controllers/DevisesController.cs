using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        private List<Devise> devises;

        public DevisesController()
        {
            devises = new List<Devise>
            {
                new Devise { Id = 1, NomDevise = "Dollar", Taux =  1.08 },
                new Devise { Id = 2, NomDevise = "Franc Suisse", Taux = 1.07 },
                new Devise { Id = 3, NomDevise = "Yen", Taux = 120 },
            };
        }

        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return devises;
        }

        // GET api/<DevisesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DevisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
