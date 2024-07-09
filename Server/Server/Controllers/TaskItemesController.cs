using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemesController : ControllerBase
    {
        private IService service;

/*        private TaskContext _Context;
*/

        public TaskItemesController(IService service)
        {
            this.service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpPost]
        public IActionResult Add(TaskItem task)
        {
            if (!service.Add(task))
            {
                return Conflict();
            }
            return CreatedAtAction("add", task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
               if(!service.Delete(id))
            {
                return NotFound();
            }return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(TaskItem task)
        
        { 
            if(!service.Update(task))
            {
                return NotFound();
            }
            return NoContent();
        }

        
    

    }
}
