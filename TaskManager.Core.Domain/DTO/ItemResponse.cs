using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Domain.Entities;

namespace TaskManager.Core.Domain.DTO
{
    public class ItemResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateOnly DueDate { get; set; }

        public bool Status { get; set; }

        public Item ToItem()
        {
            return new Item
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                DueDate = this.DueDate,
                Status = this.Status
            };
        }
    }

    public static class ItemExtensions
    {
        public static ItemResponse ToItemResponse(this Item item)
        {
            return new ItemResponse
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                DueDate = item.DueDate,
                Status = item.Status
            };
        }

        public static List<ItemResponse> ToItemResponseList(this List<Item> items)
        {
            List<ItemResponse> itemResponses = new List<ItemResponse>();
            foreach (var item in items)
            {
                itemResponses.Add(item.ToItemResponse());
            }
            return itemResponses;
        }
    }
}
