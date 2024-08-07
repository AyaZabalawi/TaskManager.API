using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Domain.Common;
using TaskManager.Core.Domain.DTO;
using TaskManager.Core.Domain.RepositoryContracts;
using TaskManager.Core.Domain.ServiceContracts;

namespace TaskManager.Core.Application.Services
{
    public class TaskAdderService : ITaskAdderService
    {
        private readonly IRepository _repository;
        private readonly ILogger<TaskAdderService> _logger;

        public TaskAdderService(IRepository repository, ILogger<TaskAdderService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response> AddItem(ItemAddRequest itemAddRequest)
        {
            try
            {
                var item = itemAddRequest.ToItem();
                item.Id = Guid.NewGuid();

                var addedItem = await _repository.AddItem(item);
                var addedItemResponse = addedItem.ToItemResponse();

                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = addedItemResponse
                };

                _logger.LogInformation($"Item {item.Id} added successfully");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Error while executing {ex.Message}");
                return new Response();
            }
        }

    }
}
