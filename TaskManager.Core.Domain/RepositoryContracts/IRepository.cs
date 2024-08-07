using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Domain.Entities;

namespace TaskManager.Core.Domain.RepositoryContracts
{
    public interface IRepository
    {
        Task <Item> AddItem(Item item);
        Task <bool> DeleteItem(Guid id);
        Task <List<Item>> GetAllItems();
        Task <Item?> GetItemByItemId(Guid ID);
        Task<Item> UpdateItem(Item updated);
    }
}
