using BusinessLogic.DTO;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testingpipelines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly BusinessLogic.ILogic _logic;

        // Injecting the Logic service via constructor injection
        public MainController(ILogic logic)
        {
            _logic = logic;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<IActionResult> GetModels()
        {
            var models = await _logic.GetModelsAsync();  // Fetching the list of models from business logic
            return Ok(models);  // Returning 200 OK with the model list
        }

        // POST: api/Models
        [HttpPost]
        public async Task<IActionResult> AddModel([FromBody] ModelDTO modelDto)
        {
            if (modelDto == null)
            {
                return BadRequest("Model data is null");  // Return 400 Bad Request if the model is null
            }

            var addedModel = await _logic.AddModelAsync(modelDto);  // Adding a new model using the business logic
            return CreatedAtAction(nameof(GetModels), new { id = addedModel.Id }, addedModel);  // Return 201 Created
        }

        // DELETE: api/Models/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            await _logic.DeleteModelAsync(id);  // Calling the business logic to delete the model
            return NoContent();  // Return 204 No Content, indicating the delete operation was successful
        }
    }
}
