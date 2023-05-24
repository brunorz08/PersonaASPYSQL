using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ParcialRaffoZelada.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PersonaController : Controller
	{
		public List<Persona> personas;
		private readonly AppDbContext _dbContext;


		public PersonaController(AppDbContext dbContext)

		{

			_dbContext = dbContext;

			personas = new List<Persona>
		{
			new Persona { Id = 1,nombre = "Bruno",edad = 25},
			new Persona { Id = 2,nombre = "Claudia",edad = 63},
			new Persona{ Id = 3,nombre = "Claudio",edad = 62}
		};

		}

		//Punto 11) Retonar datos en memoria.
		[HttpGet]
		public ActionResult<IEnumerable<Persona>> ObtenerPersonasDesdeMemoria()
		{
			return personas;

		}


		//12)
		//Metodo obtener persona por ID
		[HttpGet("{id}")]
		public ActionResult<Persona> ObtenerPersona(int id)
		{
			var persona = _dbContext.personas.Find(id);

			if (persona == null)
			{
				return NotFound();
			}

			return persona;
		}

		//Metodo crear persona
		[HttpPost]
		public ActionResult<Persona> CrearPersona([FromBody] Persona per)
		{
			_dbContext.personas.Add(per);
			_dbContext.SaveChanges();

			return per;
		}

		//Metodo Borrar mediante ID

		[HttpDelete("{id}")]
		public IActionResult BorrarPersona(int id)
		{
			var Persona = _dbContext.personas.Find(id);
			if (Persona == null)
			{
				
				return NotFound();
			}
			_dbContext.personas.Remove(Persona);
			_dbContext.SaveChanges();
			return NoContent();
		}


		//Metodo para modificar Persona mediante ID
		[HttpPut("{id}")]
		public ActionResult ModificarPersona(int id, [FromBody] Persona per)
		{
			var personaAModificar = _dbContext.personas.Find(id);

			if (personaAModificar == null)
			{
				return NotFound();
			}

			if (id != personaAModificar.Id)
			{
				return BadRequest();
			}

			_dbContext.Entry(personaAModificar).CurrentValues.SetValues(per);
			_dbContext.SaveChanges();

			return Ok();
		}



	}
}
