using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Domain.Entities;

namespace TaskManager.Core.Domain.DTO
{
    public class ItemUpdateRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateOnly DueDate { get; set; }

        [Required]
        public bool Status { get; set; }

        public Item ToItem()
        {
            return new Item
            {
                Title = Title,
                Description = Description,
                DueDate = DueDate,
                Status = Status
            };
        }
    }
}
