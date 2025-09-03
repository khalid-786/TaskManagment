using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public TaskStatusEnum Status { get; set; }
        [Required]
        public TaskPriorityEnum Priority { get; set; }
    }
}
