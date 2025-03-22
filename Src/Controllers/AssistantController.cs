using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssistantController : ControllerBase
    {
        public class Assistant
        {
            public required int Id { get; init; }
            public required string Name { get; set; }
            public required string Lastname { get; set; }
            public required string Email { get; set; }
        }

        private readonly List<Assistant> _assistants =
        [
            new Assistant
            {
                Id = 1,
                Name = "Ernes",
                Lastname = "Fuenzalida",
                Email = "ernes.fuenzalida@alumnos.ucn.cl",
            },
            new Assistant
            {
                Id = 2,
                Name = "Fernando",
                Lastname = "Chávez",
                Email = "fernando.chavez@alumnos.ucn.cl",
            },
            new Assistant
            {
                Id = 3,
                Name = "Ignacio",
                Lastname = "Valenzuela",
                Email = "ignacio.valenzuela@alumnos.ucn.cl",
            },
        ];

        [HttpGet]
        public ActionResult<IEnumerable<Assistant>> GetAssistants([FromQuery] string name)
        {
            IEnumerable<Assistant> assistants = _assistants;

            if (!string.IsNullOrEmpty(name))
            {
                assistants = assistants.Where(x =>
                    x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                );
            }

            return Ok(assistants);
        }

        [HttpGet("{id}")]
        public ActionResult<Assistant> GetAssistant([FromRoute] int id)
        {
            var assistant = _assistants.FirstOrDefault(x => x.Id == id);

            if (assistant == null)
            {
                return NotFound();
            }

            return Ok(assistant);
        }

        [HttpPost]
        public ActionResult<Assistant> CreateAssistant([FromBody] Assistant assistant)
        {
            _assistants.Add(assistant);
            return CreatedAtAction(nameof(GetAssistants), new { id = assistant.Id }, assistant);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAssistant(int id, Assistant assistant)
        {
            var assistantToUpdate = _assistants.FirstOrDefault(x => x.Id == id);

            if (assistantToUpdate == null)
            {
                return NotFound();
            }

            assistantToUpdate.Name = assistant.Name;
            assistantToUpdate.Lastname = assistant.Lastname;
            assistantToUpdate.Email = assistant.Email;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAssistant([FromRoute] int id)
        {
            var assistantToDelete = _assistants.FirstOrDefault(x => x.Id == id);

            if (assistantToDelete == null)
            {
                return NotFound();
            }

            _assistants.Remove(assistantToDelete);

            return NoContent();
        }
    }
}
