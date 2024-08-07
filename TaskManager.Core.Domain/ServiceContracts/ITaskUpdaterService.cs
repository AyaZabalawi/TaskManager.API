using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Domain.Entities;
using TaskManager.Core.Domain.Common;
using TaskManager.Core.Domain.DTO;

namespace TaskManager.Core.Domain.ServiceContracts
{
    public interface ITaskUpdaterService
    {
        Task<Response> UpdateTask(ItemUpdateRequest itemUpdateRequest);
    }
}
