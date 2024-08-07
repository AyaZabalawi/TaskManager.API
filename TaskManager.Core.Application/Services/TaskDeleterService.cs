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
    public class TaskDeleterService : ITaskDeleterService
    {
        private readonly IRepository _repository;
        private readonly ILogger<TaskDeleterService> _logger;

        public TaskDeleterService(IRepository repository, ILogger<TaskDeleterService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        
        public async Task<Response> DeleteTask(Guid ID)
        {
            try
            {
                var deleted = await _repository.DeleteItem(ID);
                if (deleted)
                {
                    _logger.LogInformation($"Task {ID} has been deleted");


                }
                else { _logger.LogWarning($"Task {ID} not found"); }

                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = deleted
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

