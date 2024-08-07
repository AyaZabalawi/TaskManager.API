using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Domain.Entities;
using TaskManager.Core.Domain.RepositoryContracts;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace TaskManager.Infrastructure.Repositories
{

    public class ItemRepository : IRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ItemRepository> _logger;
        public ItemRepository(ApplicationDbContext db, ILogger<ItemRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        public async Task<Item> AddItem(Item item)
        {
            _db.Tasks.Add(item);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"Task {item.Id} added successfully");
            return item;
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            var item = _db.Tasks.Find(id);

            if (item==null)
            {
                _logger.LogWarning($"Item with id {id} not found");
                return false;
            }
           
            _db.Remove(item);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"Task {id} deleted successfully");
            return true;
            
        }

        public async Task<List<Item>> GetAllItems()
        {
            var items = await _db.Tasks.ToListAsync();
            _logger.LogInformation("All tasks retrieved successfully");
            return items;
        }

        public async Task<Item?> GetItemByItemId(Guid ID)
        {
            var item = _db.Tasks.Find(ID);  
            if(item==null)
            {
                _logger.LogWarning($"Task {ID} does not exist");
            }
            _logger.LogInformation($"Task {ID} retrieved successfully");
            return item;
        }

        public async Task<Item> UpdateItem(Item updated)
        {
            var searchid = updated.Id;
            var item = _db.Tasks.Find(searchid);
            if (item == null)
            {
                _logger.LogWarning($"Task {searchid} does not exist");
                return updated;
            }

            item.Id = searchid;
            item.Title = updated.Title;
            item.Description = updated.Description;
            item.Status = updated.Status;

            await _db.SaveChangesAsync();
            _logger.LogInformation($"Task {searchid} updated successfully");
            return item;
        }
    }
}
