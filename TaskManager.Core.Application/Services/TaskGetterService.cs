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
    public class TaskGetterService : ITaskGetterService
    {
        private readonly IRepository _repository;
        private readonly ILogger<TaskGetterService> _logger;

        public TaskGetterService(IRepository repository, ILogger<TaskGetterService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response> GetAllItems()
        {
            try
            {
                var items = await _repository.GetAllItems();
                var itemsResponses = items.ToItemResponseList();
                _logger.LogInformation("Retrieved all tasks");
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = itemsResponses
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Error while executing {ex.Message}");
                return new Response();
            }
        }

        public async Task<Response> GetItemByItemId(Guid ID)
        {
            try
            {
                var item = await _repository.GetItemByItemId(ID);
                if (item == null)
                {
                    _logger.LogWarning($"Task {ID} does not exist");

                }
                _logger.LogInformation($"Retrieved task {ID}");
                var itemResponse = item.ToItemResponse();
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = itemResponse
                };
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

