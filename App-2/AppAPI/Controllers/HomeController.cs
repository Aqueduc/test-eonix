using AppAPI.DataObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private PersonneContext PersonneContext;

        public HomeController(PersonneContext personneContext)
        {
            //Middleware
            PersonneContext = personneContext;
        }

        [HttpGet("GetPersonnes")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Personne>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult GetPersonnes()
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            if (PersonneContext.Personne.Count() == 0)
                return NoContent();

            return Ok(PersonneContext.Personne.ToList());
        }

        [HttpGet("GetPersonne")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Personne>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult GetPersonne(string? prenom = null, string? nom = null)
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            if (string.IsNullOrEmpty(prenom) && string.IsNullOrEmpty(nom))
                return GetPersonnes();
            var _tmp = PersonneContext.Personne.ToList();
            var _founds = _tmp.Where(p => _tmp.Any(o => p.IsMatch(prenom, nom))).ToList();

            if (_founds.Count == 0)
                return NoContent();

            return Ok(_founds);
        }

        [HttpGet("GetPersonne/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Personne))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult GetPersonne(Guid id)
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            var _tmp = PersonneContext.Personne.ToList();
            var _found = _tmp.FirstOrDefault(p => p.Id == id);

            if (_found is null)
                return NoContent();

            return Ok(_found);
        }

        [HttpPost("AddPersonne")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Personne))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult AddPersonne([FromBody] Personne personne)
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            if (PersonneContext.Personne.Find(personne.Id) is not null)
                return BadRequest("L'utilisateur est déjà en DB");

            //par défaut c'est ce GUID, donc si c'est celui la, on change
            if (personne.Id == Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))
                personne.Id = new Guid();
            try
            {
                PersonneContext.Personne.Add(personne);
                PersonneContext.SaveChanges();
            }
            catch (Exception ex) { return BadRequest("Erreur : " + ex.Message); }

            return Ok(personne);
        }

        [HttpPut("UpdatePersonne")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Personne))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult UpdatePersonne([FromBody] Personne personne)
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            if (PersonneContext.Personne.Find(personne.Id) is null)
                return NoContent();

            try
            {
                PersonneContext.Personne.Update(personne);
                PersonneContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(personne);
        }

        [HttpDelete("DeletePersonne")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Personne))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeletePersonne([FromBody] Personne personne)
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            if (PersonneContext.Personne.Find(personne.Id) is null)
                return NoContent();

            try
            {
                PersonneContext.Personne.Remove(personne);
                PersonneContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(personne);
        }

        [HttpDelete("DeletePersonne/{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Personne))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeletePersonne(Guid id)
        {
            if (PersonneContext is null)
                return BadRequest("Contexte DB null");

            if (PersonneContext.Personne is null)
                return BadRequest("Data null");

            var _found = PersonneContext.Personne.Find(id);
            if (_found is null)
                return NoContent();

            try
            {
                PersonneContext.Personne.Remove(_found);
                PersonneContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_found);
        }
    }
}
