using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Domain.ServiceContracts;
using Microsoft.Extensions.Logging;
using TaskManager.Core.Domain.DTO;
using TaskManager.Core.Domain.Common;

namespace TaskManagerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ITaskAdderService _taskAdderService;
        private readonly ITaskDeleterService _taskDeleterService;
        private readonly ITaskGetterService _taskGetterService;
        private readonly ITaskUpdaterService _taskUpdaterService;
        ILogger<ItemsController> _logger;

        public ItemsController(ITaskAdderService taskAdderService, ITaskDeleterService taskDeleterService, ITaskGetterService taskGetterService, ITaskUpdaterService taskUpdaterService, ILogger<ItemsController> logger)
        {
            _taskAdderService = taskAdderService;
            _taskDeleterService = taskDeleterService;
            _taskGetterService = taskGetterService;
            _taskUpdaterService = taskUpdaterService;
            _logger = logger;
        }

        // Read operations
        [HttpGet("GetAllTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response> GetAllItems()
        {
            return await _taskGetterService.GetAllItems();
        }

        [HttpGet("GetTaskById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Response> GetItemByItemId(Guid id)
        {
            return await _taskGetterService.GetItemByItemId(id);
        }

        // Create operation
        [HttpPost("AddTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<Response> AddItem([FromBody] ItemAddRequest itemRequest)
        {
            return await _taskAdderService.AddItem(itemRequest);
        }

        // Update operation
        [HttpPut("UpdateTask/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Response> UpdateItem(Guid id, [FromBody] ItemUpdateRequest itemUpdateRequest)
        {
            return await _taskUpdaterService.UpdateTask(itemUpdateRequest);
        }

        // Delete operation
        [HttpDelete("DeleteTask/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Response> DeleteItem(Guid id)
        {
            return await _taskDeleterService.DeleteTask(id);
        }

    }
}
