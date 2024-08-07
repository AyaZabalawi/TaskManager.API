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
    public class TaskUpdaterService : ITaskUpdaterService
    {
        private readonly IRepository _repository;
        private readonly ILogger<TaskUpdaterService> _logger;

        public TaskUpdaterService(IRepository repository, ILogger<TaskUpdaterService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response> UpdateTask(ItemUpdateRequest itemUpdateRequest)
        {
            try
            {
                var item = itemUpdateRequest.ToItem();
                var searchid = item.Id;
                var searchitem = _repository.GetItemByItemId(searchid);
                if (searchitem == null)
                {
                    _logger.LogWarning($"Task {searchid} not found");
                }

                var updateditem = await _repository.UpdateItem(item);
                var itemResponse = updateditem.ToItemResponse();
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = itemResponse
                };

                return response;

                _logger.LogInformation($"Task {searchid} updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Error while executing {ex.Message}");
                return new Response();
            }
        }
    }
}


