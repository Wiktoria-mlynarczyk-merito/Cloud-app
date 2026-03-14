using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private static List<string> tasks = new List<string>()
        {
            "Learn ASP.NET",
            "Build API",
            "Connect React"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= tasks.Count)
                return NotFound();

            return Ok(tasks[id]);
        }

        [HttpPost]
        public IActionResult Create([FromBody] string task)
        {
            tasks.Add(task);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string task)
        {
            if (id < 0 || id >= tasks.Count)
                return NotFound();

            tasks[id] = task;
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= tasks.Count)
                return NotFound();

            tasks.RemoveAt(id);
            return Ok(tasks);
        }
    }
}
