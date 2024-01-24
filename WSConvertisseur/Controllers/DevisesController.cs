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
        /// <summary>
        /// Récupérer toutes les devises
        /// </summary>
        /// <returns>List IEnumerable des devises</returns>
        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return devises;
        }

        /// <summary>
        /// Obtient une devise spécifique par son ID.
        /// </summary>
        /// <param name="id">L'identifiant de la devise à récupérer.</param>
        /// <returns>Devise correspondant à l'ID spécifié.</returns>
        /// <response code="404"></response>
        // GET api/<DevisesController>/5
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}", Name = "GetDevise")]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise = (from d in devises where d.Id == id select d).FirstOrDefault();
            // Devise? devise = devises.FirstOrDefault((d) => d.Id == id); //meme chose mais lambda expression
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// Ajoute une nouvelle devise.
        /// </summary>
        /// <param name="devise">La nouvelle devise à ajouter.</param>
        /// <returns>Devise ajoutée avec une réponse 201 Created.</returns>
        /// <response code="201"></response>
        /// <response code="400"></response>
        // POST api/<DevisesController>
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Met à jour une devise existante par son ID.
        /// </summary>
        /// <param name="id">L'identifiant de la devise à mettre à jour.</param>
        /// <param name="devise">Les nouvelles données de la devise.</param>
        /// <returns>Renvoie une réponse 204 No Content si la mise à jour est réussie.</returns>
        /// <response code="204"></response>
        /// <response code="400"></response>
        /// <response code="404"></response>
        // PUT api/<DevisesController>/5
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Supprime une devise par son ID.
        /// </summary>
        /// <param name="id">L'identifiant de la devise à supprimer.</param>
        /// <returns>Devise supprimée avec une réponse 200 OK.</returns>
        /// <response code="404"></response>
        /// <response code="200"></response>
        // DELETE api/<DevisesController>/5
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise = (from d in devises where d.Id == id select d).FirstOrDefault();
            // Devise? devise = devises.FirstOrDefault((d) => d.Id == id); //meme chose mais lambda expression
            if (devise == null)
            {
                return NotFound();
            }
            devises.Remove(devise);
            return devise;
        }
    }
}
